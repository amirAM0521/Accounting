using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.DataLayer.Context;

namespace Accounting.App
{
    public partial class FrmCustomers : Form
    {
        public FrmCustomers()
        {
            InitializeComponent();
        }

        void BaidGrid()
        {
            //using (UnitOfWork db = new UnitOfWork()) 
            //{
            //    dgCustomers.AutoGenerateColumns = false;
            //    dgCustomers.DataSource = db.CustomerRepository.GetAllCustomers();
            //}
            using (UnitOfWork db = new UnitOfWork())
            {
                dgCustomers.AutoGenerateColumns = false;
                dgCustomers.DataSource = db.CustomerRepository.GetAllCustomers();
            }
        }
        private void FrmCustomers_Load(object sender, EventArgs e)
        {
            BaidGrid();
        }

        private void btnRefreshCustomers_Click(object sender, EventArgs e)
        {
            txtbox.Text = "";
            BaidGrid();
        }

        private void txtbox_Click(object sender, EventArgs e)
        {

        }

        private void txtbox_TextChanged(object sender, EventArgs e)
        {
            //using (UnitOfWork db = new UnitOfWork())
            //{
            //    dgCustomers.DataSource = db.CustomerRepository.GetCustomersByFilter(txtbox.Text);
            //}
            using (UnitOfWork db = new UnitOfWork())
            {
                dgCustomers.DataSource = db.CustomerRepository.GetCustomersByFilter(txtbox.Text);
            }
        }

        private void btnDeleteCustomers_Click(object sender, EventArgs e)
        {
            //if (dgCustomers.CurrentRow != null)
            //{
            //    using (UnitOfWork db = new UnitOfWork())
            //    {
            //        string name = dgCustomers.CurrentRow.Cells[1].Value.ToString();
            //        if (RtlMessageBox.Show($"آیا از حذف {name} مطمئن هستید ؟", "توجه", MessageBoxButtons.YesNo,
            //                MessageBoxIcon.Warning) == DialogResult.Yes)
            //        {
            //            int ID = int.Parse(dgCustomers.CurrentRow.Cells[0].Value.ToString());
            //            db.CustomerRepository.DeleteCustomer(ID);
            //            db.Save();
            //            BaidGrid();
            //        }
            //    }
            //}
            //else
            //{
            //    RtlMessageBox.Show("لطفا شخصی را انتخاب کنید");
            //}
            if (dgCustomers.CurrentRow != null)
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    string name = dgCustomers.CurrentRow.Cells[1].Value.ToString();
                    if (RtlMessageBox.Show($"آیا از حذف {name} مطمئن هستید ؟", "توجه", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int customerId = int.Parse(dgCustomers.CurrentRow.Cells[0].Value.ToString());
                        db.CustomerRepository.DeleteCustomer(customerId);
                        db.Save();
                        BaidGrid();
                    }
                }
            }
            else
            {
                RtlMessageBox.Show("لطفا شخصی را انتخاب کنید");
            }
        }

        private void btnAddCustomers_Click(object sender, EventArgs e)
        {
            //FrmCustomerAddOrEdit frmAdd = new FrmCustomerAddOrEdit();

            //if (frmAdd.ShowDialog() == DialogResult.OK)
            //{
            //    BaidGrid();
            //}
            FrmCustomerAddOrEdit frmAdd = new FrmCustomerAddOrEdit();
            if (frmAdd.ShowDialog() == DialogResult.OK)
            {
                BaidGrid();
            }

        }

        private void btnEditCustomers_Click(object sender, EventArgs e)
        {
            //if (dgCustomers.CurrentRow != null)
            //{

            //    int Id = int.Parse(dgCustomers.CurrentRow.Cells[0].Value.ToString());
            //    FrmCustomerAddOrEdit frmAddOrEdit = new FrmCustomerAddOrEdit();
            //    frmAddOrEdit.Id = Id;
            //    if (frmAddOrEdit.ShowDialog() == DialogResult.OK)
            //    {
            //        BaidGrid();
            //    }
            //}
            if (dgCustomers.CurrentRow != null)
            {
                int customerId = int.Parse(dgCustomers.CurrentRow.Cells[0].Value.ToString());
                FrmCustomerAddOrEdit frmAddOrEdit = new FrmCustomerAddOrEdit();
                frmAddOrEdit.Id = customerId;
                if (frmAddOrEdit.ShowDialog() == DialogResult.OK)
                {
                    BaidGrid();
                }
            }
            else
            {
                RtlMessageBox.Show("لطفا شخصی را انتخاب کنید");
            }
        }
    }
}