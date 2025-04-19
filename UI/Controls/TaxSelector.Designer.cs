using System.Windows.Forms;

namespace ims.UI.Controls
{
    partial class TaxSelector
    {
        private Label lblTax;
        private FlowLayoutPanel flpTaxOptions;

        private void InitializeComponent()
        {
            this.lblTax = new System.Windows.Forms.Label();
            this.flpTaxOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();

            // lblTax
            this.lblTax.AutoSize = true;
            this.lblTax.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTax.Location = new System.Drawing.Point(10, 10);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(80, 15);
            this.lblTax.TabIndex = 0;
            this.lblTax.Text = "Tax Rate:";

            // flpTaxOptions
            this.flpTaxOptions.AutoSize = true;
            this.flpTaxOptions.Location = new System.Drawing.Point(10, 30);
            this.flpTaxOptions.Name = "flpTaxOptions";
            this.flpTaxOptions.Size = new System.Drawing.Size(400, 40);
            this.flpTaxOptions.TabIndex = 1;
            this.flpTaxOptions.WrapContents = false;

            // TaxSelector
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.flpTaxOptions);
            this.Name = "TaxSelector";
            this.Size = new System.Drawing.Size(420, 80);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
