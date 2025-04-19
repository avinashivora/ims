using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using ims.Services;
using ims.Utils;
using Microsoft.Win32;
using Org.BouncyCastle.Asn1.Cmp;

namespace ims.UI.Controls
{
    public partial class BarcodeInputPanel : UserControl
    {
        private readonly BarcodeService _barcodeService;
        private readonly BarcodeReaderUtil _barcodeReaderUtil;

        public event EventHandler<BarcodeReadEventArgs> BarcodeDetected;

        public class BarcodeReadEventArgs : EventArgs
        {
            public string Barcode { get; set; }
            public bool Success { get; set; }
            public string ErrorMessage { get; set; }
        }

        public BarcodeInputPanel(BarcodeService barcodeService)
        {
            InitializeComponent();
            _barcodeService = barcodeService;

            _barcodeReaderUtil = new BarcodeReaderUtil();
            _barcodeReaderUtil.BarcodeRead += BarcodeReaderUtil_BarcodeRead;
            _barcodeReaderUtil.HookToControl(this);

            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff";
        }

        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnAddItem_Click(sender, e);
            }
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            string barcode = txtBarcode.Text.Trim();
            if (!string.IsNullOrEmpty(barcode))
            {
                BarcodeDetected?.Invoke(this, new BarcodeReadEventArgs
                {
                    Barcode = barcode,
                    Success = true
                });

                txtBarcode.Clear();
                ShowStatus("Barcode processed successfully", true);
            }
            else
            {
                ShowStatus("Please enter a barcode", false);
            }
        }

        private void BtnUploadBarcode_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ShowStatus("Processing barcode image...", true);

                    string barcode = _barcodeService.DecodeBarcode(openFileDialog.FileName);

                    if (!string.IsNullOrEmpty(barcode))
                    {
                        BarcodeDetected?.Invoke(this, new BarcodeReadEventArgs
                        {
                            Barcode = barcode,
                            Success = true
                        });

                        ShowStatus($"Barcode detected: {barcode}", true);
                    }
                    else
                    {
                        ShowStatus("No barcode detected in the image", false);

                        BarcodeDetected?.Invoke(this, new BarcodeReadEventArgs
                        {
                            Success = false,
                            ErrorMessage = "No barcode detected in the image"
                        });
                    }
                }
                catch (Exception ex)
                {
                    ShowStatus($"Error: {ex.Message}", false);

                    BarcodeDetected?.Invoke(this, new BarcodeReadEventArgs
                    {
                        Success = false,
                        ErrorMessage = ex.Message
                    });
                }
            }
        }

        private void BarcodeReaderUtil_BarcodeRead(object sender, BarcodeReaderUtil.BarcodeReadEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ProcessScannerBarcode(e.Barcode)));
            }
            else
            {
                ProcessScannerBarcode(e.Barcode);
            }
        }

        private void ProcessScannerBarcode(string barcode)
        {
            if (!string.IsNullOrEmpty(barcode))
            {
                txtBarcode.Text = barcode;

                BarcodeDetected?.Invoke(this, new BarcodeReadEventArgs
                {
                    Barcode = barcode,
                    Success = true
                });

                ShowStatus("Barcode scanned successfully", true);

                Task.Delay(1000).ContinueWith(t =>
                {
                    if (InvokeRequired)
                        Invoke(new Action(() => txtBarcode.Clear()));
                    else
                        txtBarcode.Clear();
                });
            }
        }

        private void ShowStatus(string message, bool success)
        {
            lblStatus.Text = message;
            lblStatus.ForeColor = success ? Color.Green : Color.Red;
        }
    }
}
