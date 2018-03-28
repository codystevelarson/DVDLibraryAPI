using DvdModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdData
{
    public class DvdLibraryEntities : DbContext
    {
        public DvdLibraryEntities() : base("DvdLibraryEF")
        {
        }

        public DbSet<Dvd> Dvds { get; set; }
    }
}
