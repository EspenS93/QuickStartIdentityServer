using QuickStartIdentityServer.Models.AccountViewModels;
using QuickStartIdentityServer.Models.AdminViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuickStartIdentityServer.Models
{
    [Table("People")]
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Telephone { get; set; }
        public string MobilePhone { get; set; }
        public ApplicationUser User { get; set; }

        public Person()
        {
            Id = Guid.NewGuid();
        }

        public Person(RegisterViewModel model)
        {
            Id = Guid.NewGuid();
            FirstName = model.FirstName;
            LastName = model.LastName;
            BirthDate = model.BirthDate;
            Gender = model.Gender;
            Address = model.Address;
            ZipCode = model.ZipCode;
            City = model.City;
            Telephone = model.Telephone;
            MobilePhone = model.MobilePhone;
        }
    }
}
