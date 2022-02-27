<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewExpense.aspx.cs" Inherits="ExpenseManagementClient.Expense.ViewExpense" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="ButtonViewAllExpense" runat="server" Height="78px" OnClick="ButtonViewAllExpense_Click" Text="View All Expenses" Width="356px" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:GridView ID="GridViewExpenses" runat="server">
            </asp:GridView>
            <br />
        </div>
    </form>
</body>
</html>
