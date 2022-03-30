using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpenseManagementClient.Authentication
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonAddExpense_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string email = textBoxEmail.Text;

            if(username==""|| password=="" || email=="")
            {
                ViewState["Error"] = "All fields are required!";
            }
            else
            {
                UserServiceReference.UserServiceClient Client = new UserServiceReference.UserServiceClient();
                UserServiceReference.UserModel userModel = new UserServiceReference.UserModel();
                userModel.UserName = username;
                userModel.UserPassword = password;
                userModel.UserEmail = email;
                userModel.UserCredit = 0;
                userModel.UserDebit = 0;

                string status = Client.AddUser(userModel);
                if(status== "Success")
                {
                    Response.Cookies["UserName"].Value = username.ToString();
                    Response.Cookies["Email"].Value = email.ToString();
                    Response.Redirect("/Expense/AddExpense.aspx");
                }
                else
                {
                    ViewState["Error"] = status;
                }
            }
        }
    }
}