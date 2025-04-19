using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using ims.Models;

namespace ims.UI.Controls
{
    public partial class TaxSelector : UserControl
    {
        private readonly List<TaxOption> _taxOptions;
        private readonly List<Guna2RadioButton> _radioButtons;
        private decimal _selectedTaxRate;

        public event EventHandler<TaxSelectedEventArgs> TaxSelected;

        public class TaxSelectedEventArgs : EventArgs
        {
            public decimal TaxRate { get; set; }
        }

        public TaxSelector()
        {
            InitializeComponent();

            _taxOptions = new List<TaxOption>
            {
                new TaxOption(0, "0%"),
                new TaxOption(5, "5%"),
                new TaxOption(12, "12%"),
                new TaxOption(18, "18%"),
                new TaxOption(28, "28%")
            };

            _radioButtons = new List<Guna2RadioButton>();
            CreateRadioButtons();

            _radioButtons[0].Checked = true;
            _selectedTaxRate = _taxOptions[0].Rate;
        }

        private void CreateRadioButtons()
        {
            for (int i = 0; i < _taxOptions.Count; i++)
            {
                var taxOption = _taxOptions[i];
                var radioButton = new Guna2RadioButton
                {
                    Text = taxOption.Display,
                    Tag = taxOption.Rate,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9F),
                    CheckedState =
                    {
                        BorderColor = Color.FromArgb(94, 148, 255),
                        FillColor = Color.FromArgb(94, 148, 255)
                    },
                    UncheckedState =
                    {
                        BorderColor = Color.FromArgb(125, 137, 149),
                        FillColor = Color.Transparent
                    },
                    Margin = new Padding(10, 3, 10, 3)
                };

                radioButton.CheckedChanged += RadioButton_CheckedChanged;

                _radioButtons.Add(radioButton);
                flpTaxOptions.Controls.Add(radioButton);
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is Guna2RadioButton radioButton && radioButton.Checked)
            {
                _selectedTaxRate = (decimal)radioButton.Tag;
                TaxSelected?.Invoke(this, new TaxSelectedEventArgs { TaxRate = _selectedTaxRate });
            }
        }

        public decimal SelectedTaxRate => _selectedTaxRate;
    }
}
