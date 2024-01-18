using Microsoft.Data.SqlClient;
using SIS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIS.Website.Services
{
    public class UsersDAO
    {
        readonly string connectionString = "Data Source=DESKTOP-M9BRI2O\\SQLEXPRESS;Initial Catalog=Mstudents;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool FindUserByNameAndPassword(UserModel user)
        {
            bool success = false;


            string sqlStatment = "SELECT * FROM dbo.UserRegistration WHERE username = @username AND password =@password ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatment, connection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 150).Value = user.Username;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 150).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                    }
                }
                catch (Exception e)

                {
                    Console.WriteLine(e.Message);
                }


            }
            return success;

            //return true if found in db.
        }
    }
}
