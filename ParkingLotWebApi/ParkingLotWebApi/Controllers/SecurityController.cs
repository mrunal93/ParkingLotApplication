﻿using System;
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
    [Authorize(Roles = "Security,Owner")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        public readonly IParkingBusinessLayer parkingBusiness;
        public readonly MSMQParkingLot mSMQParking = new MSMQParkingLot();

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
                    mSMQParking.Sender("Security has parked his vehical" + " " + "parking slot Id: " + parking.parkingslot);
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
                    mSMQParking.Sender("Owner has Unparked his vehical" + " " + "parking slot Id: " + unpark.parkingslot);
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
        [Route("SearchByVehicalNo")]
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
        [Route("SearchByParkingSlot")]
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
