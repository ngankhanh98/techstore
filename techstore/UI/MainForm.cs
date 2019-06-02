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
            //string path = "SERVER=db4free.net; PORT=3306; DATABASE=techmart; UID=techmart; PWD=techmart;oldguids=true";
            //MySqlConnection conn = new MySqlConnection(path);

            //string query = "SELECT * FROM Products";
            //MySqlDataAdapter adapter = new MySqlDataAdapter(query,conn);

            //DataTable table = new DataTable();
            //adapter.Fill(table);
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
            //string path = "SERVER=db4free.net; PORT=3306; DATABASE=techmart; UID=techmart; PWD=techmart;oldguids=true";
            //MySqlConnection conn = new MySqlConnection(path);

            //string cmd = string.Format("INSERT INTO `Products`(`Name`, `Brand`, `Price`, `Description`, `Available`) VALUES ('{0}','{1}',{2},'{3}',{4})",product.name, product.brand, product.price, product.des, product.available);
            //conn.Open();
            //MySqlCommand command = new MySqlCommand(cmd, conn);
            //command.ExecuteNonQuery();
            //conn.Close();
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
            //string path = "SERVER=db4free.net; PORT=3306; DATABASE=techmart; UID=techmart; PWD=techmart;oldguids=true";
            //MySqlConnection conn = new MySqlConnection(path);

            //string cmd = string.Format("UPDATE `Products` SET `Price`={2},`Description`='{3}',`Available`={4} WHERE `Name`='{0}' AND `Brand`='{1}'", product.name, product.brand, product.price, product.des, product.available);
            //conn.Open();
            //MySqlCommand command = new MySqlCommand(cmd, conn);
            //command.ExecuteNonQuery();
            //conn.Close();

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

                //string path = "SERVER=db4free.net; PORT=3306; DATABASE=techmart; UID=techmart; PWD=techmart;oldguids=true";
                //MySqlConnection conn = new MySqlConnection(path);

                //string cmd = string.Format("DELETE FROM `Products` WHERE `Name`='{0}' AND `Brand`='{1}'", product.name, product.brand);
                //conn.Open();
                //MySqlCommand command = new MySqlCommand(cmd, conn);
                //command.ExecuteNonQuery();
                //conn.Close();
                proDAO.OnDelete(product);
                OnLoad();
            }
        }
    }
}
