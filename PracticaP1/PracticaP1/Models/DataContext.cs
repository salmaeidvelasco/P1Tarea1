using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PracticaP1.Models
{
    public class DataContext:DbContext
    {
        public DataContext(): base ("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<PracticaP1.Models.Eid> Eids { get; set; }
    }
}