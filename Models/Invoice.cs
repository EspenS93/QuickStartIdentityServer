using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuickStartIdentityServer.Models
{
    [Table("Invoices")]
    public class Invoice
    {
        public Guid? Id { get; set; }
        public ApplicationUser User { get; set; }
        public double Total { get; set; }
        public double SentDate { get; set; }
        public double LastDate { get; set; }
        public bool Paid { get; set; }
    }
}
