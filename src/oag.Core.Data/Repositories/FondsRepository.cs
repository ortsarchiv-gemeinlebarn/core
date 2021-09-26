using Microsoft.EntityFrameworkCore;
using oag.Core.Data.Contexts;
using oag.Core.Data.Interfaces;
using oag.Core.Data.Models;

namespace oag.Core.Data.Repositories
{
    public class FondsRepository : Repository<Fonds>, IFondsRepository
    {
        public FondsRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
