using NineWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NineWebService.Abstractions
{
    public interface IDataService
    {
        Response ProcessIncomingShowJsonString(Root root);
    }
}
