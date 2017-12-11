using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace QuickStartIdentityServer.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public Person Person { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public List<License> Licenses { get; set; }
        public List<Product> Products { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}
