using Microsoft.EntityFrameworkCore;
using DatabaseEntityLib;
using System.Reflection.Emit;

namespace DataBaseContext
{
    public class DB_Context_Class : DbContext
    {
        public DbSet<Predmet> Predmet { get; set; }
        public DbSet<Oblast> Oblast { get; set; }
        public DbSet<Zadatak> Zadatak { get; set; }
        public DbSet<NivoTezine> NivoTezine { get; set; }

        public DB_Context_Class(DbContextOptions<DB_Context_Class> options) : base(options)
        {

        }

        
    }
}