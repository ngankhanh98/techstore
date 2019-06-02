using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using techstore.DTO;

namespace techstore.UI
{
    public partial class AddEditForm : Form
    {

        public delegate void UpdateEvent(Product product);
        public event UpdateEvent OnUpdate = null;

        public delegate void InsertEvent(Product product);
        public event InsertEvent OnInsert = null;

        public AddEditForm()
        {
            InitializeComponent();
        }

        public AddEditForm(Product product)
        {
            InitializeComponent();

            txtName.Text = product.name;
            txtBrand.Text = product.brand;
            txtDes.Text = product.des;
            nudPrice.Value = (decimal)product.price;
            cbAvailable.SelectedItem = (product.available == true) ? cbAvailable.Items[0] : cbAvailable.Items[1];

            btnOK.Text = "Save";
            txtBrand.ReadOnly = true;
            txtName.ReadOnly = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Product product = GetProductInfor();

            if(OnInsert!=null)
            {
                OnInsert(product);
                this.Close();
            }

            if (OnUpdate != null)
            {
                OnUpdate(product);
                this.Close();
            }
        }

        private Product GetProductInfor()
        {
            

            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;   // Uppercase First Letter

            Product product = new Product();
            product.name = myTI.ToTitleCase(txtName.Text);
            product.brand = myTI.ToTitleCase(txtBrand.Text);
            product.price = (int)nudPrice.Value;
            product.des = myTI.ToTitleCase(txtDes.Text);
            product.available = (cbAvailable.SelectedItem == "Remaining") ? true : false;

            return product;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
