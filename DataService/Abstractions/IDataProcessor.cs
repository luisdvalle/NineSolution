using System.Collections.Generic;

namespace DataService.Abstractions
{
    /// <summary>
    /// Provides a common definition for processing data
    /// </summary>
    public interface IDataProcessor<T>
    {
        /// <summary>
        /// Provides a definition for processing RequestData
        /// </summary>
        /// <param name="requestData">A set of requestData to be processed</param>
        /// <returns>A set of of Response data</returns>
        IEnumerable<Response> ProcessRequestData(IEnumerable<T> requestData);
    }
}
