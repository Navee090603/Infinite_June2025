using System;
using System.Data;
using System.Web.UI.WebControls;
using EBillDLL;

namespace EBillApp
{
    public partial class Customers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCustomers();
            }
        }

        private void LoadCustomers()
        {
            ElectricityBoard eb = new ElectricityBoard();
            DataTable dt = eb.GetAllCustomers();
            gvCustomers.DataSource = dt;
            gvCustomers.DataBind();
        }

        protected void gvCustomers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCustomers.PageIndex = e.NewPageIndex;
            LoadCustomers();
        }
    }
}