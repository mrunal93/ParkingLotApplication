using ParkingLotModelLayer;
using ParkingLotRepositoryLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotBusinessLayer
{
    public class UserTypeBusiness :IUserTypeBusiness
    {
        public readonly IUserTypeRepository userTypeRepository;

        public UserTypeBusiness(IUserTypeRepository userTypeRepository)
        {
            this.userTypeRepository = userTypeRepository;
        }

        public UserTypeModel AddUserType(UserTypeModel userType)
        {
            return userTypeRepository.AddUserType(userType);
        }

        public string GenerateToken(UserTypeModel login, string type)
        {
            return userTypeRepository.GenerateToken(login, type);
        }
    }
}
