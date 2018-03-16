using DataService.Abstractions;

namespace NineWebService.Models
{
    /// <summary>
    /// Data model for Show describing data to be sent as part of the response
    /// </summary>
    /// <remarks>Implements Response abstract class</remarks>
    public class Show : Response
    {
        public string Image { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
    }
}
