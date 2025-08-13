using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_1
{
    public partial class ProductPage : System.Web.UI.Page
    {
        private Dictionary<string, (string ImageUrl, string Price)> products = new Dictionary<string, (string, string)>
        {
            { "Laptop", ("~/Images/laptop.jpg", "₹65,000") },
            { "Smartphone", ("~/Images/phone.jpg", "₹1,25,000") },
            { "Headphones", ("~/Images/headphone.jpg", "₹3,500") },
            { "Camera", ("~/Images/camera.jpg", "₹40,000") }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProducts.DataSource = products.Keys;
                ddlProducts.DataBind();
                ddlProducts.Items.Insert(0, new ListItem("-- Select Product --", ""));
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = ddlProducts.SelectedValue;
            if (products.ContainsKey(selected))
            {
                imgProduct.ImageUrl = products[selected].ImageUrl;
                lblPrice.Text = "";
            }
            else
            {
                imgProduct.ImageUrl = "";
                lblPrice.Text = "";
            }
        }

        protected void btnGetPrice_Click(object sender, EventArgs e)
        {
            string selected = ddlProducts.SelectedValue;
            if (products.ContainsKey(selected))
            {
                lblPrice.Text = "Price: " + products[selected].Price;
            }
            else
            {
                lblPrice.Text = "Please select a product.";
            }

        }
    }
}