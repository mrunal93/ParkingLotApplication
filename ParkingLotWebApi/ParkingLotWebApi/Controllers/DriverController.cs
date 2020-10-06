using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingLotBusinessLayer;
using ParkingLotModelLayer;

namespace ParkingLotWebApi.Controllers
{
    [Authorize(Roles ="Driver,Owner")]
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        public readonly IParkingBusinessLayer parkingBusiness;
        public readonly MSMQParkingLot mSMQParking = new MSMQParkingLot();

        public DriverController(IParkingBusinessLayer parkingBusiness)
        {
            this.parkingBusiness = parkingBusiness;
        }

        [HttpPost]
        [Route("AddParking")]
        public IActionResult AddParking(ParkingModel parking)
        {
            var parkingResult = this.parkingBusiness.AddParkingData(parking);

            try
            {
                if (parkingResult != null)
                {
                    mSMQParking.Sender("Driver has parked his vehical" + " " + "parking slot Id: " + parking.parkingslot);
                    return this.Ok(new Response(HttpStatusCode.OK, "The Parking Data", parkingResult));
                }
                return this.NotFound(new Response(HttpStatusCode.NotFound, "Parking Data Not Found", parkingResult));
            }
            catch (Exception)
            {
                return this.BadRequest(new Response(HttpStatusCode.BadRequest, "List of Parking not displayed", null));
            }
        }

        [HttpPut]
        [Route("Unparking")]
        public IActionResult Unparking(ParkingModel unpark)
        {
            var parkingResult = this.parkingBusiness.Unparked(unpark);

            try
            {
                if (parkingResult != null)
                {
                    mSMQParking.Sender("Owner has UnParked his vehical" + " " + "parking slot Id: " + unpark.parkingslot);
                    return this.Ok(new Response(HttpStatusCode.OK, "The Parking Data", parkingResult));
                }
                return this.NotFound(new Response(HttpStatusCode.NotFound, "Parking Data Not Found", parkingResult));
            }
            catch (Exception)
            {
                return this.BadRequest(new Response(HttpStatusCode.BadRequest, "List of Parking not displayed", null));
            }
        }
    }
}