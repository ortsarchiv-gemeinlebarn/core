using oag.Core.Data.Models;
using System;
using System.Threading.Tasks;

namespace oag.Core.Interfaces
{
    public interface IFondsService
    {
        Task<Fonds> CreateAsync(Fonds fond);
        Fonds GetById(Guid id);
        Fonds GetBySignature(string signature);
        Fonds Update(Fonds fond);
        Fonds Delete(Fonds fond);
    }
}
