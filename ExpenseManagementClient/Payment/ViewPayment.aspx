<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPayment.aspx.cs" Inherits="ExpenseManagementClient.Payment.ViewPayment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Payment</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body>
    <!--#include file="~/static/Components/SharedNavbar.html"-->

    <table class="table container mt-4">
        <thead>
            <tr>
                <th scope="col" class='text-center'>Payment Number</th>
                <th scope="col" class='text-center'>Payment Description</th>
                <th scope="col" class='text-center'>Payment Date</th>
                <th scope="col" class='text-center'>Payment Amount</th>
                <th scope="col" class='text-center'>Payment Sender</th>
                <th scope="col" class='text-center'>Payment Receiver</th>
                <th scope="col" class='text-center'>Update Payment</th>
                <th scope="col" class='text-center'>Delete Payment</th>
            </tr>
        </thead>
        <tbody>
            <%

                for (int i = 0; i < payments.Length; i++)
                {
                    Response.Write("<tr>" +
                        "<th class='text-center'>"+ (i + 1).ToString()+"</th>"+
                        "<td class='text-center'>"+payments[i].PaymentDescription.ToString()+"</td>"+
                        "<td class='text-center'>"+payments[i].PaymentDate.ToString()+"</td>"+
                        "<td class='text-center'>"+payments[i].PaymentAmount.ToString()+"</td>"+
                        "<td class='text-center'>"+payments[i].PaymentFromUser.ToString()+"</td>"+
                        "<td class='text-center'>"+payments[i].PaymentToUser.ToString()+"</td>"+
                        "<td class='text-center'><a href='/Payment/UpdatePayment.aspx/?id=" + payments[i].PaymentId.ToString() + "'><button class='btn btn-primary'>Update</button></a></td>"+
                        "<td class='text-center'><a href='/Payment/DeletePayment.aspx/?id=" + payments[i].PaymentId.ToString() + "'><button class='btn btn-danger'>Delete</button></a></td>"
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
