using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPOB.Models.MasterMenu
{
    public class MasterMenu
    {
        public string MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuURL { get; set; }
        public string MenuIcon { get; set; }
        public string MenuParentId { get; set; }
        public string MenuParent { get; set; }
    }
}