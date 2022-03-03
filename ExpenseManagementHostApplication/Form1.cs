using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseManagementHostApplication
{
    public partial class Form1 : Form
    {
        ServiceHost sh1 = null;
        ServiceHost sh2 = null;
        ServiceHost sh3 = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                sh1 = new ServiceHost(typeof(ExpenseManagement.UserServiceClass));
                sh2 = new ServiceHost(typeof(ExpenseManagement.ExpenseServiceClass));
                sh3 = new ServiceHost(typeof(ExpenseManagement.PaymentServiceClass));
                sh1.Open();
                sh2.Open();
                sh3.Open();
                labelServiceRunning.Text = "Service running!!";
            }
            catch(Exception error)
            {
                labelServiceRunning.Text = "Error in service running!!! " + error.Message;
            }
            
        }
        public Form1()
        {
            InitializeComponent();
        }

    }
}
