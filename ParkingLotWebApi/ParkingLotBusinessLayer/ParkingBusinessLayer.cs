using ParkingLotModelLayer;
using ParkingLotRepositoryLayer;
using System;

namespace ParkingLotBusinessLayer
{
    public class ParkingBusinessLayer :IParkingBusinessLayer 
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
       
        public ParkingTypeModel AddParkingType(ParkingTypeModel typeModel)
        {
            return parkingRepository.AddParkingType(typeModel);
        }
       
        public RolesModel AddRoles(RolesModel roles)
        {
            return parkingRepository.AddRoles(roles);
        }
       
        public VehicalTypeModel AddVehicalType(VehicalTypeModel vehicalType)
        {
            return parkingRepository.AddVehicalType(vehicalType);
        }
        
        public ParkingModel Unparked(ParkingModel unpark)
        {
            return parkingRepository.Unparked(unpark);
        }

        public ParkingModel SearchByVehicalNo(string vehicalnumber)
        {
            return parkingRepository.SearchByVehicalNo(vehicalnumber);
        }
        
        public ParkingModel SearchByParkingSlot(int slotnumber)
        {
            return parkingRepository.SearchByParkingSlot(slotnumber);
        }
    }
}
