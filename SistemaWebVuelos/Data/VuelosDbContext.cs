using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SistemaWebVuelos.Models;

namespace SistemaWebVuelos.Data
{
    public class VuelosDbContext: DbContext
    {
        public VuelosDbContext() : base("KeyDB") { }
        public DbSet<Vuelo> Vuelos { get; set; }
    }
}