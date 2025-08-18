using System;
using System.Data;
using EBillDLL;

namespace EBillApp
{
    public partial class AddBill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string currentMonth = DateTime.Now.ToString("yyyy-MM");
                txtBillMonth.Attributes["max"] = currentMonth;
                LoadConsumerNumbers();
            }
        }

        private void LoadConsumerNumbers()
        {
            ElectricityBoard eb = new ElectricityBoard();
            ddlConsumerNumber.DataSource = eb.GetCustomerNumbers();
            ddlConsumerNumber.DataTextField = "ConsumerNumber";
            ddlConsumerNumber.DataValueField = "ConsumerNumber";
            ddlConsumerNumber.DataBind();
            ddlConsumerNumber.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select Consumer --", ""));
        }

        protected void ddlConsumerNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlConsumerNumber.SelectedIndex > 0)
            {
                string consumerNumber = ddlConsumerNumber.SelectedValue;
                txtConsumerName.Text = GetConsumerName(consumerNumber);
            }
            else
            {
                txtConsumerName.Text = "";
            }
        }

        private string GetConsumerName(string consumerNumber)
        {
            ElectricityBoard eb = new ElectricityBoard();
            DataTable dt = eb.GetAllCustomers();
            DataRow[] rows = dt.Select($"ConsumerNumber = '{consumerNumber}'");
            if (rows.Length > 0)
            {
                return rows[0]["ConsumerName"].ToString();
            }
            return "";
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    ElectricityBill bill = new ElectricityBill();
                    bill.ConsumerNumber = ddlConsumerNumber.SelectedValue;
                    bill.ConsumerName = txtConsumerName.Text;
                    bill.UnitsConsumed = Convert.ToInt32(txtUnitsConsumed.Text);
                    bill.BillMonth = txtBillMonth.Text;   // assign month (YYYY-MM format)


                    ElectricityBoard eb = new ElectricityBoard();
                    eb.CalculateBill(bill);

                    lblBillAmount.Text = $"Bill Amount for {bill.ConsumerName} (Units: {bill.UnitsConsumed}, Month: {bill.BillMonth}): Rs. {bill.BillAmount}";
                    ViewState["CurrentBill"] = bill;
                    btnSave.Enabled = true;
                    lblMessage.Visible = false;
                }
                catch (FormatException ex)
                {
                    lblMessage.Text = ex.Message;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ViewState["CurrentBill"] != null)
            {
                try
                {
                    ElectricityBill bill = (ElectricityBill)ViewState["CurrentBill"];
                    ElectricityBoard eb = new ElectricityBoard();
                    eb.AddBill(bill);

                    lblMessage.Text = "Bill saved successfully!";
                    lblMessage.CssClass = "alert alert-success";
                    lblMessage.Visible = true;

                    // Reset form
                    ddlConsumerNumber.SelectedIndex = 0;
                    txtConsumerName.Text = "";
                    txtUnitsConsumed.Text = "";
                    txtBillMonth.Text = "";
                    lblBillAmount.Text = "";
                    btnSave.Enabled = false;
                    ViewState["CurrentBill"] = null;
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
