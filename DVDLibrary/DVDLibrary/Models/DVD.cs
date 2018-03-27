using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDLibrary.Models
{
    public class DVD
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public string Notes { get; set; }
    }
}