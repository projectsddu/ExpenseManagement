<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ExpenseManagementClient.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/chart.js@3.7.1/dist/chart.min.js"></script>
</head>
<style>
    .card-1 {
        color: white;
        border: 0px solid black;
        background-color: #045de9;
        background-image: linear-gradient(315deg, #045de9 0%, #22acff 74%)
        /*background-color: #0abcf9;

            /*background-image:linear-gradient()*/
    }

    .card-2 {
        color: white;
        border: 0px solid black;
        /*  background-color: #045de9;
            background-image:linear-gradient(315deg, #045de9 0%, #22acff 74%)*/
        background-color: #a40606;
        background-image: linear-gradient(315deg, #ff3b3b 0%, #f0652d 74%)
        /*background-color: #0abcf9;

            /*background-image:linear-gradient()*/
    }

    .card-3 {
        color: white;
        border: 0px solid black;
        background-color: #045de9;
        background-image: linear-gradient(315deg, #045de9 0%, #22acff 74%)
        /*background-color: #0abcf9;

            /*background-image:linear-gradient()*/
    }
</style>
<body>
    <!--#include file="~/static/Components/SharedNavbar.html"-->
    <div class="container">
        <div class="row mt-3" style="display: flex; justify-content: center; width: 100%">
            <div class="col-4" style="">
                <div class="card mb-3 card-1" style="max-width: 540px;">
                    <div class="row g-0">
                        <div class="">
                            <div class="card-body" style="width: 100%">
                                <p class="card-text display-5"><b>Welcome</b></p>
                                <h1 style="margin-top: 10%; width: 100%;" class="card-title display-5">Jenil Gandhi</h1>

                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="col-4" style="">
                <div class="card mb-3 card-2" style="max-width: 540px;">
                    <div class="row g-0">
                        <div class="">
                            <div class="card-body" style="width: 100%">
                                <p class="card-text display-5"><b>Expenditure</b></p>
                                <h1 style="margin-top: 10%; width: 100%;" class="card-title display-5">₹ 550</h1>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-4" style="">
                <div class="card mb-3 card-3" style="max-width: 540px;">
                    <div class="row g-0">
                        <div class="">
                            <div class="card-body" style="width: 100%">
                                <p class="card-text display-5"><b>Income</b></p>
                                <h1 style="margin-top: 10%; width: 100%;" class="card-title display-5">₹ 850</h1>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <h4 class="display-6" style="border-bottom:1px solid black">Expense Chart</h4>
        <canvas id="myChart" style="width:100%;max-width:1270px;height:300px"></canvas>

<script>
    var xValues = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
    var yValues = [500, 200, 300, 900, 1200, 1500, 500, 200, 300, 900, 1200, 1500]
    var barColors = ["#a6f8ff", "#a6f8ff", "#ebff38", "#fa8e1b", "#fa651b", "#cbff3d", "#a5ff3d", "#a5ff3d", "#3dff7b","#3dff7b"];

    new Chart("myChart", {
        type: "bar",
        data: {
            labels: xValues,
            datasets: [{
                backgroundColor: barColors,
                data: yValues
            }]
        },
        options: {
            
           
        }
    });
</script>

    </div>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>


    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>