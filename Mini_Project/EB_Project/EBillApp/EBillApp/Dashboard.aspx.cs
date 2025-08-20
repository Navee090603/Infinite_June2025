using System;
using System.Data.SqlClient;
using System.Configuration;

namespace EBillApp
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDashboardData();
            }
        }

        private void LoadDashboardData()
        {
            string connStr = ConfigurationManager.ConnectionStrings["EBillDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                // Total Revenue
                string revenueQuery = "SELECT ISNULL(SUM(BillAmount),0) FROM ElectricityBill";
                SqlCommand cmdRevenue = new SqlCommand(revenueQuery, con);
                decimal totalRevenue = Convert.ToDecimal(cmdRevenue.ExecuteScalar());
                lblRevenue.Text = "₹" + totalRevenue.ToString("N2");

                // Total Customers
                string customerQuery = "SELECT COUNT(*) FROM Customers";
                SqlCommand cmdCustomers = new SqlCommand(customerQuery, con);
                int totalCustomers = Convert.ToInt32(cmdCustomers.ExecuteScalar());
                lblCustomers.Text = totalCustomers.ToString();

                // Total Bills
                string billQuery = "SELECT COUNT(*) FROM ElectricityBill";
                SqlCommand cmdBills = new SqlCommand(billQuery, con);
                int totalBills = Convert.ToInt32(cmdBills.ExecuteScalar());
                lblBills.Text = totalBills.ToString();
            }
        }


    }
}
