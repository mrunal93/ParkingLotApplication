using ParkingLotModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotBusinessLayer
{
    public interface IUserTypeBusiness
    {
        UserTypeModel AddUserType(UserTypeModel userType);
    }
}
