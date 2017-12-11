using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuickStartIdentityServer.Models
{
    [Table("Specials")]
    public class Special
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Product Product{ get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public double Price { get; set; }
    }
}
