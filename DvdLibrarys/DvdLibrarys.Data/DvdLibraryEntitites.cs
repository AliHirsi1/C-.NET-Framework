using DvdLibrarys.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrarys.Data
{
    class DvdLibraryEntitites : DbContext
    {
        public DvdLibraryEntitites()
            : base("DvdLibrary"){

        }

        public DbSet<Dvd> Dvd { get; set; }
    }
}
