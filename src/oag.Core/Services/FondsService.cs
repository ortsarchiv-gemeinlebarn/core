using oag.Core.Interfaces;
using oag.Core.Data.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using oag.Core.Data.Interfaces;
using System.Collections.Generic;

namespace oag.Core.Services
{
    public class FondsService : IFondsService
    {
        private readonly IFondsRepository fondsRepository;

        public FondsService(IFondsRepository fondsRepository)
        {
            this.fondsRepository = fondsRepository;
        }

        public async Task<Fonds> CreateAsync(Fonds fonds)
        {
            this.fondsRepository.Create(fonds);
            await this.fondsRepository.SaveAsync();
            return fonds;
        }

        public Fonds Delete(Fonds fond)
        {
            return fondsRepository.Delete(fond);
        }

        public IEnumerable<Fonds> GetAll()
        {
            return fondsRepository.ReadAll();
        }

        public Fonds GetById(Guid id)
        {
            return fondsRepository.ReadByCondition(fonds => fonds.Id == id).Single();
        }

        public Fonds GetBySignature(string signature)
        {
            try
            {
                return fondsRepository.ReadByCondition(fonds => fonds.Signature == signature).Single();
            }
            catch(InvalidOperationException)
            {
                return null;
            }
        }

        public Fonds Update(Fonds fond)
        {
            return fondsRepository.Update(fond);
        }
    }
}
