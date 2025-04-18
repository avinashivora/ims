using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace ims.UI.Forms
{
    partial class CategoryItemViewer
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel panel;
        private FlowLayoutPanel flowItems;
        private Guna2HtmlLabel lblPrompt;
        private Guna2Button btnYes;
        private Guna2Button btnNo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panel = new Guna2Panel();
            flowItems = new FlowLayoutPanel();
            lblPrompt = new Guna2HtmlLabel();
            btnYes = new Guna2Button();
            btnNo = new Guna2Button();

            panel.Dock = DockStyle.Fill;
            panel.Controls.Add(flowItems);
            panel.Controls.Add(lblPrompt);
            panel.Controls.Add(btnYes);
            panel.Controls.Add(btnNo);

            flowItems.Location = new Point(20, 20);
            flowItems.Size = new Size(740, 400);
            flowItems.AutoScroll = true;

            lblPrompt.Text = "This category contains items. Do you want to proceed with deletion?";
            lblPrompt.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPrompt.Location = new Point(20, 440);
            lblPrompt.AutoSize = true;

            btnYes.Text = "Yes";
            btnYes.Location = new Point(580, 480);
            btnYes.Size = new Size(80, 36);
            btnYes.Click += BtnYes_Click;

            btnNo.Text = "No";
            btnNo.Location = new Point(670, 480);
            btnNo.Size = new Size(80, 36);
            btnNo.Click += BtnNo_Click;

            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 530);
            Controls.Add(panel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Items in Category";
        }
    }
}
