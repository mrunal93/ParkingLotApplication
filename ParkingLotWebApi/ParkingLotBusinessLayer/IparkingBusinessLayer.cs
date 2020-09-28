using ParkingLotModelLayer;
using ParkingLotRepositoryLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotBusinessLayer
{
    public interface IParkingBusinessLayer
    {
        ParkingModel AddParkingData(ParkingModel data);
        ParkingTypeModel AddParkingType(ParkingTypeModel typeModel);
        RolesModel AddRoles(RolesModel roles);
        VehicalTypeModel AddVehicalType(VehicalTypeModel vehicalType);
        ParkingModel Unparked(ParkingModel unpark);
    }
}
