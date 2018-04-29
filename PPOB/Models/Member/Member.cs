using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPOB.Models
{
    public class MasterMember
    {
        public string MemberId { get; set; }
        public string Photo { get; set; }
        public string NamaMember { get; set; }
        public string Email { get; set; }
        public string KodeReverall { get; set; }
        public string NoTepon { get; set; }
        public string TypeMember { get; set; }
        public string TanggalGabung { get; set; }
    }
}