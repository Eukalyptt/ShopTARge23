using ShopTARge23.Core.Dto;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Core.Domain;
using ShopTARge23.ApplicationServices;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace ShopTARge23.KindergartenTests
{
    public class KindergartenTests
    {
        [Fact]
        public void ShouldAddKindergartenToList()
        {
            // arrange

            var repository = new List<KindergartenDto>();
            var kindergarten = new KindergartenDto
            {
                KindergartenName = "uus nimi",
                GroupName = "uus grupi nimi",
                Teacher = "uus õpetaja",
                ChildrenCount = 222,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            // act

            repository.Add(kindergarten);

            // assert

            Assert.Single(repository); // kontrollib et listis on aint 1 element
            Assert.Contains(kindergarten, repository); // kontrollib kas lisati
        }

        [Fact]
        public void ShouldGetKindergartenById()
        {
            // arrange 

            var id = Guid.NewGuid();
            var repository = new List<KindergartenDto>
            {
                new KindergartenDto
                {
                    Id = id,
                    KindergartenName = "uus nimi",
                    GroupName = "uus grupi nimi",
                    Teacher = "uus õpetaja",
                    ChildrenCount = 222,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                }
            };

            // act 

            var result = repository.FirstOrDefault(k => k.Id == id);

            // assert

            Assert.NotNull(result); // leiab elemendi
            Assert.Equal(id, result.Id); // kontrollib kas id vastab oodatule
        }

        [Fact]
        public void ShouldUpdateKindergartenProperties()
        {
            // arrange

            var id = Guid.NewGuid();
            var kindergarten = new KindergartenDto
            {
                Id = id,
                KindergartenName = "uus nimi",
                GroupName = "uus grupi nimi",
                Teacher = "uus õpetaja",
                ChildrenCount = 222,
            };

            var repository = new List<KindergartenDto> { kindergarten };

            // act

            var entityToUpdate = repository.FirstOrDefault(k => k.Id == id);
            entityToUpdate.KindergartenName = "Jõelähtme";
            entityToUpdate.ChildrenCount = 20;


            // assert

            Assert.Equal("Jõelähtme", entityToUpdate.KindergartenName); // kontrollib nime vahetust
            Assert.Equal(20, entityToUpdate.ChildrenCount); // kontrollib uut laste arvu
        }

        [Fact]
        public void ShouldDeleteKindergartenFromList()
        {
            // arrange

            var id = Guid.NewGuid();
            var kindergarten = new KindergartenDto
            {
                Id = id,
                KindergartenName = "uus nimi"
            };
            var repository = new List<KindergartenDto> { kindergarten };

            // act
            var entityToRemove = repository.FirstOrDefault(k => k.Id == id);
            repository.Remove(entityToRemove);

            // assert
            Assert.Empty(repository); // kontrollib kas list tühi
        }
    }
}