using DataService.Abstractions;
using NineWebService.Models;
using System.Collections.Generic;
using System.Linq;

namespace NineWebService.Services
{
    public class RequestDataProcessor : IDataProcessor<Payload>
    {
        public IEnumerable<Response> ProcessRequestData(IEnumerable<Payload> requestData)
        {
            var requestDataArray = requestData.ToArray();

            Payload[] payload = new Payload[requestDataArray.Length];

            for (int i = 0; i < requestDataArray.Length ; i++)
            {
                payload[i] = requestDataArray[i];
            }

            Show[] shows = payload
                .Where(p => p.Drm == true && p.EpisodeCount > 0)
                .Select(p => new Show { Image = p.Image.ShowImage, Slug = p.Slug, Title = p.Title })
                .ToArray();

            return shows;
        }
    }
}
