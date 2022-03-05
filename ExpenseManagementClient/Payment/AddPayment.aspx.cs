using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpenseManagementClient.Payment
{
    public partial class AddPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonAddPayment_Click(object sender, EventArgs e)
        {
            PaymentServiceReference.PaymentServiceClient client = new PaymentServiceReference.PaymentServiceClient();

            string paymentDescription = textBoxPaymentDesc.Text;
            DateTime paymentDate = Convert.ToDateTime(textBoxPaymentDate.Text);
            float paymentAmount = float.Parse(textBoxPaymentAmt.Text);
            string paymentToUser = textBoxPaymentReceiver.Text;

            PaymentServiceReference.PaymentModel payment = new PaymentServiceReference.PaymentModel()
            {
                PaymentDescription = paymentDescription,
                PaymentDate = paymentDate,
                PaymentAmount = paymentAmount,
                PaymentToUser = paymentToUser
            };

            client.AddPayment(payment);
        }
    }
}