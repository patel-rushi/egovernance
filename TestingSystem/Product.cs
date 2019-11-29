using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingSystems
{
    public partial class Product : Form
    {
        public Int32 FullScreenOff = 0;
        Guid ProductId;
        public Product()
        {
            InitializeComponent();
            Search();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Product.Text != String.Empty)
                {
                    if (btn_Add.Text == "Add")
                    {
                        ProductDataBase productdb = new ProductDataBase();
                        productdb.ProductName = txt_Product.Text.ToString();
                        if (productdb.Insert_Product() == 1)
                        {
                            MessageBox.Show("Added");
                        }
                    }
                    else if (btn_Add.Text == "Update")
                    {
                        ProductDataBase productdb = new ProductDataBase();
                        productdb.ProductName = txt_Product.Text.ToString();
                        productdb.ProductId = ProductId;
                        if (productdb.Update_Product() == 1)
                        {
                            MessageBox.Show("Updated");
                            Search();

                        }
                    }
                    Clear();

                }
                else
                {
                    MessageBox.Show("Enter Product Name. ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            txt_Product.Text = string.Empty;
            btn_Add.Text = "Add";
            Search();
        }

        private void dgv_CommMethod_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {

                    dgv_Product.AutoGenerateColumns = false;
                    dgv_Product.Rows[e.RowIndex].Selected = true;
                    if (dgv_Product.SelectedCells.Count > 0)
                    {
                        DataGridViewRow selectrow = dgv_Product.Rows[e.RowIndex];
                        ProductId = Guid.Parse(selectrow.Cells["_ProductId"].Value.ToString());

                        if (dgv_Product.Columns[e.ColumnIndex].HeaderText == "Edit")
                        {
                            // if (MessageBox.Show(Helper.MessageBoxMessages.Updateconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                btn_Add.Text = "Update";
                                FillUpdates(ProductId);

                            }

                        }
                        else if (dgv_Product.Columns[e.ColumnIndex].HeaderText == "Delete")
                        {
                            if (MessageBox.Show(Helper.MessageBoxMessages.DeleteConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                ProductDataBase productdb = new ProductDataBase();
                                productdb.ProductId = ProductId;
                                if (productdb.Delete_Product() == 1)
                                {
                                    const string type = "Deleted";
                                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);

                                    Clear();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message + ex.StackTrace); }
        }
        private void FillUpdates(Guid p_ProductId)
        {
            try
            {
                ProductDataBase productdb = new ProductDataBase();
                productdb.ProductId = p_ProductId;
                DataTable dt = productdb.Search_Product();
                if (dt.Rows.Count > 0)
                {
                    txt_Product.Text = dt.Rows[0][1].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }
        private void Search()
        {
            try
            {
                ProductDataBase productdb = new ProductDataBase();
                DataTable dt = productdb.Search_Product();
                dgv_Product.DataSource = null;
                dgv_Product.AutoGenerateColumns = false;
                dgv_Product.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }
    }
}
