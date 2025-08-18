<%@ Page Title="Customers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="EBillApp.Customers" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Customers</h2>
    <hr />
    
    <div class="table-responsive">
        <asp:GridView ID="gvCustomers" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvCustomers_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="ConsumerNumber" HeaderText="Consumer Number" />
                <asp:BoundField DataField="ConsumerName" HeaderText="Consumer Name" />
                <asp:BoundField DataField="JoinDate" HeaderText="Join Date" DataFormatString="{0:dd-MMM-yyyy}" />
            </Columns>
            <EmptyDataTemplate>
                No customers found.
            </EmptyDataTemplate>
            <PagerSettings Mode="NumericFirstLast" />
            <PagerStyle CssClass="pagination" />
        </asp:GridView>
    </div>
</asp:Content>
