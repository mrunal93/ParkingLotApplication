using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ParkingLotModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
            sqlCommand.Parameters.AddWithValue("@Password", encodePassowrd);
            sqlCommand.Parameters.AddWithValue("role", userType.Roles);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return userType;
        }

        public string GenerateToken(UserTypeModel login, string type)
        {

            try
            {
                var symmetricSecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

                var signingCreds = new SigningCredentials(symmetricSecuritykey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                claims.Add(new Claim("Email", login.Email.ToString()));
                claims.Add(new Claim("Password", login.Password.ToString()));
                var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                    configuration["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddHours(120),
                    signingCredentials: signingCreds);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
