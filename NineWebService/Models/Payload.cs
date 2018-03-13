using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NineWebService.Models
{
    public class Payload
    {
        public string Country { get; set; }
        public string Description { get; set; }
        public bool Drm { get; set; }
        public int EpisodeCount { get; set; }
        public string Genre { get; set; }
        public Image Image { get; set; }
        public string Language { get; set; }
        public NextEpisode NextEpisode { get; set; }
        public string PrimaryColour { get; set; }
        public Season[] Seasons { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string TvChannel { get; set; }
    }
}
