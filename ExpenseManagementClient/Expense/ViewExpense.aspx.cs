using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpenseManagementClient.Expense
{
    public partial class ViewExpense2 : System.Web.UI.Page
    {
        public ExpenseServiceReference.ExpenseModel[] expenses;
        protected void Page_Load(object sender, EventArgs e)
        {
            ExpenseServiceReference.ExpenseServiceClient client = new ExpenseServiceReference.ExpenseServiceClient();
            int userId = int.Parse(Request.Cookies["UserId"].Value.ToString());
            expenses = client.ViewAllExpense(userId);
            //ViewState["expenses"] = expenses;
            //ViewState["expensesLength"]
        }
    }
}