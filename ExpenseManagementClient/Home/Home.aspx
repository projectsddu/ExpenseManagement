<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ExpenseManagementClient.Home.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <style>
        .bg1 {
            border: 0px;
            /*background-image: linear-gradient(135deg, #ccff00, green);*/
            background-color: #ee5166;
            background-image: linear-gradient(315deg, #ee5166 0%, #f08efc 74%);
            color: white;
        }

        .bg2 {
            border: 0px;
            /*background-image: linear-gradient(135deg, #ccff00, green);*/
            background-color: #045de9;
            background-image: linear-gradient(315deg, #045de9 0%, #09c6f9 74%);
            color: white;
        }

        .bg3 {
            border: 0px;
            /*background-image: linear-gradient(135deg, #ccff00, green);*/
            background-color: #f7b42c;
            background-image: linear-gradient(315deg, #f7b42c 0%, #fc575e 74%);
            color:white;

        }
    </style>
</head>
<body>
    <!--#include file="~/static/Components/SharedNavbar.html"-->
    <form id="form1" class="container mt-4" runat="server">
        <div style="display:flex;justify-content:space-evenly">
        <div class="card bg1" style="width: 100%;margin: 1%;height: 100%;">
            <div class="card-body">
                <h1 class="card-title">Welcome</h1>
                <p class="display-4" style="margin-top:3%">
                    <% Response.Write(ViewState["UserName"].ToString()); %>
                </p>
            </div>
        </div>
        <div class="card bg2" style="width: 100%;margin: 1%;height: 100%;">
            <div class="card-body">
                <h1 class="card-title">Credit</h1>
                <p class="display-4" style="margin-top:3%">₹ <% Response.Write(ViewState["Credit"].ToString()); %></p>
            </div>
        </div>
        <div class="card bg3" style="width: 100%;margin: 1%;height: 100%;">
            <div class="card-body">
                <h1 class="card-title">Debit</h1>
                <p class="display-4" style="margin-top:3%">₹ <% Response.Write(ViewState["Debit"].ToString()); %></p>
            </div>
        </div>
        <!-- <div class="card" style="width: 100%;margin: 1%;">
            <div class="card-body">
                <h5 class="card-title">Card title</h5>
                <h6 class="card-subtitle mb-2 text-muted">Card subtitle</h6>
                <p class="card-text">Some quick example text to build on the card title and make up the bulk of the
                    card's
                    content.</p>
                <a href="#" class="card-link">Card link</a>
                <a href="#" class="card-link">Another link</a>
            </div>
        </div>

        <div class="card" style="width: 100%;margin: 1%;">
            <div class="card-body">
                <h5 class="card-title">Card title</h5>
                <h6 class="card-subtitle mb-2 text-muted">Card subtitle</h6>
                <p class="card-text">Some quick example text to build on the card title and make up the bulk of the
                    card's
                    content.</p>
                <a href="#" class="card-link">Card link</a>
                <a href="#" class="card-link">Another link</a>
            </div>
        </div> -->
    </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>
