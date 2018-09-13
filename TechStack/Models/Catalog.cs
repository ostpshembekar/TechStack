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

        [Required(ErrorMessage = "Please enter the name of the catalog")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the vendor of the catalog")]
        public string Vendor { get; set; }

        [Display(Name="Latest Version")]
        public string LatestVersion { get; set; }

    }
}
