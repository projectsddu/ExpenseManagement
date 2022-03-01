using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpenseManagementClient.Expense
{
    public partial class UpdateExpense : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            ExpenseServiceReference.ExpenseServiceClient client = new ExpenseServiceReference.ExpenseServiceClient();

            id = Convert.ToInt32(Request.QueryString["id"]);

            ExpenseServiceReference.ExpenseModel expense = client.ViewSingleExpense(id);

            textBoxExpenseDesc.Text = expense.ExpenseDescription;
            textBoxExpenseDate.Text = expense.ExpenseDate.ToString("yyyy-MM-dd");
            textBoxExpenseAmt.Text = expense.ExpenseAmount.ToString();

        }

        protected void buttonUpdateExpense_Click(object sender, EventArgs e)
        {
            ExpenseServiceReference.ExpenseServiceClient client = new ExpenseServiceReference.ExpenseServiceClient();

            id = Convert.ToInt32(Request.QueryString["id"]);

            Debug.WriteLine(textBoxExpenseDesc.Text);
            Debug.WriteLine(textBoxExpenseDate.Text);
            Debug.WriteLine(textBoxExpenseAmt.Text);

            //string expenseDescription = /*textBoxExpenseDesc.Text*/;
            string expenseDescription = "keval";

            DateTime expenseDate = Convert.ToDateTime(textBoxExpenseDate.Text);

            float expenseAmount = float.Parse(textBoxExpenseAmt.Text);

            ExpenseServiceReference.ExpenseModel expense = new ExpenseServiceReference.ExpenseModel()
            {
                ExpenseId = id,
                ExpenseDescription = expenseDescription,
                ExpenseDate = expenseDate,
                ExpenseAmount = expenseAmount,
                ExpenseUserId = 1
            };

            ExpenseServiceReference.ExpenseModel newE = client.UpdateExpense(expense);

            Debug.WriteLine(newE.ExpenseId);
            Debug.WriteLine(newE.ExpenseDescription);
            Debug.WriteLine(newE.ExpenseDate);
            Debug.WriteLine(newE.ExpenseAmount);
            Debug.WriteLine(newE.ExpenseUserId);
        }
    }
}