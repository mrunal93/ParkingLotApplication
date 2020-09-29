using Microsoft.Extensions.Configuration;
using ParkingLotModelLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ParkingLotRepositoryLayer
{
    public class ParkingRepository : IParkingRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly SqlConnection sqlConnection;

        public ParkingRepository (IConfiguration configuration)
        {

            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("UserDbConnection");
            this.sqlConnection = new SqlConnection(this.connectionString);
        }

       public ParkingModel AddParkingData(ParkingModel data)
        {
            SqlCommand sqlCommand = new SqlCommand("sp_AddParking", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@parkingSlot", data.parkingslot);
            sqlCommand.Parameters.AddWithValue("@VehicalNo", data.VehicalNo);
            sqlCommand.Parameters.AddWithValue("@isDisable", data.isDisabled);
            sqlCommand.Parameters.AddWithValue("@vehicalTypeId", data.vehicalTypeId);
            sqlCommand.Parameters.AddWithValue("@parkingtypeId", data.ParkingTypeId);
            sqlCommand.Parameters.AddWithValue("@roleId", data.roleId);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return data;

        }

        public ParkingTypeModel AddParkingType(ParkingTypeModel typeModel)
        {
            SqlCommand sqlCommand = new SqlCommand("sp_AddParkingType", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@parkingType", typeModel.ParkingType);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return typeModel;
        }

        public RolesModel AddRoles(RolesModel roles)
        {
            SqlCommand sqlCommand = new SqlCommand("sp_AddParkingType", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("sp_AddRoles", roles.Roles);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return roles;
        }

        public VehicalTypeModel AddVehicalType(VehicalTypeModel vehicalType)
        {
            SqlCommand sqlCommand = new SqlCommand("sp_AddVehicalType", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@VehicalType", vehicalType.VehicalType);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return vehicalType;
        }

        public ParkingModel Unparked(ParkingModel unpark)
        {
            SqlCommand sqlCommand = new SqlCommand("sp_UnParked", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@ParkingSlot", unpark.parkingslot);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return unpark;
        }

        public ParkingModel SearchByVehicalNo(string vehicalnumber)
        {
            ParkingModel vehical = new ParkingModel();

            SqlCommand sqlCommand = new SqlCommand("sp_SearchByVehicalNumber", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("vehicalNO", vehicalnumber);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                vehical.parkingslot = Convert.ToInt32(sqlDataReader["parkingSlot"]);
                vehical.VehicalNo = sqlDataReader["VehicalNo"].ToString();
                vehical.EntryTime = sqlDataReader["EntryTime"].ToString();
                vehical.ExitTime = sqlDataReader["ExitTime"].ToString();
                vehical.isDisabled = Convert.ToInt32(sqlDataReader["isDisabled"]);
                vehical.ParkingCharges = Convert.ToInt32(sqlDataReader["ParkingCharges"]);
                vehical.vehicalTypeId = Convert.ToInt32(sqlDataReader["vehicalTypeId"]);
                vehical.roleId = Convert.ToInt32(sqlDataReader["roleId"]);
                vehical.ParkingTypeId = Convert.ToInt32(sqlDataReader["ParkingTypeId"]);
            }
            return vehical;
        }

        public ParkingModel SearchByParkingSlot(int slotnumber)
        {
            ParkingModel vehical = new ParkingModel();

            SqlCommand sqlCommand = new SqlCommand("sp_SearchByParkingSlot", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@parkingSlot", slotnumber);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                vehical.parkingslot = Convert.ToInt32(sqlDataReader["parkingSlot"]);
                vehical.VehicalNo = sqlDataReader["VehicalNo"].ToString();
                vehical.EntryTime = sqlDataReader["EntryTime"].ToString();
                vehical.ExitTime = sqlDataReader["ExitTime"].ToString();
                vehical.isDisabled = Convert.ToInt32(sqlDataReader["isDisabled"]);
                vehical.ParkingCharges = Convert.ToInt32(sqlDataReader["ParkingCharges"]);
                vehical.vehicalTypeId = Convert.ToInt32(sqlDataReader["vehicalTypeId"]);
                vehical.roleId = Convert.ToInt32(sqlDataReader["roleId"]);
                vehical.ParkingTypeId = Convert.ToInt32(sqlDataReader["ParkingTypeId"]);
            }
            return vehical;
        }
    }
}
