using System;
using System.Data.SqlClient;
using EBillDLL;

namespace EBillApp
{
    public partial class AddCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    ElectricityBill customer = new ElectricityBill();
                    customer.ConsumerNumber = txtConsumerNumber.Text.Trim();
                    customer.ConsumerName = txtConsumerName.Text.Trim();

                    ElectricityBoard eb = new ElectricityBoard();
                    eb.AddCustomer(customer);

                    lblMessage.Text = "Customer added successfully!";
                    lblMessage.CssClass = "alert alert-success";
                    lblMessage.Visible = true;

                    // Clear form
                    txtConsumerNumber.Text = "";
                    txtConsumerName.Text = "";
                }
                catch (FormatException ex)
                {
                    lblMessage.Text = ex.Message;
                    lblMessage.CssClass = "alert alert-danger";
                    lblMessage.Visible = true;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Primary key violation
                    {
                        lblMessage.Text = "Consumer number already exists";
                    }
                    else
                    {
                        lblMessage.Text = "Database error: " + ex.Message;
                    }
                    lblMessage.CssClass = "alert alert-danger";
                    lblMessage.Visible = true;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                    lblMessage.CssClass = "alert alert-danger";
                    lblMessage.Visible = true;
                }
            }
        }
    }
}