using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpenseManagementClient.Expense
{
    public partial class DeleteExpense : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void No_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Expense/ViewExpense.aspx");
        }

        protected void Yes_Click(object sender, EventArgs e)
        {
            ExpenseServiceReference.ExpenseServiceClient client = new ExpenseServiceReference.ExpenseServiceClient();

            id = Convert.ToInt32(Request.QueryString["id"]);

            Boolean status = client.DeleteExpense(id);

            if(status)
            {
                Response.Redirect("/Expense/ViewExpense.aspx");
            }

            Debug.WriteLine(status);
        }
    }
}