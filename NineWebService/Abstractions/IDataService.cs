using NineWebService.Models;

namespace NineWebService.Abstractions
{
    public interface IDataService
    {
        Response ProcessIncomingShowData(RequestData requestData);
    }
}
