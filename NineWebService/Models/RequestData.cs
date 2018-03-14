using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NineWebService.Models
{
    public class RequestData
    {
        public Payload[] Payload { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public int? TotalRecords { get; set; }
    }
}
