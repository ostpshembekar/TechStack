using System.Linq;
using Xunit;
using TechStack.Pages.Catalog;
using Microsoft.EntityFrameworkCore;
using TechStack.Infrastructure;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TechStack.Tests.Catalog
{
    public class CatalogTests
    {
        [Fact]
        public async void ShouldAddNewCatalogEntry()
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

            await createmodel.OnPostCreateAsync();

            Assert.True(context.Catalog.Any());
        }

        // Adding multiple rows
        [Fact]
        public async void ShouldGiveCorrectID()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("MyConnection1");
            var context = new ApplicationDbContext(optionsBuilder.Options);
            var createmodel = new CreateModel(context);

            //foreach (var entity in context.Catalog)
            //    context.Catalog.Remove(entity);
            //context.SaveChanges();

            var catalog = new Models.Catalog();
            catalog.Id = 1;
            catalog.Name = ".NET Core";
            catalog.Vendor = "Microsoft";
            catalog.LatestVersion = "2.1";
            
            createmodel.Catalog = catalog;
            await createmodel.OnPostCreateAsync();

            catalog = new Models.Catalog();
            catalog.Id = 2;
            catalog.Name = "Java";
            catalog.Vendor = "Oracle";
            catalog.LatestVersion = "10.0.2";

            createmodel.Catalog = catalog;
            await createmodel.OnPostCreateAsync();

            Assert.Equal(2, context.Catalog.Max(item => item.Id));
        }

    }
}
