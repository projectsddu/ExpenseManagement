using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpenseManagementClient.Payment
{
    public partial class UpdatePayment : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PaymentServiceReference.PaymentServiceClient client = new PaymentServiceReference.PaymentServiceClient();

                id = Convert.ToInt32(Request.QueryString["id"]);

                PaymentServiceReference.PaymentModel payment = client.ViewSinglePayment(id);

                textBoxPaymentDesc.Text = payment.PaymentDescription;
                textBoxPaymentDate.Text = payment.PaymentDate.ToString("yyyy-MM-dd");
                textBoxPaymentAmt.Text = payment.PaymentAmount.ToString();
                textBoxPaymentReceiver.Text = payment.PaymentToUser;
            }
        }

        protected void buttonUpdatePayment_Click(object sender, EventArgs e)
        {
            PaymentServiceReference.PaymentServiceClient client = new PaymentServiceReference.PaymentServiceClient();

            id = Convert.ToInt32(Request.QueryString["id"]);

            string paymentDescription = textBoxPaymentDesc.Text;
            //DateTime paymentDate = Convert.ToDateTime(textBoxPaymentDate.Text);
            //float paymentAmount = float.Parse(textBoxPaymentAmt.Text);
            //string paymentToUser = textBoxPaymentReceiver.Text;

            int userId = int.Parse(Request.Cookies["UserId"].Value.ToString());

            PaymentServiceReference.PaymentModel payment = new PaymentServiceReference.PaymentModel()
            {
                PaymentId = id,
                PaymentDescription = paymentDescription,
                //PaymentDate = paymentDate,
                //PaymentAmount = paymentAmount,
                PaymentFromUser = userId.ToString(),
                //PaymentToUser = paymentToUser
            };

            PaymentServiceReference.PaymentModel newP = client.UpdatePayment(payment);

            if(newP.PaymentId == -1)
            {
                ViewState["message"] = "Error! While updating payment!";
                ViewState["status"] = "danger";
            }
            else
            {
                ViewState["message"] = "Payment updated successfully!";
                ViewState["status"] = "success";
            }

            Debug.WriteLine(newP.PaymentId);
            Debug.WriteLine(newP.PaymentDescription);
        }
    }
}