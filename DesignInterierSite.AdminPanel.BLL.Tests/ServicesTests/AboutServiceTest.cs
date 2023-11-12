using Microsoft.EntityFrameworkCore;

namespace DesignInterierSite.AdminPanel.BLL.Tests.ServicesTests
{
    public class AboutServiceTest
    {
        AboutService aboutService;

        TestDbContext context;

        public AboutServiceTest()
        {
            var options = new DbContextOptionsBuilder<AppDataContext>().UseInMemoryDatabase("about").Options;

            context = new TestDbContext(options);

            context.Database.EnsureDeleted();

            aboutService = new AboutService(context);
        }

        [Fact]
        public async Task GetAboutAsync_ThereIsData()
        {
            await context.AboutModel.AddAsync(new AboutModel()
            {
                Title = "Test",
                Text = "Test",
                Image = new ImagesModel() { Name = "Test" }
            });

            await context.SaveChangesAsync();

            var result = await aboutService.GetAboutAsync();

            Assert.NotNull(result.AboutModel);
        }

        [Fact]
        public async Task GetAboutAsync_NoData()
        {
            var result = await aboutService.GetAboutAsync();

            Assert.Null(result.AboutModel);
        }

        [Fact]
        public async Task AddNewAboutAsync_SuccessfulAddition()
        {
            var aboutPageModel = new AboutPageModel()
            {
                AboutModel = new AboutModel()
                {
                    Title = "Test",
                    Text = "Test",
                    Image = new ImagesModel()
                    {
                        Name = "Test"
                    }
                }
            };

            await aboutService.AddNewAboutAsync(aboutPageModel);

            var result = await context.AboutModel.FirstOrDefaultAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddNewAboutAsync_Throws_NullReferenceException()
        {
            var aboutPageModel = new AboutPageModel();

            await Assert.ThrowsAsync<NullReferenceException>(async () => { await aboutService.AddNewAboutAsync(aboutPageModel); });
        }

        [Fact]
        public async Task AddNewAboutAsync_Throws_DbUpdateException()
        {
            var aboutPageModel = new AboutPageModel()
            {
                AboutModel = new AboutModel()
            };

            await Assert.ThrowsAsync<DbUpdateException>(async () => { await aboutService.AddNewAboutAsync(aboutPageModel); });
        }
    }
}