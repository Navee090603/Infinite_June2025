<%@ Page Title="Add Customer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="EBillApp.AddCustomer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Add New Customer</h2>
    <hr />
    
    <div class="form-horizontal">
        <div class="form-group">
            <label class="control-label col-md-2">Consumer Number</label>
            <div class="col-md-10">
                <asp:TextBox ID="txtConsumerNumber" runat="server" CssClass="form-control" placeholder="EB followed by 5 digits (e.g., EB12345)"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvConsumerNumber" runat="server" ControlToValidate="txtConsumerNumber" 
                    ErrorMessage="Consumer number is required" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revConsumerNumber" runat="server" ControlToValidate="txtConsumerNumber"
                    ValidationExpression="^EB\d{5}$" ErrorMessage="Consumer number must start with EB followed by 5 digits" 
                    CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
        </div>
        
        <div class="form-group">
            <label class="control-label col-md-2">Consumer Name</label>
            <div class="col-md-10">
                <asp:TextBox ID="txtConsumerName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvConsumerName" runat="server" ControlToValidate="txtConsumerName" 
                    ErrorMessage="Consumer name is required" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        
        <div class="form-group mt-3">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="btnSave" runat="server" Text="Save Customer" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            </div>
        </div>
        
        <div class="form-group mt-3">
            <div class="col-md-offset-2 col-md-10">
                <asp:Label ID="lblMessage" runat="server" CssClass="alert" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>