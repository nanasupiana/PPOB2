using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPOB.Models.Pulsa
{
    public class MasterPulsa
    {
        public string PulsaId { get; set; }
        public string Deskripsi { get; set; }
    }

    public class MasterOperator
    {
        public string OperatorId { get; set; }
        public string PulsaId { get; set; }
        public string NamaOperator { get; set; }
    }
}