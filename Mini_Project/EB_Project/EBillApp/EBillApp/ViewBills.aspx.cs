using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EBillDLL;

namespace EBillApp
{
    public partial class ViewBills : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnViewBills_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    int numberOfBills = Convert.ToInt32(txtNumberOfBills.Text);
                    ElectricityBoard eb = new ElectricityBoard();
                    List<ElectricityBill> bills = eb.Generate_N_BillDetails(numberOfBills);

                    if (bills.Count > 0)
                    {
                        gvBills.DataSource = bills;
                        gvBills.DataBind();
                        gvBills.Visible = true;
                    }
                    else
                    {
                        gvBills.Visible = false;
                        // Show message if no bills found
                    }
                }
                catch (Exception ex)
                {
                    // Handle error
                }
            }
        }
    }
}