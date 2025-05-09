﻿using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ims.UI.Forms
{
    partial class DuplicateItemViewer
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel pnlContainer;
        private Guna2Button btnYes;
        private Guna2Button btnNo;
        private Guna2HtmlLabel lblPrompt;
        private FlowLayoutPanel flowLayoutPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlContainer = new Guna2Panel();
            this.flowLayoutPanel = new FlowLayoutPanel();
            this.lblPrompt = new Guna2HtmlLabel();
            this.btnYes = new Guna2Button();
            this.btnNo = new Guna2Button();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.flowLayoutPanel);
            this.pnlContainer.Controls.Add(this.lblPrompt);
            this.pnlContainer.Controls.Add(this.btnYes);
            this.pnlContainer.Controls.Add(this.btnNo);
            this.pnlContainer.Dock = DockStyle.Fill;
            this.pnlContainer.Location = new Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new Size(800, 600);
            this.pnlContainer.TabIndex = 0;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanel.WrapContents = false;
            this.flowLayoutPanel.Location = new Point(12, 12);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new Size(776, 500);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // lblPrompt
            // 
            this.lblPrompt.Text = "Item(s) with the same name exist. Create new item anyway?";
            this.lblPrompt.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblPrompt.Location = new Point(12, 520);
            this.lblPrompt.AutoSize = false;
            this.lblPrompt.Size = new Size(600, 25);
            // 
            // btnYes
            // 
            this.btnYes.Text = "Yes";
            this.btnYes.Location = new Point(620, 550);
            this.btnYes.Size = new Size(75, 30);
            this.btnYes.Click += new System.EventHandler(this.BtnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Text = "No";
            this.btnNo.Location = new Point(710, 550);
            this.btnNo.Size = new Size(75, 30);
            this.btnNo.Click += new System.EventHandler(this.BtnNo_Click);
            // 
            // DuplicateItemViewer
            // 
            this.ClientSize = new Size(800, 600);
            this.Controls.Add(this.pnlContainer);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Name = "DuplicateItemViewer";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Duplicate Items Found";
            this.pnlContainer.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
