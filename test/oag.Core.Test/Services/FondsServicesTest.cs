using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using oag.Core.Data.Models;
using Microsoft.EntityFrameworkCore;
using oag.Core.Interfaces;
using oag.Core.Data.Interfaces;
using oag.Core.Services;
using oag.Core.Data.Contexts;
using oag.Core.Data.Repositories;
using oag.Core.Fakes.Repositories;

namespace oag.Core.Test.Services
{
    public class FondsServicesTest
    {
        private IEnumerable<Fonds> data;
        private FondsService service;

        public FondsServicesTest()
        {
            this.service = new FondsService(new FondsRepositoryMock().Object);
        }

        [Fact]
        public void Should_FindThreeFonds_When_GetAllFonds()
        {
            // Arrange

            // Act
            var fonds = this.service.GetAll();

            // Assert
            Assert.Equal(3, fonds.Count());
        }

        [Fact]
        public async void Should_GetAddedFonds_When_AddFondsAndGetBySignature()
        {
            // Arrange
            var fondsToAdd = new Fonds
            {
                Id = Guid.NewGuid(),
                Signature = "GXA",
                Name = "Gemeinlebarner XUnit Archive"
            };

            // Act
            await this.service.CreateAsync(fondsToAdd);
            var fonds = this.service.GetBySignature("GXA");

            // Assert
            Assert.Equal(4, this.service.GetAll().Count());
            Assert.Equal(fondsToAdd.Id, fonds.Id);
            Assert.Equal(fondsToAdd.Signature, fonds.Signature);
            Assert.Equal(fondsToAdd.Name, fonds.Name);
        }

        [Fact]
        public void Should_HaveNewNameAndSignature_When_UpdateFonds()
        {
            // Arrange
            var oldFonds = new Fonds { Id = new Guid("093aa90c-7b7f-4942-b64f-6dbdb31bc36f"), Signature = "GOA", Name = "Gemeinlebarner Ortsarchiv" };
            var newFonds = new Fonds { Id = new Guid("093aa90c-7b7f-4942-b64f-6dbdb31bc36f"), Signature = "GXA", Name = "Gemeinlebarner XUnit Archive" };

            // Act
            this.service.Update(newFonds);
            var fonds = this.service.GetById(new Guid("093aa90c-7b7f-4942-b64f-6dbdb31bc36f"));

            // Assert
            Assert.Equal(oldFonds.Id, fonds.Id);
            Assert.Equal(newFonds.Signature, fonds.Signature);
            Assert.Equal(newFonds.Name, fonds.Name);
        }

        [Fact]
        public void Should_CountOneFondsLess_When_RemoveFonds()
        {
            // Arrange
            var fondsToRemove = new Fonds { Id = new Guid("093aa90c-7b7f-4942-b64f-6dbdb31bc36f"), Signature = "GOA", Name = "Gemeinlebarner Ortsarchiv" };

            // Act
            this.service.Delete(fondsToRemove);
            var fonds = this.service.GetBySignature("GOA");

            // Assert
            Assert.Equal(2, this.service.GetAll().Count());
            Assert.Null(service.GetBySignature("GOA"));
        }
    }
}
