using DreamJourneyAPI.Data;
using DreamJourneyAPI.Models;
using DreamJourneyAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace DreamJourneyAPI.Tests.Repositories
{
    public class DreamRepositoryTest
    {
        public DreamRepositoryTest()
        {

        }

        [Fact]
        public async Task GetAll_ShouldReturnListOfDreamModels()
        {
            //var fixture = new Fixture();
            //List<DreamModel> dreamModelss = fixture.CreateMany<DreamModel>(3).ToList();

            var dreamModels = new List<DreamModel>
            {
            new DreamModel { Id = 1, Name = "Dream1", Description = "User1" },
            new DreamModel { Id = 2, Name = "Dream2", Description = "User2" }
            }.AsQueryable();

            var dbSetMock = new Mock<DbSet<DreamModel>>();
            dbSetMock.As<IQueryable<DreamModel>>().Setup(m => m.Provider).Returns(dreamModels.Provider);
            dbSetMock.As<IQueryable<DreamModel>>().Setup(m => m.Expression).Returns(dreamModels.Expression);
            dbSetMock.As<IQueryable<DreamModel>>().Setup(m => m.ElementType).Returns(dreamModels.ElementType);
            dbSetMock.As<IQueryable<DreamModel>>().Setup(m => m.GetEnumerator()).Returns(dreamModels.GetEnumerator());

            var dbContextMock = new Mock<DreamJourneyDbContext>();
            dbContextMock.Setup(dbContext => dbContext.Set<DreamModel>()).Returns(dbSetMock.Object);

            var dreamRepository = new DreamRepository(dbContextMock.Object);
            var result = await dreamRepository.GetAll(0, 2);
            Assert.Equal(dreamModels.ToList(), result);
        }
    }
}

