using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingLotBusinessLayer;
using ParkingLotModelLayer;

namespace ParkingLotWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        public readonly IParkingBusinessLayer parkingBusiness;

        public SecurityController(IParkingBusinessLayer parkingBusiness)
        {
            this.parkingBusiness = parkingBusiness;
        }

        [HttpPost]
        [Route("sAddParking")]
        public IActionResult AddParking(ParkingModel parking)
        {
            var parkingResult = this.parkingBusiness.AddParkingData(parking);

            try
            {
                if (parkingResult != null)
                {
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
        [Route("sUnparking")]
        public IActionResult Unparking(ParkingModel unpark)
        {
            var parkingResult = this.parkingBusiness.Unparked(unpark);

            try
            {
                if (parkingResult != null)
                {
                    return this.Ok(new Response(HttpStatusCode.OK, "The Parking Data", parkingResult));
                }
                return this.NotFound(new Response(HttpStatusCode.NotFound, "Parking Data Not Found", parkingResult));
            }
            catch (Exception)
            {
                return this.BadRequest(new Response(HttpStatusCode.BadRequest, "List of Parking not displayed", null));
            }
        }

        [HttpGet]
        [Route("sSearchByVehicalNo")]
        public IActionResult SearchByVehicalNo(string vehicalnumber)
        {
            var parkingData = this.parkingBusiness.SearchByVehicalNo(vehicalnumber);

            try
            {
                if (parkingData != null)
                {
                    return this.Ok(new Response(HttpStatusCode.OK, "The Parking Data", parkingData));
                }
                return this.NotFound(new Response(HttpStatusCode.NotFound, "Parking Data Not Found", parkingData));
            }
            catch (Exception)
            {
                return this.BadRequest(new Response(HttpStatusCode.BadRequest, "List of Parking not displayed", null));
            }

        }

        [HttpGet]
        [Route("sSearchByParkingSlot")]
        public IActionResult SearchByParkingSlot(int slotnumber)
        {
            var parkingData = this.parkingBusiness.SearchByParkingSlot(slotnumber);

            try
            {
                if (parkingData != null)
                {
                    return this.Ok(new Response(HttpStatusCode.OK, "The Parking Data", parkingData));
                }
                return this.NotFound(new Response(HttpStatusCode.NotFound, "Parking Data Not Found", parkingData));
            }
            catch (Exception)
            {
                return this.BadRequest(new Response(HttpStatusCode.BadRequest, "List of Parking not displayed", null));
            }

        }
    }
}
