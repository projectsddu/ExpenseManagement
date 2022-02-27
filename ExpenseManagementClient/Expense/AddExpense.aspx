<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddExpense.aspx.cs" Inherits="ExpenseManagementClient.Expense.AddExpense" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 274px;
        }
    </style>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />

</head>
<body>

    <!--#include file="~/static/Components/SharedNavbar.html"-->
    <form id="form1" runat="server" class="container mt-3">
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Description</label>
            <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp"/>
        </div>
        <div class="mb-3">
            <label for="exampleInputPassword1" class="form-label">Date and Time</label>
            <input type="datetime-local" class="form-control" id="exampleInputPassword1"/>
        </div>
        <div class="mb-3">
            <label for="exampleInputPassword1" class="form-label">Amount</label>
            <input type="number" class="form-control" id="exampleInputPassword2"/>
        </div>
       
        <button type="submit" class="btn btn-primary">Submit</button>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>

</body>
</html>
