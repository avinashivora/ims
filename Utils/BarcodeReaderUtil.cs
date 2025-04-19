using System;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace ims.Utils
{
    public class BarcodeReaderUtil
    {
        private bool _isReading;
        private string _currentInput;
        private Timer _timer;
        private const int TIMEOUT_MS = 100; // 100ms timeout for barcode scanner input

        public event EventHandler<BarcodeReadEventArgs> BarcodeRead;

        public class BarcodeReadEventArgs : EventArgs
        {
            public string Barcode { get; set; }
        }

        public BarcodeReaderUtil()
        {
            _isReading = false;
            _currentInput = string.Empty;
            _timer = new Timer(OnTimerElapsed, null, Timeout.Infinite, Timeout.Infinite);
        }

        public void HookToControl(Control control)
        {
            // Hook to the control's KeyPress event
            control.KeyPress += Control_KeyPress;
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Start reading mode if not already reading
            if (!_isReading)
            {
                _isReading = true;
                _currentInput = string.Empty;
            }

            // Append the character to the current input
            _currentInput += e.KeyChar;

            // Reset the timer to detect the end of barcode input
            _timer.Change(TIMEOUT_MS, Timeout.Infinite);
        }

        private void OnTimerElapsed(object state)
        {
            // Timer elapsed, process the barcode
            _isReading = false;

            // If the input is not empty, raise the event with the barcode
            if (!string.IsNullOrEmpty(_currentInput))
            {
                // Remove the last character if it's a enter key (common in barcode scanners)
                if (_currentInput.EndsWith("\r") || _currentInput.EndsWith("\n"))
                {
                    _currentInput = _currentInput.TrimEnd('\r', '\n');
                }

                // Raise the barcode read event
                BarcodeRead?.Invoke(this, new BarcodeReadEventArgs { Barcode = _currentInput });
            }

            _currentInput = string.Empty;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}