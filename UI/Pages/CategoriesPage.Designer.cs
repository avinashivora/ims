using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ims.UI.Pages
{
    partial class CategoriesPage
    {
        private Guna2DataGridView categoriesDataGrid;
        private Guna2Button btnAddCategory;

        private void InitializeComponent()
        {
            this.categoriesDataGrid = new Guna2DataGridView();
            this.btnAddCategory = new Guna2Button();

            ((System.ComponentModel.ISupportInitialize)(this.categoriesDataGrid)).BeginInit();
            this.SuspendLayout();

            // categoriesDataGrid
            this.categoriesDataGrid.AllowUserToAddRows = false;
            this.categoriesDataGrid.AllowUserToDeleteRows = false;
            this.categoriesDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.categoriesDataGrid.Location = new System.Drawing.Point(20, 70);
            this.categoriesDataGrid.Name = "categoriesDataGrid";
            this.categoriesDataGrid.Size = new System.Drawing.Size(760, 400);
            this.categoriesDataGrid.TabIndex = 0;
            this.categoriesDataGrid.CellContentClick += new DataGridViewCellEventHandler(this.CategoriesDataGrid_CellContentClick);

            // btnAddCategory
            this.btnAddCategory.Text = "Add Category";
            this.btnAddCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddCategory.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAddCategory.ForeColor = System.Drawing.Color.White;
            this.btnAddCategory.Size = new System.Drawing.Size(150, 40);
            this.btnAddCategory.Location = new System.Drawing.Point(20, 20);
            this.btnAddCategory.Click += new System.EventHandler(this.BtnAddCategory_Click);

            // CategoriesPage (UserControl)
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.categoriesDataGrid);
            this.Name = "CategoriesPage";
            this.Size = new System.Drawing.Size(800, 500);
            this.BackColor = System.Drawing.Color.White;

            ((System.ComponentModel.ISupportInitialize)(this.categoriesDataGrid)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
