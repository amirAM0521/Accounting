using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.DataLayer;
using Accounting.DataLayer.Context;
using ValidationComponents;

namespace Accounting.App
{
    public partial class FrmCustomerAddOrEdit : Form
    {
        public int Id = 0;

        UnitOfWork db = new UnitOfWork();
        public FrmCustomerAddOrEdit()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork())
            {

                //    if (BaseValidator.IsFormValid(this.components))
                //    {
                //        string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(pcCustomers.ImageLocation);

                //        string path = Application.StartupPath + "/Images/";

                //        if (!Directory.Exists(path))
                //        {
                //            Directory.CreateDirectory(path);
                //        }

                //        pcCustomers.Image.Save(path + ImageName);

                //        Customers customers = new Customers()
                //        {
                //            FullName = txtName.Text,
                //            Mobile = txtMobile.Text,
                //            Adress = txtAddress.Text,
                //            Email = txtEmail.Text,
                //            Image = ImageName
                //        };
                //        if (Id == 0)
                //        {
                //            db.CustomerRepository.InsertCustomer(customers);
                //        }
                //        else
                //        {
                //            customers.ID = Id;
                //            db.CustomerRepository.UpdateCustomer(customers);
                //        }

                //        db.Save();
                //        DialogResult = DialogResult.OK;
                //    }
                //}

                if (BaseValidator.IsFormValid(this.components))
                {
                    string imageName = Guid.NewGuid().ToString() + Path.GetExtension(pcCustomers.ImageLocation);
                    string path = Application.StartupPath + "/Images/";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    pcCustomers.Image.Save(path + imageName);
                    Customers customers = new Customers()
                    {
                        Adress = txtAddress.Text,
                        Email = txtEmail.Text,
                        FullName = txtName.Text,
                        Mobile = txtMobile.Text,
                        Image = imageName
                    };
                    if (Id == 0)
                    {
                        db.CustomerRepository.InsertCustomer(customers);
                    }
                    else
                    {
                        customers.ID = Id;
                        db.CustomerRepository.UpdateCustomer(customers);
                    }

                    db.Save();
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnSavePhoto_Click(object sender, EventArgs e)
        {
            //OpenFileDialog fileDialog = new OpenFileDialog();
            //if (fileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    pcCustomers.ImageLocation = fileDialog.FileName;
            //}
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                // pcCustomer.ima
                pcCustomers.ImageLocation = openFile.FileName;
            }
        }

        private void FrmCustomerAddOrEdit_Load(object sender, EventArgs e)
        {
            //if (Id != 0)
            //{
            //    this.Text = "ویرایش شخص";
            //    btnSave.Text = "ویرایش";
            //    var customer = db.CustomerRepository.GetCustomerById(Id);
            //    txtName.Text = customer.FullName;
            //    txtMobile.Text = customer.Mobile;
            //    txtEmail.Text = customer.Email;
            //    txtAddress.Text = customer.Adress;
            //    pcCustomers.ImageLocation = Application.StartupPath + "/Images/" + customer.Image;
            //}
            if (Id != 0)
            {
                this.Text = "ویرایش شخص";
                btnSave.Text = "ویرایش";
                var customer = db.CustomerRepository.GetCustomerById(Id);
                txtEmail.Text = customer.Email;
                txtAddress.Text = customer.Adress;
                txtMobile.Text = customer.Mobile;
                txtName.Text = customer.FullName;
                pcCustomers.ImageLocation = Application.StartupPath + "/Images/" + customer.Image;
            }
        }
    }
}
