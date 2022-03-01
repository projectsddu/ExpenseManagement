<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateExpense.aspx.cs" Inherits="ExpenseManagementClient.Expense.UpdateExpense" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Expense</title>
    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body>
    <!--#include file="~/static/Components/SharedNavbar.html"-->
    <form id="form1" class="container mt-4" runat="server">
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Expense Description</label>
            <asp:TextBox class="form-control" ID="textBoxExpenseDesc" aria-describedby="expenseDesc" runat="server"></asp:TextBox>
            <div id="expenseDesc" class="form-text">Enter the expense description.</div>
        </div>




        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Expense date</label>
            <%--<input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp"/>--%>
            <asp:TextBox class="form-control" type="date" ID="textBoxExpenseDate" aria-describedby="expenseDate" runat="server"></asp:TextBox>
            <div id="expenseDate" class="form-text">Enter the expense date</div>
        </div>


        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Expense amount</label>
            <%--<input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp"/>--%>
            <asp:TextBox class="form-control" type="number" ID="textBoxExpenseAmt" aria-describedby="expenseAmt" runat="server"></asp:TextBox>
            <div id="expenseAmt" class="form-text">
                Enter the expense amount
            </div>
        </div>

        <asp:Button ID="buttonUpdateExpense" type="submit" class="btn btn-success"  runat="server" Text="Update Expense" OnClick="buttonUpdateExpense_Click"/>

        <div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>
