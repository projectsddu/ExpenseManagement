using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpenseManagementClient.Home
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Request.Cookies["UserName"].Value.ToString();
            ViewState["UserName"] = username;

            // fetch user
            UserServiceReference.UserServiceClient client = new UserServiceReference.UserServiceClient();

            int userId = int.Parse(Request.Cookies["UserId"].Value.ToString());

            UserServiceReference.UserModel user = client.GetUser(userId);

            ViewState["Credit"] = user.UserCredit;
            ViewState["Debit"] = user.UserDebit;
        }
    }
}