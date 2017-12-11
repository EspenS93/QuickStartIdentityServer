using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickStartIdentityServer.Models.AdminViewModels
{
    public class ListViewModel
    {
        public string Name { get; set; }
        public List<string> Headers { get; set; }

        public List<IdentityRole> List { get; set; }
    }
}
