using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpenseManagementClient.Payment
{
    public partial class ViewPayment : System.Web.UI.Page
    {
        public PaymentServiceReference.PaymentModel[] payments;
        protected void Page_Load(object sender, EventArgs e)
        {
            PaymentServiceReference.PaymentServiceClient client = new PaymentServiceReference.PaymentServiceClient();

            int userId = int.Parse(Request.Cookies["UserId"].Value.ToString());
            payments = client.ViewAllPayment(userId);
        }
    }
}