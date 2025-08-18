using System;
using System.Web.UI;

namespace EBillApp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if user is authenticated
                if (Session["Username"] == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void SignOut(object sender, EventArgs e)
        {
            // Clear all session variables
            Session.Clear();

            // Abandon the session
            Session.Abandon();

            //clear any existing cookies
            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-1);
            }

            //clear the output cache
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetNoStore();

            // Clear authentication cookie
            System.Web.Security.FormsAuthentication.SignOut();

            // Redirect to login page
            Response.Redirect("~/Login.aspx");
        }
    }
}