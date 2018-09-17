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


        [Fact]
        public async void ShouldEditExistingCatalogEntry()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("MyConnection");
            var context = new ApplicationDbContext(optionsBuilder.Options);

            var catalog = new Models.Catalog();
            catalog.Id = 2;
            catalog.Name = ".NET Core";
            catalog.Vendor = "Microsoft";
            catalog.LatestVersion = "2.1";

            var createmodel = new CreateModel(context);
            createmodel.Catalog = catalog;

            await createmodel.OnPostCreateAsync();

            var newcatalog = new Models.Catalog();
            newcatalog.Id = 2;
            newcatalog.Name = ".NET Core";
            newcatalog.Vendor = "Microsoft .NET";
            newcatalog.LatestVersion = "2.1";

            var editmodel = new EditModel(context);
            editmodel.Catalog = newcatalog;

            await editmodel.OnPostAsync();

            Assert.Equal("Microsoft .NET", context.Catalog.Find(2).Vendor);

        }

        //// Do not provide Name
        //[Fact]
        //public async void ShouldThrowExceptionOnEmptyName()
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        //    optionsBuilder.UseInMemoryDatabase("MyConnection");
        //    var context = new ApplicationDbContext(optionsBuilder.Options);

        //    var catalog = new Models.Catalog();
        //    catalog.Id = 2;
        //    catalog.Name = "";
        //    catalog.Vendor = "Microsoft";
        //    catalog.LatestVersion = "2.1";

        //    var createmodel = new CreateModel(context);
        //    createmodel.Catalog = catalog;

        //    var result = await createmodel.OnPostCreateAsync();

        //    Assert.NotNull(result);
        //    Assert.IsType<BadRequestObjectResult>(result);
        //}


    }
}
