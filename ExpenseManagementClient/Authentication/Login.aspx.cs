using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpenseManagementClient.Authentication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonAddExpense_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            UserServiceReference.UserServiceClient Client= new UserServiceReference.UserServiceClient();
            
            if(username==""||password=="")
            {
                ViewState["message"] = "All fields are required!";
                ViewState["status"] = "danger";
            }
            else
            {
                int status = Client.LoginUser(username, password);
                Debug.WriteLine("Here in service");
                Debug.WriteLine(status);
                if(status != -1)
                {
                    Response.Cookies["UserName"].Value = username.ToString();
                    Response.Cookies["UserId"].Value = status.ToString();
                    Response.Redirect("/Home/Home.aspx");
                }
                else
                {
                    ViewState["message"] = "Wrong username or password!";
                    ViewState["status"] = "danger";
                }
            }

        }
    }
}