<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteExpense.aspx.cs" Inherits="ExpenseManagementClient.Expense.DeleteExpense" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Expense</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body>
    <!--#include file="~/static/Components/SharedNavbar.html"-->
    <% 
        if (ViewState["message"] != null)
        {
            Response.Write("<div class='alert alert-" + ViewState["status"] + " alert-dismissible fade show' role='alert'><strong>" + ViewState["message"] + "</strong> <button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>");
        }
    %>
    <form id="form1" class="container mt-4" runat="server">
        <div class="alert alert-light" role="alert">
            <h3 class="alert-heading" style="color:black">Are you sure you want to delete this expense?</h3>
            <div class="row" style="margin-top:2%">
                <div class="col-2">

                    <asp:Button style="width:50%" ID="Yes" runat="server" Text="Confirm" class="btn btn-danger" OnClick="Yes_Click" />
                </div>
                <div class="col-2">
                    <asp:Button ID="No" style="width:50%" runat="server" Text="Cancel" class="btn btn-success" OnClick="No_Click" />
                </div>
            </div>
            
            <p class="mb-0"></p>
        </div>
    </form>


    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>
