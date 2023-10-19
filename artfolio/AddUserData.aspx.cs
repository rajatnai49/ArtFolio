using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace artfolio
{
    public partial class AddUserData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string userDesc = txtDesc.Text;
            string workDesc = txtWorkDesp.Text;
            string password = txtPassword.Text;

            string primaryColor = ddlPrimaryColor.SelectedValue;
            string secondaryColor = ddlSecondaryColor.SelectedValue;
            string font = ddlFont.SelectedValue;

            string mobile = txtMobile.Text;
            string email = txtEmail.Text;
            string twitter = txtTwitter.Text;
            string instagram = txtInstagram.Text;
            string facebook = txtFacebook.Text;
            string linkedIn = txtLinkedIn.Text;



            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(userDesc) || string.IsNullOrEmpty(workDesc) || string.IsNullOrEmpty(password))
            {
                Response.Write("Please fill in all required fields.");
                return;
            }

            if (fileDp.HasFile && fileWorkImage.HasFile && filePhoto.HasFiles)
            {
                byte[] dpData = fileDp.FileBytes;
                byte[] workImageData = fileWorkImage.FileBytes;

                int userId = InsertUserData(name, userDesc, dpData, workDesc, workImageData, password);
                InsertCustomizationData(userId, primaryColor, secondaryColor, font);
                InsertContactData(userId, mobile, email, twitter, instagram, facebook, linkedIn);

                foreach (HttpPostedFile uploadedPhoto in filePhoto.PostedFiles)
                {
                    byte[] photoData = new byte[uploadedPhoto.ContentLength];
                    uploadedPhoto.InputStream.Read(photoData, 0, uploadedPhoto.ContentLength);
                    InsertPhotoData(userId, photoData);
                }

                Response.Write("Data has been successfully inserted.<br/>");
                Response.Write("Your UserId is: " + userId + "<br/>");
                Response.Write("Please remember it for doing after updation and don't forget your password 😌<br/>");
                Response.Write("You can see your website here: <a href='" + GetWebsiteUrl(userId) + "'>Your Site</a>");


            }
            else
            {
                Response.Write("Please select all required files.");
            }
        }

        private string GetWebsiteUrl(int userId)
        {
            return "localhost:5174/" + userId;
        }

        private int InsertUserData(string name, string userDesc, byte[] dpData, string workDesc, byte[] workImageData, string password)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\artfolio\artfolio\App_Data\Database.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO [dbo].[User] ([Name], [Desc], [Dp], [WorkDesp], [WorkImage], [Password]) VALUES (@Name, @Desc, @Dp, @WorkDesp, @WorkImage, @Password); SELECT SCOPE_IDENTITY();";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Desc", userDesc);
                        command.Parameters.AddWithValue("@Dp", dpData);
                        command.Parameters.AddWithValue("@WorkDesp", workDesc);
                        command.Parameters.AddWithValue("@WorkImage", workImageData);
                        command.Parameters.AddWithValue("@Password", password);

                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Error inserting user data: " + ex.ToString());
                    throw;
                }
            }
        }

        private void InsertPhotoData(int userId, byte[] photoData)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\artfolio\artfolio\App_Data\Database.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Photo] ([userId], [Image]) VALUES (@userId, @Image);", connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@Image", photoData);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Error inserting photo data: " + ex.ToString());
                }
            }
        }


        private void InsertCustomizationData(int userId, string primaryColor, string secondaryColor, string font)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\artfolio\artfolio\App_Data\Database.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(
                        "INSERT INTO [dbo].[Customization] ([userId], [PrimaryColor], [SecondaryColor], [Font]) VALUES (@userId, @PrimaryColor, @SecondaryColor, @Font);",
                        connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@PrimaryColor", primaryColor);
                        command.Parameters.AddWithValue("@SecondaryColor", secondaryColor);
                        command.Parameters.AddWithValue("@Font", font);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Error inserting customization data: " + ex.ToString());
                }
            }
        }

        private void InsertContactData(int userId, string mobile, string email, string twitter, string instagram, string facebook, string linkedIn)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\artfolio\artfolio\App_Data\Database.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(
                        "INSERT INTO [dbo].[Contact] ([userId], [Mobile], [Email], [Twitter], [Instagram], [Facebook], [LinkedIn]) VALUES (@userId, @Mobile, @Email, @Twitter, @Instagram, @Facebook, @LinkedIn);",
                        connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@Mobile", mobile);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Twitter", twitter);
                        command.Parameters.AddWithValue("@Instagram", instagram);
                        command.Parameters.AddWithValue("@Facebook", facebook);
                        command.Parameters.AddWithValue("@LinkedIn", linkedIn);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Error inserting contact data: " + ex.ToString());
                }
            }
        }

    }
}