<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductPage.aspx.cs" Inherits="Assignment_1.ProductPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Viewer</title>
    <style>
        body {
            margin: 0;
            padding: 0;
            background: linear-gradient(to right, #f0f4f8, #d9e2ec);
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

        .container {
            max-width: 500px;
            margin: 60px auto;
            padding: 30px;
            background-color: #ffffff;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
            border-radius: 12px;
            text-align: center;
        }

        h2 {
            color: #2c3e50;
            margin-bottom: 20px;
        }

        .dropdown {
            width: 100%;
            padding: 10px;
            font-size: 16px;
            margin-bottom: 20px;
            border-radius: 6px;
            border: 1px solid #ccc;
        }

        .product-image {
            width: 220px;
            height: 220px;
            object-fit: contain;
            border: 1px solid #ddd;
            border-radius: 8px;
            margin: 20px 0;
        }

        .btn {
            background-color: #3498db;
            color: white;
            border: none;
            padding: 10px 20px;
            font-size: 16px;
            border-radius: 6px;
            cursor: pointer;
        }

        .btn:hover {
            background-color: #2980b9;
        }

        .price-label {
            font-size: 20px;
            color: #27ae60;
            margin-top: 15px;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Select a Product</h2>

            <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="true" Class="dropdown" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged" />

            <asp:Image ID="imgProduct" runat="server" Class="product-image" />
            <br />
            <asp:Button ID="btnGetPrice" runat="server" Text="Get Price" Class="btn" OnClick="btnGetPrice_Click" />
            <br /><br />
            <asp:Label ID="lblPrice" runat="server" Class="price-label" />
        </div>
    </form>
</body>
</html>>