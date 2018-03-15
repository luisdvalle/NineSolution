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
