<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Assignment_1.Validator" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validation Form</title>
    <style>
        body {
            font-family: Arial;
        }
        .form-container {
            margin: 40px auto;
            width: 550px;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 8px;
        }
        h2 {
            color: darkgreen;
            text-align: center;
        }
        .form-row {
            display: flex;
            align-items: center;
            margin-bottom: 10px;
        }
        .label {
            width: 120px;
            font-weight: bold;
        }
        .input-field {
            flex: 1;
        }
        .error {
            color: red;
            margin-left: 10px;
            white-space: nowrap;
        }
        .error-box {
            border: 1px solid red;
            background-color: #ffe6e6;
            padding: 10px;
            margin-top: 20px;
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h2>Insert Your Details</h2>

            <div class="form-row">
                <span class="label">Name:</span>
                <div class="input-field">
                    <asp:TextBox ID="txtName" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                        ErrorMessage="Name is required" CssClass="error" ValidationGroup="Check" />
                </div>
            </div>

            <div class="form-row">
                <span class="label">Family Name:</span>
                <div class="input-field">
                    <asp:TextBox ID="txtFamily" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvFamily" runat="server" ControlToValidate="txtFamily"
                        ErrorMessage="Family Name is required" CssClass="error" ValidationGroup="Check" />
                    <asp:CompareValidator ID="cmpName" runat="server" ControlToCompare="txtName"
                        ControlToValidate="txtFamily" Operator="NotEqual" Type="String"
                        ErrorMessage="Family Name must differ from Name" CssClass="error" ValidationGroup="Check" />
                </div>
            </div>

            <div class="form-row">
                <span class="label">Address:</span>
                <div class="input-field">
                    <asp:TextBox ID="txtAddress" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                        ErrorMessage="Address is required" CssClass="error" ValidationGroup="Check" />
                    <asp:RegularExpressionValidator ID="revAddress" runat="server"
                        ControlToValidate="txtAddress" ValidationExpression=".{2,}"
                        ErrorMessage="Address must be at least 2 characters" CssClass="error" ValidationGroup="Check" />
                </div>
            </div>

            <div class="form-row">
                <span class="label">City:</span>
                <div class="input-field">
                    <asp:TextBox ID="txtCity" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity"
                        ErrorMessage="City is required" CssClass="error" ValidationGroup="Check" />
                    <asp:RegularExpressionValidator ID="revCity" runat="server"
                        ControlToValidate="txtCity" ValidationExpression=".{2,}"
                        ErrorMessage="City must be at least 2 characters" CssClass="error" ValidationGroup="Check" />
                </div>
            </div>

            <div class="form-row">
                <span class="label">Zip Code:</span>
                <div class="input-field">
                    <asp:TextBox ID="txtZip" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvZip" runat="server" ControlToValidate="txtZip"
                        ErrorMessage="Zip Code is required" CssClass="error" ValidationGroup="Check" />
                    <asp:RegularExpressionValidator ID="revZip" runat="server"
                        ControlToValidate="txtZip" ValidationExpression="^\d{5}$"
                        ErrorMessage="Zip Code must be 5 digits" CssClass="error" ValidationGroup="Check" />
                </div>
            </div>

            <div class="form-row">
                <span class="label">Phone:</span>
                <div class="input-field">
                    <asp:TextBox ID="txtPhone" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone"
                        ErrorMessage="Phone is required" CssClass="error" ValidationGroup="Check" />
                    <asp:RegularExpressionValidator ID="revPhone" runat="server"
                        ControlToValidate="txtPhone" ValidationExpression="^\d{2,3}-\d{7}$"
                        ErrorMessage="Phone must be in format XX-XXXXXXX or XXX-XXXXXXX" CssClass="error" ValidationGroup="Check" />
                </div>
            </div>

            <div class="form-row">
                <span class="label">E-Mail:</span>
                <div class="input-field">
                    <asp:TextBox ID="txtEmail" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Email is required" CssClass="error" ValidationGroup="Check" />
                    <asp:RegularExpressionValidator ID="revEmail" runat="server"
                        ControlToValidate="txtEmail"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ErrorMessage="Invalid email format" CssClass="error" ValidationGroup="Check" />
                </div>
            </div>

            <div class="form-row" style="justify-content:center;">
                <asp:Button ID="btnCheck" runat="server" Text="Check" OnClick="btnCheck_Click" ValidationGroup="Check" />
            </div>

            <div class="error-box">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                    HeaderText="Please fix the following errors:" CssClass="error" ShowMessageBox="False" ShowSummary="True" ValidationGroup="Check" />
            </div>
        </div>
    </form>
</body>
</html>
