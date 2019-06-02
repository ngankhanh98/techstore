using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using techstore.techstoreBUS;
using techstore.UI;

namespace techstore
{
    public partial class MainForm : Form
    {
        techstoreBUS.techstoreBUSSoapClient proDAO = new techstoreBUS.techstoreBUSSoapClient();

        public MainForm()
        {
            InitializeComponent();
            OnLoad();
        }

        public void OnLoad()
        {
            DataTable table = proDAO.OnLoad().Tables[0];
            dgvProducts.DataSource = table;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditForm form = new AddEditForm();
            form.OnInsert += Form_OnInsert;
            form.Show();
        }

        private void Form_OnInsert(Product product)
        {
            proDAO.OnInsert(product);
            OnLoad();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.name = dgvProducts.CurrentRow.Cells[0].Value.ToString();
            product.brand = dgvProducts.CurrentRow.Cells[1].Value.ToString();
            product.price = int.Parse(dgvProducts.CurrentRow.Cells[2].Value.ToString());
            product.des = dgvProducts.CurrentRow.Cells[3].Value.ToString();
            product.available = bool.Parse(dgvProducts.CurrentRow.Cells[4].Value.ToString());

            AddEditForm form = new AddEditForm(product);
            form.OnUpdate += Form_OnUpdate; ;
            form.Show();
        }

        private void Form_OnUpdate(Product product)
        {
            proDAO.OnUpdate(product);
            OnLoad();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Delete this?", "Delete", MessageBoxButtons.OKCancel)==DialogResult.OK))
            {
                Product product = new Product();
                product.name = dgvProducts.CurrentRow.Cells[0].Value.ToString();
                product.brand = dgvProducts.CurrentRow.Cells[1].Value.ToString();

                proDAO.OnDelete(product);
                OnLoad();
            }
        }
    }
}
