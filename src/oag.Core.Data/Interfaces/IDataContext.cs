using Microsoft.EntityFrameworkCore;
using oag.Core.Data.Models;

namespace oag.Core.Data.Interfaces
{
    public interface IDataContext
    {
        public DbSet<Fonds> Fonds { get; set; }
    }
}
