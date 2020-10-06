using ParkingLotModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotRepositoryLayer
{
    public interface IParkingRepository
    {
        IEnumerable<ParkingModel> GetAllData();
        ParkingModel AddParkingData(ParkingModel data);
        ParkingTypeModel AddParkingType(ParkingTypeModel typeModel);
        RolesModel AddRoles(RolesModel roles);
        VehicalTypeModel AddVehicalType(VehicalTypeModel vehicalType);
        ParkingModel Unparked(ParkingModel unpark);
        ParkingModel SearchByVehicalNo(string vehicalnumber);
        ParkingModel SearchByParkingSlot(int slotnumber);
    }
}
