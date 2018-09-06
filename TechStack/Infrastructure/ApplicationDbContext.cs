using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStack.Models;

namespace TechStack.Infrastructure
{
    // Step 2: Create a context to talk to a datastore
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Catalog> Catalog { get; set; }
    }
}
