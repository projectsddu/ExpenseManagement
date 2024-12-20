﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewExpense.aspx.cs" Inherits="ExpenseManagementClient.Expense.ViewExpense2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Expense</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body>
    <!--#include file="~/static/Components/SharedNavbar.html"-->

    <table class="table container mt-4">
        <thead>
            <tr>
                <th scope="col" class='text-center'>Expense Number</th>
                <th scope="col" class='text-center'>Expense Description</th>
                <th scope="col" class='text-center'>Expense Date</th>
                <th scope="col" class='text-center'>Expense Amount</th>
                <th scope="col" class='text-center'>Update Expense</th>
                <th scope="col" class='text-center'>Delete Expense</th>
            </tr>
        </thead>
        <tbody>
            <%

                for (int i = 0; i < expenses.Length; i++)
                {
                    Response.Write("<tr>" +
                        "<th class='text-center'>"+ (i + 1).ToString()+"</th>"+
                        "<td class='text-center'>"+expenses[i].ExpenseDescription.ToString()+"</td>"+
                        "<td class='text-center'>"+expenses[i].ExpenseDate.ToString()+"</td>"+
                        "<td class='text-center'>"+expenses[i].ExpenseAmount.ToString()+"</td>"+
                        "<td class='text-center'><a href='/Expense/UpdateExpense.aspx/?id=" + expenses[i].ExpenseId.ToString() + "'><button class='btn btn-primary'>Update</button></a></td>"+
                        "<td class='text-center'><a href='/Expense/DeleteExpense.aspx/?id=" + expenses[i].ExpenseId.ToString() + "'><button class='btn btn-danger'>Delete</button></a></td>"
                        );
                }

            %>
                    </tbody>
    </table>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>
