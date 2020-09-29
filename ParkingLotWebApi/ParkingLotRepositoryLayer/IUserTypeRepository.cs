using ParkingLotModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotRepositoryLayer
{
    public interface IUserTypeRepository
    {
        UserTypeModel AddUserType(UserTypeModel userType);
    }
}
