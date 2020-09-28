using ParkingLotModelLayer;
using ParkingLotRepositoryLayer;
using System;

namespace ParkingLotBusinessLayer
{
    public class ParkingBusinessLayer
    {

        public readonly IParkingRepository parkingRepository;

        public ParkingBusinessLayer(IParkingRepository parkingRepository)
        {
            this.parkingRepository = parkingRepository;
        }

        public ParkingModel AddParkingData(ParkingModel data)
        {
            return parkingRepository.AddParkingData(data);
        }
        ParkingTypeModel AddParkingType(ParkingTypeModel typeModel)
        {
            return parkingRepository.AddParkingType(typeModel);
        }
        RolesModel AddRoles(RolesModel roles)
        {
            return parkingRepository.AddRoles(roles);
        }
        VehicalTypeModel AddVehicalType(VehicalTypeModel vehicalType)
        {
            return parkingRepository.AddVehicalType(vehicalType);
        }
        ParkingModel Unparked(ParkingModel unpark)
        {
            return parkingRepository.Unparked(unpark);
        }
    }
}
