using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPOB.Models.RoleMenu
{
    public class RoleMenu
    {
        public string RoleMenuID { get; set; }
        public string RoleID { get; set; }
        public string MenuID { get; set; }
        public string RoleName { get; set; }
        public string MenuName { get; set; }
        public string Active { get; set; }
        public string Create { get; set; }
        public string Update { get; set; }
        public string Delete { get; set; }
    }

    public class RoleMenuDetail
    {
        public string RoleMenuID { get; set; }
        public string RoleID { get; set; }
        public string MenuID { get; set; }
        public string RoleName { get; set; }
        public string MenuName { get; set; }
        public string Active { get; set; }
        public string Create { get; set; }
        public string Update { get; set; }
        public string Delete { get; set; }
    }
}