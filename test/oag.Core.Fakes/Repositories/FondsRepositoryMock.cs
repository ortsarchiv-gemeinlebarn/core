using Moq;
using oag.Core.Data.Interfaces;
using oag.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace oag.Core.Fakes.Repositories
{
    public class FondsRepositoryMock : Mock<IFondsRepository>
    {
        private List<Fonds> data = new List<Fonds>
        {
            new Fonds { Id = new Guid("093aa90c-7b7f-4942-b64f-6dbdb31bc36f"), Signature = "GOA", Name = "Gemeinlebarner Ortsarchiv" },
            new Fonds { Id = new Guid("8ced7a00-7dda-4d6f-8d45-2185178b1beb"), Signature = "GFA", Name = "Gemeinlebarner Feuerwehrarchiv" },
            new Fonds { Id = new Guid("a3121ac9-1807-48b5-b09d-3d6288bd5bd3"), Signature = "GSA", Name = "Gemeinlebarner Schularchiv" }
        };

        public FondsRepositoryMock()
        {
            this.Setup(r => r.Create(It.IsAny<Fonds>())).Returns((Fonds item) => {
                this.data.Add(item);
                return item;
            });

            this.Setup(r => r.Update(It.IsAny<Fonds>())).Returns((Fonds item) => {
                this.data.RemoveAt(this.data.FindIndex(f => f.Id == item.Id));
                this.data.Add(item);
                return item;
            });

            this.Setup(r => r.Delete(It.IsAny<Fonds>())).Returns((Fonds item) => {
                this.data.RemoveAll(f => f.Id == item.Id);
                return item;
            });

            this.Setup(r => r.ReadAll()).Returns(this.data.AsQueryable());
            this.Setup(r => r.ReadByCondition(It.IsAny<Expression<Func<Fonds, bool>>>())).Returns((Expression<Func<Fonds, bool>> exp) => this.data.AsQueryable().Where(exp));
        }
    }
}
