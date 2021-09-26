using Microsoft.EntityFrameworkCore;
using oag.Core.Data.Interfaces;
using oag.Core.Data.Models;

namespace oag.Core.Data.Contexts
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Fonds> Fonds { get; set; }
    }
}
