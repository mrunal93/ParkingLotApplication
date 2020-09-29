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
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserTypeBusiness userBusiness;

        public UserController(IUserTypeBusiness userBusiness)
        {
            this.userBusiness = userBusiness;
        }

        [HttpPost]
        [Route("AddUsertype")]
        public IActionResult AddUserType(UserTypeModel userType)
        {
            var userResult = this.userBusiness.AddUserType(userType);

            try
            {
                if (userResult != null)
                {
                    return this.Ok(new Response(HttpStatusCode.OK, "The  Data", userResult));
                }
                return this.NotFound(new Response(HttpStatusCode.NotFound, "Parking Data Not Found", userResult));
            }
            catch (Exception)
            {
                return this.BadRequest(new Response(HttpStatusCode.BadRequest, "List of Parking not displayed", null));
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route(nameof(UserLoginData))]
        public IActionResult UserLoginData(UserTypeModel user)
        {

            var userResult = userBusiness.AddUserType(user);
            try
            {
                if (userResult != null)
                {
                    var jsonToken = userBusiness.GenerateToken(userResult, "User");

                    return Ok(new Response(HttpStatusCode.OK, "login done successfully", jsonToken));
                }
                return NotFound(new Response(HttpStatusCode.NotFound, "List not fount", userResult));

            }
            catch (System.Exception)
            {

                return BadRequest(new Response(HttpStatusCode.BadRequest, "List canot display", null));
            }
        }
    }
}
