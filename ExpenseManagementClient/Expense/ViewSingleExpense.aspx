<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSingleExpense.aspx.cs" Inherits="ExpenseManagementClient.Expense.ViewSingleExpense" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 713px;
            width: 1319px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:TextBox ID="TextBoxID" runat="server" Height="92px" Width="508px"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="ButtonViewExpense" runat="server" Height="66px" OnClick="ButtonViewExpense_Click" Text="View Expense" Width="453px" />
            <br />
            <br />
            <br />
            <asp:Label ID="LabelDesc" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="LabelAmount" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="LabelDate" runat="server"></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
