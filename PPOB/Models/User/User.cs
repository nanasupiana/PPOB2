using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPOB.Models.User
{
    public class User
    {
        public string NameIdentifier { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public int AccessFailedCount { get; set; }
        public string PhoneNumber { get; set; }
        //[Required, Microsoft.Web.Mvc.FileExtensions(Extensions = "csv",
        //     ErrorMessage = "Specify a CSV file. (Comma-separated values)")]
        public string Photo { get; set; }
        public int RoleId { get; set; }
    }
}