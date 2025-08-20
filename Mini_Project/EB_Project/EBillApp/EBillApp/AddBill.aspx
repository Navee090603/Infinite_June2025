<%@ Page Title="Add Bill" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBill.aspx.cs" Inherits="EBillApp.AddBill" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Add New Bill</h2>
    <hr />
    
    <div class="form-horizontal">
        <div class="form-group">
            <label class="control-label col-md-2">Consumer Number</label>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlConsumerNumber" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlConsumerNumber_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
        
        <div class="form-group">
            <label class="control-label col-md-2">Consumer Name</label>
            <div class="col-md-10">
                <asp:TextBox ID="txtConsumerName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
        </div>

        <!-- Bill Month Selection -->
<div class="form-group">
    <label class="control-label col-md-2">Bill Month</label>
    <div class="col-md-10">
        <!-- HTML5 month picker -->
        <asp:TextBox ID="txtBillMonth" runat="server" CssClass="form-control" 
                     TextMode="Month"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvMonth" runat="server" ControlToValidate="txtBillMonth" 
            ErrorMessage="Please select a bill month" CssClass="text-danger"></asp:RequiredFieldValidator>
    </div>
</div>
        
        <div class="form-group">
            <label class="control-label col-md-2">Units Consumed</label>
            <div class="col-md-10">
                <asp:TextBox ID="txtUnitsConsumed" runat="server" CssClass="form-control" TextMode="Number" min="1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUnits" runat="server" ControlToValidate="txtUnitsConsumed" 
                    ErrorMessage="Units consumed is required" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvUnits" runat="server" ControlToValidate="txtUnitsConsumed" 
                    Type="Integer" MinimumValue="1" MaximumValue="999999" 
                    ErrorMessage="Check the Units" CssClass="text-danger" Display="Dynamic"></asp:RangeValidator>
            </div>
        </div>
        
        <div class="form-group mt-3">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="btnCalculate" runat="server" Text="Calculate Bill" CssClass="btn btn-primary" OnClick="btnCalculate_Click" />
                <asp:Button ID="btnSave" runat="server" Text="Save Bill" CssClass="btn btn-success" OnClick="btnSave_Click" Enabled="false" />
            </div>
        </div>
        
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Label ID="lblBillAmount" runat="server" CssClass="lead"></asp:Label>
            </div>
        </div>
        
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Label ID="lblMessage" runat="server" CssClass="alert" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
