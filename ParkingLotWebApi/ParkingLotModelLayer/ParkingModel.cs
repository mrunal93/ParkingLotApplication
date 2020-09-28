using System;

namespace ParkingLotModelLayer
{
    public class ParkingModel
    {
        public int parkingslot { get; set; }
        public string VehicalNo { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }
        public int isDisabled { get; set; }
        public int ParkingCharges { get; set; }
        public int vehicalTypeId { get; set; }
        public int ParkingTypeId { get; set; }
        public int roleId { get; set; }

    }
}
