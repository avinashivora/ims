using System.Drawing;
using System.Windows.Forms;

namespace ims.UI.Controls
{
    partial class TaxSelector
    {
        private Label lblTax;
        private FlowLayoutPanel flpTaxOptions;

        private void InitializeComponent()
        {
            this.lblTax = new Label();
            this.flpTaxOptions = new FlowLayoutPanel();
            this.SuspendLayout();

            // lblTax
            this.lblTax.AutoSize = true;
            this.lblTax.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblTax.Location = new Point(10, 10);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new Size(80, 15);
            this.lblTax.TabIndex = 0;
            this.lblTax.Text = "Tax Rate:";

            // flpTaxOptions
            this.flpTaxOptions.AutoSize = true;
            this.flpTaxOptions.Location = new Point(10, 30);
            this.flpTaxOptions.Name = "flpTaxOptions";
            this.flpTaxOptions.Size = new Size(400, 40);
            this.flpTaxOptions.TabIndex = 1;
            this.flpTaxOptions.WrapContents = false;

            // TaxSelector
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.flpTaxOptions);
            this.Name = "TaxSelector";
            this.Size = new Size(420, 80);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
