using System;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace artfolio
{
    public partial class LogInForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string userId = txt_id.Text;
            string password = txt_password.Text;

            if (userId == "12345" && password == "12345")
            {
                Session["IsAdmin"] = true;
                Response.Redirect("AdminPage.aspx");
            }

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\artfolio\artfolio\App_Data\Database.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id FROM [dbo].[User] WHERE Id = @UserId AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Password", password);

                    object resultObj = command.ExecuteScalar();

                    if (resultObj != null)
                    {
                        Session["UserId"] = userId;
                        // Redirect to UserPanel.aspx with the user ID in the URL
                        Response.Redirect($"UserPage.aspx?UserId={userId}");
                    }
                    else
                    {
                        Response.Write("Invalid user ID or password. Please try again.");
                    }
                }
            }
        }


    }
}
