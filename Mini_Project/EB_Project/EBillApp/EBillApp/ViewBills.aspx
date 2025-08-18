<%@ Page Title="View Bills" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewBills.aspx.cs" Inherits="EBillApp.ViewBills" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>View Bills</h2>
    <hr />
    
    <div class="form-horizontal">
        <div class="form-group">
            <label class="control-label col-md-2">Number of Bills to View</label>
            <div class="col-md-10">
                <asp:TextBox ID="txtNumberOfBills" runat="server" CssClass="form-control" TextMode="Number" min="1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNumber" runat="server" ControlToValidate="txtNumberOfBills" 
                    ErrorMessage="Please enter number of bills" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvNumber" runat="server" ControlToValidate="txtNumberOfBills" 
                    Type="Integer" MinimumValue="1" MaximumValue="100" 
                    ErrorMessage="Please enter a number between 1 and 100" CssClass="text-danger" Display="Dynamic"></asp:RangeValidator>
            </div>
        </div>
        
        <div class="form-group mt-3">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="btnViewBills" runat="server" Text="View Bills" CssClass="btn btn-primary" OnClick="btnViewBills_Click" />
            </div>
        </div>
    </div>
    
    <hr />
    
    <div class="table-responsive">
        <asp:GridView ID="gvBills" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="false" Visible="false">
            <Columns>
                <asp:BoundField DataField="ConsumerNumber" HeaderText="Consumer Number" />
                <asp:BoundField DataField="ConsumerName" HeaderText="Consumer Name" />
                <asp:BoundField DataField="UnitsConsumed" HeaderText="Units Consumed" />
                <asp:BoundField DataField="BillAmount" HeaderText="Bill Amount (Rs.)" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="BillMonth" HeaderText="Bill Month" />

            </Columns>
            <EmptyDataTemplate>
                No bills found.
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
</asp:Content>