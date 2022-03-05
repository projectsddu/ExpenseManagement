using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpenseManagementClient.Payment
{
    public partial class DeletePayment : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Yes_Click(object sender, EventArgs e)
        {
            PaymentServiceReference.PaymentServiceClient client = new PaymentServiceReference.PaymentServiceClient();

            id = Convert.ToInt32(Request.QueryString["id"]);

            Boolean status = client.DeletePayment(id);

            if (status)
            {
                Response.Redirect("/Payment/ViewPayment.aspx");
            }

            Debug.WriteLine(status);
        }

        protected void No_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Payment/ViewPayment.aspx");
        }
    }
}