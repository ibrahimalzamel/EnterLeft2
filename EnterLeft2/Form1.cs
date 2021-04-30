using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnterLeft2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        //GetAll
        private void button1_Click(object sender, EventArgs e)
        {
            GetAllDataGirdview();
        }

        //checkTextBoxs ; True  or false
        private bool checkTextBoxs()
        {
            if (txtName.Text == ""|| txtCatogeriId.Text == "" || txtUnitPrice.Text == "")
            { return false; }

            else{return true;}
        }

        //Add
        private void button2_Click(object sender, EventArgs e)
        {
            ProductManager product1 = new ProductManager(new EfProductDal());
            bool checkDiscontinue = false;
            if (!checkTextBoxs())
            {
                MessageBox.Show("name vaya catogeri Id vaya unit price boş olmaz");
            }
            else
            {
                string message = "Do you want to Added product ? ";
                string title = "Product Add";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result1 = MessageBox.Show(message, title, buttons);
                if (result1 == DialogResult.Yes)
                {

                    if (checkDiscontinued.Checked)
                    {
                        checkDiscontinue = true;
                    }
                    var result = product1.Add(new Product
                    {
                       
                        ProductName = txtName.Text,
                        CategoryId = Convert.ToInt32(txtCatogeriId.Text),
                        UnitPrice = Convert.ToInt32(txtUnitPrice.Text),
                        Discontinued = checkDiscontinue
                    });
                    if (result.Success)
                    {
                       ClearTxt();
                       GetAllDataGirdview();
                    }
                   
                    MessageBox.Show(result.Message + " " + result.Success);
                }
            }
        }

        // update
        private void button3_Click(object sender, EventArgs e)
        {

           
                ProductManager product1 = new ProductManager(new EfProductDal());
                bool chekDiscontinue = false;
                if (!checkTextBoxs())
                {
                    MessageBox.Show("name vaya catogeri Id vaya unit price boş olmaz");
                }
            else
            {
                string message = "Do you want to update product ? ";
                string title = "Product update";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result1 = MessageBox.Show(message, title, buttons);
                if (result1 == DialogResult.Yes)
                {
                    if (checkDiscontinued.Checked)
                    {
                        chekDiscontinue = true;
                    }
                    var result = product1.Update(new Product
                    {
                        Id = Convert.ToInt32(txtId.Text),
                        ProductName = txtName.Text,
                        CategoryId = Convert.ToInt32(txtCatogeriId.Text),
                        UnitPrice = Convert.ToInt32(txtUnitPrice.Text),
                        Discontinued = chekDiscontinue
                    });
                    ClearTxt();
                    GetAllDataGirdview();
                    MessageBox.Show(result.Message + " " + result.Success);
                }
            }
        }

        //Delete
        private void button4_Click(object sender, EventArgs e)
        {
            
                ProductManager product1 = new ProductManager(new EfProductDal());
                bool chekDiscontinue = false;
                if (!checkTextBoxs())
                {
                    MessageBox.Show("name vaya catogeri Id vaya unit price boş olmaz");
                }
                else
                {
                    string message = "Do you want to Delete product ? ";
                    string title = "Product Delete";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result1 = MessageBox.Show(message, title, buttons);
                    if (result1 == DialogResult.Yes)
                    {
                        if (checkDiscontinued.Checked)
                        {
                            chekDiscontinue = true;
                        }
                        var result = product1.Delete(new Product
                        {
                            Id = Convert.ToInt32(txtId.Text),
                            ProductName = txtName.Text,
                            CategoryId = Convert.ToInt32(txtCatogeriId.Text),
                            UnitPrice = Convert.ToInt32(txtUnitPrice.Text),
                            Discontinued = chekDiscontinue
                        });
                        ClearTxt();
                        GetAllDataGirdview();
                        MessageBox.Show(result.Message + " " + result.Success);
                    }
                }
        }

        //button select
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtId.Text = row.Cells["ProductID"].Value.ToString();
                txtCatogeriId.Text = row.Cells["CateGoryID"].Value.ToString();
                txtName.Text = row.Cells["ProductName"].Value.ToString();
                txtUnitPrice.Text = row.Cells["UnitPrice"].Value.ToString();
                if (row.Cells["Discontinued"].Value.ToString()=="True"){ checkDiscontinued.Checked = true;}
                else{checkDiscontinued.Checked =false;}
            }
        }

        // form load
        private void Form1_Load(object sender, EventArgs e)
        {
           GetAllDataGirdview();
        }
        private void GetAllDataGirdview()
        {
            dataGridView1.Rows.Clear();
            ProductManager product1 = new ProductManager(new EfProductDal());
            int n = 0;
            foreach (var product in product1.GetAll().Data)
            {
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = product.Id;
                dataGridView1.Rows[n].Cells[1].Value = product.CategoryId;
                dataGridView1.Rows[n].Cells[2].Value = product.ProductName;
                dataGridView1.Rows[n].Cells[3].Value = product.UnitPrice;
                dataGridView1.Rows[n].Cells[4].Value = product.Discontinued;
            }
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        //text boxs Clear
        private void ClearTxt()
        {
            txtId.Clear();
            txtName.Clear();
            txtCatogeriId.Clear();
            txtUnitPrice.Clear();
            checkDiscontinued.Checked = false; 
        }
        private void checkDiscontinued_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtId.Text, "[^0-9]") || System.Text.RegularExpressions.Regex.IsMatch(txtId.Text, ","))
            {
                MessageBox.Show("Lütfen yalnızca rakam girin.");
                txtId.Text = txtId.Text.Remove(txtId.Text.Length - 1);
            }
        }

        private void txtCatogeriId_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtCatogeriId.Text, "[^0-9]"))
            {
                MessageBox.Show("Lütfen yalnızca rakam girin.");
                txtCatogeriId.Text = txtCatogeriId.Text.Remove(txtCatogeriId.Text.Length - 1);
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtUnitPrice.Text, "[^0-9]"))
            {
                MessageBox.Show("Lütfen yalnızca rakam girin.");
                txtUnitPrice.Text = txtUnitPrice.Text.Remove(txtUnitPrice.Text.Length - 1);
            }
        }
    }
}
