using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrarys.Model
{
    public class Dvd
    {
        [Key]
        public int DvdId { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Rating { get; set; }
        public string DirectorName { get; set; }
    }
}
