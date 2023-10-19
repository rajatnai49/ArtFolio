using artfolio.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace artfolio.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<String> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public User Get(int id)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\artfolio\artfolio\App_Data\Database.mdf;Integrated Security=True";

            User user = null;

            string query = @"
            SELECT
    u.*,
    ph.Image AS PhotoImage,
    ph.[Desc] AS [PhotoDesc],
    c.PrimaryColor,
    c.SecondaryColor,
    c.Font,
    con.Mobile,
    con.Email,
    con.Twitter,
    con.Instagram,
    con.Facebook,
    con.LinkedIn
FROM
    [dbo].[User] u
LEFT JOIN
    [dbo].[Photo] ph ON u.Id = ph.userId
LEFT JOIN
    [dbo].[Customization] c ON u.Id = c.userId
LEFT JOIN
    [dbo].[Contact] con ON u.Id = con.userId
WHERE
    u.Id = @UserId;
";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", id);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (user == null)
                            {
                                user = new User
                                {
                                    Id = (int)reader["Id"],
                                    Name = (string)reader["Name"],
                                    Description = (string)reader["Desc"],
                                    DisplayPicture = reader["Dp"] as byte[],
                                    WorkDescription = (string)reader["WorkDesp"],
                                    WorkImage = reader["WorkImage"] as byte[],
                                    Password = (string)reader["Password"],
                                    Customization = new Customization
                                    {
                                        PrimaryColor = reader["PrimaryColor"] as string,
                                        SecondaryColor = reader["SecondaryColor"] as string,
                                        Font = reader["Font"] as string
                                    },
                                    Contact = new Contact
                                    {
                                        Mobile = reader["Mobile"] as string,
                                        Email = reader["Email"] as string,
                                        Twitter = reader["Twitter"] as string,
                                        Instagram = reader["Instagram"] as string,
                                        Facebook = reader["Facebook"] as string,
                                        LinkedIn = reader["LinkedIn"] as string
                                    },
                                    Photos = new List<Photo>(),
                                };
                            }

                            if (reader["PhotoImage"] != DBNull.Value)
                            {
                                user.Photos.Add(new Photo
                                {
                                    Image = (byte[])reader["PhotoImage"],
                                    Desc = reader["PhotoDesc"] as string,
                                    UserId = user.Id
                                });
                            }
                        }
                    }
                }
            }

            return user;
        }


        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
