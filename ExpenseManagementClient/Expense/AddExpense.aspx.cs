using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpenseManagementClient.Expense
{
    public partial class AddExpense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAddExpense_Click(object sender, EventArgs e)
        {
            ExpenseServiceReference.ExpenseServiceClient client = new ExpenseServiceReference.ExpenseServiceClient();

            string description = TextBoxExpenseDesc.Text;

            DateTime expenseDate = Convert.ToDateTime(TextBoxExpenseDate.Text);

            float expenseAmount = float.Parse(TextBoxExpenseAmount.Text);

            ExpenseServiceReference.ExpenseModel expense = new ExpenseServiceReference.ExpenseModel()
            {
                ExpenseDescription = description,
                ExpenseAmount = expenseAmount,
                ExpenseDate = expenseDate

            };

            client.AddExpense(expense);

        }
    }
}