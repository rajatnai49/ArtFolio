using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

namespace artfolio
{
    public partial class UserPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsAdmin"] == null && Session["UserId"] == null)
            {
                Response.Redirect("LogInForm.aspx");
            }
            if (!IsPostBack)
            {
                LoadUserDetails();
                LoadContactDetails();
                LoadCustomizationDetails();
                LoadPhotos();

            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["IsAdmin"] = null;
            Session["UserId"] = null;
            Response.Redirect("LogInForm.aspx");
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateUserDetails();
        }

        protected void btnContactUpdate_Click(object sender, EventArgs e)
        {
            UpdateContactDetails();
        }

        protected void btnCustomUpdate_Click(object sender, EventArgs e)
        {
            UpdateCustomDetails();
        }

        private void LoadUserDetails()
        {
            string userId = Request.QueryString["UserId"];
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\artfolio\artfolio\App_Data\Database.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM [dbo].[User] WHERE Id = @UserId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtName.Text = reader["Name"].ToString();
                            txtPassword.Text = reader["Password"].ToString(); 
                            txtDescription.Text = reader["Desc"].ToString();
                            txtWorkDesp.Text = reader["WorkDesp"].ToString();
                        }
                    }
                }
            }
        }

        private void LoadContactDetails()
        {
            string userId = Request.QueryString["UserId"];
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\artfolio\artfolio\App_Data\Database.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM [dbo].[Contact] WHERE UserId = @UserId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtNo.Text = reader["Mobile"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                            txtTwitter.Text = reader["Twitter"].ToString();
                            txtInstagram.Text = reader["Instagram"].ToString();
                            txtFacebook.Text = reader["Facebook"].ToString();
                            txtLinkedln.Text = reader["LinkedIn"].ToString();
                        }
                    }
                }
            }
        }

        private void LoadCustomizationDetails()
        {
            string userId = Request.QueryString["UserId"];
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\artfolio\artfolio\App_Data\Database.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM [dbo].[Customization] WHERE UserId = @UserId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Set the selected values in the dropdown lists
                            string primaryColor = reader["PrimaryColor"].ToString();
                            string secondaryColor = reader["SecondaryColor"].ToString();
                            string font = reader["Font"].ToString();

                            SetDropDownSelectedValue(ddlPrimaryColor, primaryColor);
                            SetDropDownSelectedValue(ddlSecondaryColor, secondaryColor);
                            SetDropDownSelectedValue(ddlFont, font);
                        }
                    }
                }
            }
        }

        private void UpdateUserDetails()
        {
            string userId = Request.QueryString["UserId"];
            string name = txtName.Text;
            string password = txtPassword.Text;
            string description = txtDescription.Text;
            string workDesp = txtWorkDesp.Text;

            byte[] profilePicture = fileProfilePicture.HasFile ? fileProfilePicture.FileBytes : null;
            byte[] workImage = fileWorkImage.HasFile ? fileWorkImage.FileBytes : null;

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\artfolio\artfolio\App_Data\Database.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE [dbo].[User] SET Name = @Name, Password = @Password, [Desc] = @Desc, Dp = @Dp, WorkDesp = @WorkDesp, WorkImage = @WorkImage WHERE Id = @UserId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Desc", description);
                    command.Parameters.AddWithValue("@Dp", profilePicture);
                    command.Parameters.AddWithValue("@WorkDesp", workDesp);
                    command.Parameters.AddWithValue("@WorkImage", workImage);

                    command.ExecuteNonQuery();
                }
            }
            lblMessage.Text = "User details updated successfully!";

            Response.Redirect(Request.RawUrl);
        }

        private void UpdateContactDetails()
        {
            string userId = Request.QueryString["UserId"];
            string mobile = txtNo.Text;
            string email = txtEmail.Text;
            string twitter = txtTwitter.Text;
            string instagram = txtInstagram.Text;
            string facebook = txtFacebook.Text;
            string linkedin = txtLinkedln.Text;

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\artfolio\artfolio\App_Data\Database.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE [dbo].[Contact] SET Mobile = @Mobile, Email = @Email, Twitter = @Twitter, Instagram = @Instagram, Facebook = @Facebook, LinkedIn = @LinkedIn WHERE UserId = @UserId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Mobile", mobile);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Twitter", twitter);
                    command.Parameters.AddWithValue("@Instagram", instagram);
                    command.Parameters.AddWithValue("@Facebook", facebook);
                    command.Parameters.AddWithValue("@LinkedIn", linkedin);

                    command.ExecuteNonQuery();
                    lblMessage.Text = "User details updated successfully!";
                }
            }
            Response.Redirect(Request.RawUrl);
        }

        private void UpdateCustomDetails()
        {
            string userId = Request.QueryString["UserId"];
            string primaryColor = ddlPrimaryColor.SelectedValue;
            string secondaryColor = ddlSecondaryColor.SelectedValue;
            string font = ddlFont.SelectedValue;

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\artfolio\artfolio\App_Data\Database.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE [dbo].[Customization] SET PrimaryColor = @PrimaryColor, SecondaryColor = @SecondaryColor, Font = @Font WHERE UserId = @UserId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@PrimaryColor", primaryColor);
                    command.Parameters.AddWithValue("@SecondaryColor", secondaryColor);
                    command.Parameters.AddWithValue("@Font", font);

                    command.ExecuteNonQuery();
                }
            }

            Response.Redirect(Request.RawUrl);
        }

        private void SetDropDownSelectedValue(DropDownList dropDownList, string value)
        {
            ListItem item = dropDownList.Items.FindByValue(value);
            if (item != null)
            {
                item.Selected = true;
            }
        }

        private void LoadPhotos()
        {
            string userId = Request.QueryString["UserId"];
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\artfolio\artfolio\App_Data\Database.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM [dbo].[Photo] WHERE userId = @UserId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        rptPhotos.DataSource = reader;
                        rptPhotos.DataBind();
                    }
                }
            }
        }

        protected void btnDeletePhoto_Click(object sender, EventArgs e)
        {
            string photoId = ((Button)sender).CommandArgument;
            DeletePhoto(photoId);
            LoadPhotos();
        }

        private void DeletePhoto(string photoId)
        {
            // Implement logic to delete a photo from the database
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\artfolio\artfolio\App_Data\Database.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM [dbo].[Photo] WHERE Id = @PhotoId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PhotoId", photoId);
                    command.ExecuteNonQuery();
                }
            }
        }


        protected void btnAddPhoto_Click(object sender, EventArgs e)
        {
            string userId = Request.QueryString["UserId"];
            string desc = txtNewPhotoDesc.Text;

            if (fileNewPhoto.HasFile)
            {
                byte[] imageBytes = fileNewPhoto.FileBytes;
                AddNewPhoto(userId, desc, imageBytes);
                LoadPhotos();
            }
        }

        private void AddNewPhoto(string userId, string desc, byte[] imageBytes)
        {
            // Implement logic to add a new photo to the database
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\artfolio\artfolio\App_Data\Database.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO [dbo].[Photo] (userId, Image, [Desc]) VALUES (@UserId, @Image, @Desc)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Image", imageBytes);
                    command.Parameters.AddWithValue("@Desc", desc);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
