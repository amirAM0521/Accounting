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
using ValidationComponents;
using Acconting = Accounting.DataLayer.Acconting;

namespace Accounting.App
{
    public partial class FrmCustomerTransaction : Form
    {
        private UnitOfWork db;
        public int AccountID = 0;
        public FrmCustomerTransaction()
        {
            InitializeComponent();
        }

        private void FrmCustomerTransaction_Load(object sender, EventArgs e)
        {
            db = new UnitOfWork();
            dgCustomerName.AutoGenerateColumns = false;
            dgCustomerName.DataSource = db.CustomerRepository.GetNameCustomer();
            if (AccountID != 0)
            {
                var account = db.AccontingRepository.GetById(AccountID);
                txtAmount.Text = account.Amount.ToString();
                txtDescription.Text = account.Description;
                txtName.Text = db.CustomerRepository.GetCustomerNameById(account.ID);
                if (account.TypeID == 1)
                {
                    rbRecive.Checked = true;
                }
                else
                {
                    rbPey.Checked = true;
                }

                this.Text = "ویرایش";
                btnSave.Text = "ویرایش";
                db.Dispose();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dgCustomerName.AutoGenerateColumns = false;
            dgCustomerName.DataSource = db.CustomerRepository.GetNameCustomer(txtfilter.Text);
        }

        private void dgCustomerName_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dgCustomerName.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (BaseValidator.IsFormValid(this.components))
            {
                if (rbPey.Checked || rbRecive.Checked)
                {
                    db = new UnitOfWork();
                    DataLayer.Acconting accounting = new DataLayer.Acconting()
                    {
                        Amount = int.Parse(txtAmount.Value.ToString()),
                        //ID = db.CustomerRepository.GetCustomerIdByName(txtName.Text),

                        TypeID = (rbRecive.Checked) ? 1 : 2,
                        DateTitle = DateTime.Now,
                        Description = txtDescription.Text

                    };
                    if (AccountID == 0)
                    {
                        db.AccontingRepository.Insert(accounting);
                        db.Save();
                    }
                    else
                    {
                        accounting.ID = AccountID;
                        db.AccontingRepository.Update(accounting);

                    }
                    db.Save();
                    db.Dispose();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    RtlMessageBox.Show("لطفا نوع تراکنش را انتخاب کنید");
                }
            }
        }
    }
}