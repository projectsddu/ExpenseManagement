<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ExpenseManagementClient.Authentication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>

</head>
<body>
    <!--#include file="~/static/Components/LoginNavbar.html"-->
    <% 
        if (ViewState["message"] != null)
        {
            Response.Write("<div class='alert alert-" + ViewState["status"] + " alert-dismissible fade show' role='alert'><strong>" + ViewState["message"] + "</strong> <button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>");
        }
    %>
    <h1  class="container mt-2">Login</h1>
    <form id="form1" class="container mt-4" runat="server">
        <div>
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label"><b>Username</b></label>
            <%--<input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp"/>--%>
            <asp:TextBox class="form-control" ID="textBoxUsername" aria-describedby="expenseDesc" runat="server"></asp:TextBox>
            <div id="expenseDesc" class="form-text">Enter your username.</div>
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label"><b>Password</b></label>
            <%--<input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp"/>--%>
            <asp:TextBox class="form-control" ID="textBoxPassword" type="password" aria-describedby="expenseDesc" runat="server"></asp:TextBox>
            <div id="password" class="form-text">Enter your password.</div>
        </div>
              <asp:Button ID="buttonLogin" type="submit" class="btn btn-success"  runat="server" Text="Login" OnClick="buttonAddExpense_Click" />
    </form>
     <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>

</body>
</html>
