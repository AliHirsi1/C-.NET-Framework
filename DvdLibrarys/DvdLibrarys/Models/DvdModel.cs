using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibrarys.Models
{
    public class DvdModel
    {
        public int DvdId { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Rating { get; set; }
        public string DirectorName { get; set; }

    }
}