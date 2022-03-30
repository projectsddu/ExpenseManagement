using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpenseManagementClient.Expense
{
    public partial class AddExpense1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonAddExpense_Click(object sender, EventArgs e)
        {

            ExpenseServiceReference.ExpenseServiceClient client = new ExpenseServiceReference.ExpenseServiceClient();

            string description = textBoxExpenseDesc.Text;

            DateTime expenseDate = Convert.ToDateTime(textBoxExpenseDate.Text);
            float expenseAmount = float.Parse(textBoxExpenseAmt.Text);

            int userId = int.Parse(Request.Cookies["UserId"].Value.ToString());
            ExpenseServiceReference.ExpenseModel expense = new ExpenseServiceReference.ExpenseModel()
            {
                ExpenseDescription = description,
                ExpenseAmount = expenseAmount,
                ExpenseDate = expenseDate,
                ExpenseUserId = userId
            };

            ExpenseServiceReference.ExpenseModel returedExpense = client.AddExpense(expense);

            if(returedExpense.ExpenseId == -1)
            {
                ViewState["message"] = "Error! While adding expense!";
                ViewState["status"] = "danger";
            }
            else
            {
                ViewState["message"] = "Expense added successfully!";
                ViewState["status"] = "success";
            }
        }
    }
}