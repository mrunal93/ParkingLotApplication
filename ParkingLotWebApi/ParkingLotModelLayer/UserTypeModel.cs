using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParkingLotModelLayer
{
    public class UserTypeModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9.+_-]+[@][a-zA-Z0-9]+[.]co(m|.in)$")]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^([A-Za-z0-9])*[!@#$%^&*]{1}([A-Za-z0-9])*$")]
        public string Password { get; set; }
        public string Roles { get; set; }
    }
}
