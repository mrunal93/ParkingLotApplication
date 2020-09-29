using Microsoft.Extensions.Configuration;
using ParkingLotModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ParkingLotRepositoryLayer
{
    public class UserTypeRepository :IUserTypeRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly SqlConnection sqlConnection;

        public UserTypeRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("UserDbConnection");
            this.sqlConnection = new SqlConnection(this.connectionString);
        }

        public string EncodePassword(string password)
        {
            byte[] encPassword = new byte[password.Length];
            encPassword = Encoding.UTF8.GetBytes(password);
            string encodedPassword = Convert.ToBase64String(encPassword);
            return encodedPassword;

        }

        public UserTypeModel AddUserType(UserTypeModel userType)
        {
            SqlCommand sqlCommand = new SqlCommand("sp_AddUserType", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            var encodePassowrd = this.EncodePassword(userType.Password);

            sqlCommand.Parameters.AddWithValue("@email", userType.Email);
            sqlCommand.Parameters.AddWithValue("@Password", userType.Password);
            sqlCommand.Parameters.AddWithValue("role", userType.Roles);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return userType;
        }
    }
}
