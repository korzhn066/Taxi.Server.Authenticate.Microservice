using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Server.Authenticate.Microservice.Domain.Models
{
    public class ApplicationUserRegister
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "PhoneNumber is required")]
        public string PhoneNumber { get; set; } = null!;
    }
}
