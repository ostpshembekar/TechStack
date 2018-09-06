using System.Linq;
using Xunit;
using TechStack.Pages.Catalog;
using Microsoft.EntityFrameworkCore;
using TechStack.Infrastructure;


namespace TechStack.Tests.Catalog
{
    public class CatalogTests
    {
        [Fact]
        public void ShouldAddNewCatalogEntry()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("MyConnection");
            var context = new ApplicationDbContext(optionsBuilder.Options);

            var catalog = new Models.Catalog();
            catalog.Id = 1;
            catalog.Name = ".NET Core";
            catalog.Vendor = "Microsoft";
            catalog.LatestVersion = "2.1";

            var createmodel = new CreateModel(context);
            createmodel.Catalog = catalog;

            createmodel.OnPostCreate();

            Assert.True(context.Catalog.Any());
        }
    }
}
