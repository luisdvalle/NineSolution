using DataService.Abstractions;
using NineWebService.Models;
using System.Collections.Generic;
using System.Linq;

namespace NineWebService.Services
{
    /// <summary>
    /// Implementatin of IDataProcessor to process Payload data
    /// </summary>
    public class RequestDataProcessor : IDataProcessor<Payload>
    {
        /// <summary>
        ///     Processes a set of Payload data, extracting required information to construct a set of Response 
        ///     objects
        /// </summary>
        /// <param name="requestData">Set of Payload data to be processed</param>
        /// <returns>Set of Show data with required information about Payload</returns>
        /// <remarks>Will process only Payload objects with DRM = True and EpisodeCount > 0</remarks>
        public IEnumerable<Response> ProcessRequestData(IEnumerable<Payload> requestData)
        {
            Show[] shows = requestData
                .Where(p => p.Drm == true && p.EpisodeCount > 0)
                .Select(p => new Show { Image = p.Image.ShowImage, Slug = p.Slug, Title = p.Title })
                .ToArray();

            return shows;
        }
    }
}
