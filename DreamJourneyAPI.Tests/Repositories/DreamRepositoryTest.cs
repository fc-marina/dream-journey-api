using DreamJourneyAPI.Data;
using DreamJourneyAPI.Models;
using DreamJourneyAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace DreamJourneyAPI.Tests.Repositories
{
    public class DreamRepositoryTest
    {
        //private Mock<ILogger<DreamJourneydbcontext>>? _mock;
        //private dreamjourneydbcontext? _context;
        //private dreamrepository _dreamrepository;

        //public Dreamrepositorytest()
        //{
        //    _mock = new Mock<ILogger<dreamjourneydbcontext>>();
        //    createdreamjourneydbcontext();

        //}

        //private void CreateDreamJourneyDbContext()
        //{
        //    var options = new DbContextOptionsBuilder<DreamJourneyDbContext>().Options;
        //    _context = (DreamJourneyDbContext)Activator.CreateInstance(typeof(DreamJourneyDbContext), new object[] { options });
        //    _context.Database.EnsureDeleted();
        //    _context.Database.EnsureCreated();
        //}

        //[Fact]
        //public async Task GetAll_ShouldReturnListOfDreamModels()
        //{
        //    var dream1 = new DreamModel { Id = 1, Name = "Dream 1", UserId = 1, Description = "Description", LifeArea= 0, Status= 0};
        //    var dream2 = new DreamModel { Id = 1, Name = "Dream 1", UserId = 1, Description = "Description", LifeArea = 0, Status = 0 };
        //    _context.DreamModel.AddRange(dream1, dream2);
        //    await _context.SaveChangesAsync();
        //    _dreamRepository = new DreamRepository(_context);
        //    var result = await _dreamRepository.GetAll(0, 2);

        //    Assert.Equal(2, result.Count);

        //}

        //private DreamRepository _dreamRepository;
        //private DreamJourneyDbContext _dbContext;

        //public DreamRepositoryTest()
        //{
        //    var options = new DbContextOptionsBuilder<DreamJourneyDbContext>()
        //        .UseInMemoryDatabase(databaseName: "TestDb")
        //        .Options;
        //    _dbContext = new DreamJourneyDbContext(options);

        //    _dreamRepository = new DreamRepository(_dbContext);
        //}

        //[Fact]
        //public async Task GetAll_ShouldReturList()
        //{

        //    var dream1 = new DreamModel { Id = 1, Name = "Dream 1", Description = "x", LifeArea = 0, Status = 0 };
        //    var dream2 = new DreamModel { Id = 2, Name = "Dream 2", Description = "y", LifeArea = 0, Status = 0 };
        //    _dbContext.DreamModel.AddRange(dream1, dream2);

        //    await _dbContext.SaveChangesAsync();

        //    var result = await _dreamRepository.GetAll(0, 2);

        //    Assert.Equal(2, result.Count);

        //    Assert.Equal("Dream 1", result[0].Name);
        //    Assert.Equal("Dream 2", result[1].Name);
        //}
    }
}
