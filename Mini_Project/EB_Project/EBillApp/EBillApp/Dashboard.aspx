<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="EBillApp.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Admin Dashboard</h2>
    <hr />
    <div class="container-fluid mt-3">


        <!-- Cards -->
        <div class="row">
            <!-- Total Revenue -->
            <div class="col-md-4">
                <div class="card text-black mb-3 shadow-lg">
                    <div class="card-body d-flex justify-content-between align-items-center">
                        <div>
                            <h5 class="card-title">Total Revenue</h5>
                            <h2><asp:Label ID="lblRevenue" runat="server" Text="₹0"></asp:Label></h2>
                        </div>
                        <i class="bi bi-currency-rupee fs-1"></i>
                    </div>
                </div>
            </div>

            <!-- Total Customers -->
            <div class="col-md-4">
                <div class="card text-black mb-3 shadow-lg">
                    <div class="card-body d-flex justify-content-between align-items-center">
                        <div>
                            <h5 class="card-title">Total Customers</h5>
                            <h2><asp:Label ID="lblCustomers" runat="server" Text="0"></asp:Label></h2>
                        </div>
                        <i class="bi bi-people fs-1"></i>
                    </div>
                </div>
            </div>

            <!-- Bills Generated -->
            <div class="col-md-4">
                <div class="card text-black mb-3 shadow-lg">
                    <div class="card-body d-flex justify-content-between align-items-center">
                        <div>
                            <h5 class="card-title">Bills Generated</h5>
                            <h2><asp:Label ID="lblBills" runat="server" Text="0"></asp:Label></h2>
                        </div>
                        <i class="bi bi-file-earmark-text fs-1"></i>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <!-- Bootstrap Icons -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.8.1/font/bootstrap-icons.css">
</asp:Content>
