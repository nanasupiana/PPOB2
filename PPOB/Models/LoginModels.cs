using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPOB.Models
{
    public class UserLogin
    {        
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public byte  Photo { get; set; }
        public string NoTelpon { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string LastLogin { get; set; }
        public string UserType { get; set; }
        public string Active { get; set; }

       
    }
    public class RoleUser
    {
        public string UserName { get; set; }
        public string ValidFrom { get; set; }
        public string ValidThrough { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string Active { get; set; }        
    }

    public class UserPermition
    {
        public string UserName { get; set; }
        public string ValidFrom { get; set; }
        public string ValidThrough { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string Active { get; set; }
    }  
}