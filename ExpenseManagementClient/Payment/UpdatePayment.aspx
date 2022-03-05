<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePayment.aspx.cs" Inherits="ExpenseManagementClient.Payment.UpdatePayment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Payment</title>
    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body>
    <!--#include file="~/static/Components/SharedNavbar.html"-->
    <form id="form1" class="container mt-4" runat="server">
        <div class="mb-3">
            <label for="payementDescription" class="form-label"><b>Payment Description</b></label>
            <%--<input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp"/>--%>
            <asp:TextBox class="form-control" ID="textBoxPaymentDesc" aria-describedby="expenseDesc" runat="server"></asp:TextBox>
            <div id="paymentDesc" class="form-text">Enter the payment description.</div>
        </div>
        <div class="mb-3">
            <label for="paymentDate" class="form-label"><b>Payment Date</b></label>
            <%--<input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp"/>--%>
            <asp:TextBox class="form-control" type="date" ID="textBoxPaymentDate" aria-describedby="expenseDate" runat="server"></asp:TextBox>
            <div id="paymentDate" class="form-text">Enter the payment date</div>
        </div>
        <div class="mb-3">
            <label for="exampleInputPaymentAmount" class="form-label"><b>Payment Amount</b></label>
            <%--<input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp"/>--%>
            <asp:TextBox class="form-control" type="number" ID="textBoxPaymentAmt" aria-describedby="expenseAmt" runat="server"></asp:TextBox>
            <div id="paymentAmt" class="form-text">
                Enter the payment amount
            </div>
        </div>
        
        <div class="mb-3">
            <label for="paymentToUser" class="form-label"><b>Payment Receiver</b></label>
            <%--<input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp"/>--%>
            <asp:TextBox class="form-control" ID="textBoxPaymentReceiver" aria-describedby="expenseDesc" runat="server"></asp:TextBox>
            <div id="paymentToUser" class="form-text">Enter the payment receiver.</div>
        </div>

        <asp:Button ID="buttonUpdatePayment" type="submit" class="btn btn-success mb-4"  runat="server" Text="Update Payment" OnClick="buttonUpdatePayment_Click" />
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>
