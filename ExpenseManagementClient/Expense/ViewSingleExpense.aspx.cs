using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpenseManagementClient.Expense
{
    public partial class ViewSingleExpense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonViewExpense_Click(object sender, EventArgs e)
        {
            ExpenseServiceReference.ExpenseServiceClient client = new ExpenseServiceReference.ExpenseServiceClient();

            int id = int.Parse(TextBoxID.Text);

            ExpenseServiceReference.ExpenseModel expense = client.ViewSingleExpense(id);

            LabelDesc.Text = expense.ExpenseDescription;
            LabelAmount.Text = expense.ExpenseAmount.ToString();
            LabelDate.Text = expense.ExpenseDate.ToString();
        }
    }
}