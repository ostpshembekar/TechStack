using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechStack.Models
{
    // Step 1: Create the model
    public class Catalog
    {
        // POCO: Plain old C# objects (POJO: Plain old Java objects)
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Vendor { get; set; }

        public string LatestVersion { get; set; }

    }
}
