using System.Windows.Forms;
using ims.Models;
using ims.UI.Controls;

namespace ims.UI.Forms
{
    public partial class ItemForm : Form
    {
        private readonly ItemFormControl _formControl;
        public Item UpdatedItem => _formControl.UpdatedItem;
        public string NewItemCategoryId { get; private set; }

        public ItemForm(Item item = null)
        {
            InitializeComponent();

            _formControl = new ItemFormControl(item)
            {
                Dock = DockStyle.Fill
            };
            _formControl.ItemSaved += (_, _) => this.Close();
            _formControl.NewItemSaved += ItemFormControl_NewItemSaved; // Subscribe to the event

            this.Controls.Add(_formControl);
        }

        private void ItemFormControl_NewItemSaved(string categoryId)
        {
            NewItemCategoryId = categoryId;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            // The UpdatedItem is a direct getter to the FormControl's property,
            // so no need to assign it here on FormClosed.
        }
    }
}