using DataService.Abstractions;

namespace NineWebService.Models
{
    public class Show : Response
    {
        public string Image { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
    }
}
