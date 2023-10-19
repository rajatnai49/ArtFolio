using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace artfolio
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsAdmin"] == null && Session["UserId"] == null)
            {
                Response.Redirect("LogInForm.aspx");
            }
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["IsAdmin"] = null;
            Session["UserId"] = null;
            Response.Redirect("LogInForm.aspx");
        }

        private void BindGridView()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\artfolio\artfolio\App_Data\Database.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Name, Dp FROM [dbo].[User]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image imgProfile = (Image)e.Row.FindControl("imgProfile");
                if (imgProfile != null)
                {
                    DataRowView drv = e.Row.DataItem as DataRowView;
                    byte[] imageData = drv["Dp"] as byte[];
                    if (imageData != null)
                    {
                        string base64String = Convert.ToBase64String(imageData, 0, imageData.Length);
                        imgProfile.ImageUrl = "data:image/png;base64," + base64String;
                    }
                    else
                    {
                        imgProfile.ImageUrl = "~/path/to/default-image.jpg"; // Set a default image path
                    }
                }
            }
        }

    }
}