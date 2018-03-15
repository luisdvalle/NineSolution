using System.Collections.Generic;

namespace DataService.Abstractions
{
    public interface IDataProcessor<T>
    {
        IEnumerable<Response> ProcessRequestData(IEnumerable<T> requestData);
    }
}
