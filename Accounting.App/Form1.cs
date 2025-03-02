using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.App.Transaction;

namespace Accounting.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmCustomers FrmCustomers = new FrmCustomers();
            FrmCustomers.ShowDialog();
        }

        private void btnNewTransaction_Click(object sender, EventArgs e)
        {
            FrmCustomerTransaction frmTransaction = new FrmCustomerTransaction();
            frmTransaction.ShowDialog();
        }

        private void btnReportPay_Click(object sender, EventArgs e)
        {
            FrmReport frmReport = new FrmReport();
            frmReport.TypeID = 2;
            frmReport.ShowDialog();
        }

        private void btnReportRecive_Click(object sender, EventArgs e)
        {
            FrmReport frmReport = new FrmReport();
            frmReport.TypeID = 1;
            frmReport.ShowDialog();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
