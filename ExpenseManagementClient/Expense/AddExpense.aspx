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
            width: 290px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2"><strong>Expense Description:</strong></td>
                    <td>
                        <asp:TextBox type="text" ID="TextBoxExpenseDesc" runat="server" Height="41px" Width="863px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"><strong></strong></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"><strong>Expense Date:</strong></td>
                    <td>
                        <asp:TextBox type="date" ID="TextBoxExpenseDate" runat="server" Height="41px" Width="863px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"><strong></strong></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"><strong>Expense Amount:</strong></td>
                    <td>
                        <asp:TextBox type="number" ID="TextBoxExpenseAmount" runat="server" Height="41px" Width="863px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"><strong></strong></td>
                    <td>&nbsp;</td>
                </tr>
                <%--<tr>
                    <td class="auto-style2"><strong>Expense User Name:</strong></td>
                    <td>
                        <asp:TextBox ID="TextBoxUserName" runat="server" Height="41px" Width="863px"></asp:TextBox>
                    </td>
                </tr>--%>
                <tr>
                    <td class="auto-style2"><strong></strong></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"><strong></strong></td>
                    <td>
                        <asp:Button ID="ButtonAddExpense" runat="server" OnClick="ButtonAddExpense_Click" Text="Add Expense" Width="191px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"><strong></strong></td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
