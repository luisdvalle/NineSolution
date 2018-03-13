﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NineWebService.Models
{
    public class NextEpisode
    {
        public string Channel { get; set; }
        public string ChannelLogo { get; set; }
        public DateTime Date { get; set; }
        public string Html { get; set; }
        public string Url { get; set; }
    }
}
