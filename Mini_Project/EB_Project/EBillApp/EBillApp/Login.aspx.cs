using System;
using System.Data.SqlClient;

namespace EBillApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Please enter both username and password";
                lblError.Visible = true;
                return;
            }

            try
            {
                using (SqlConnection connection = EBillDLL.DBHandler.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM AdminLogin WHERE Username = @Username AND Password = @Password";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        Session["Username"] = username;
                        Response.Redirect("~/AddBill.aspx");
                    }
                    else
                    {
                        lblError.Text = "Invalid username or password";
                        lblError.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error: " + ex.Message;
                lblError.Visible = true;
            }
        }
    }
}