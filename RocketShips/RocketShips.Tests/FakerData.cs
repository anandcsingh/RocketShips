using Bogus;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using RocketShips.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RocketShips.Tests
{
    public class FakerData
    {

        #region Ooooo

       AdventureWorksContext context;
        public FakerData()
        {

            var optionsBuilder = new DbContextOptionsBuilder<AdventureWorksContext>();
            optionsBuilder.UseSqlServer(connection);
            context = new AdventureWorksContext(optionsBuilder.Options);
        }
        #endregion

        [Fact]
        public void GenerateData()
        {
            var bulkConfig = new BulkConfig { SetOutputIdentity = true, BatchSize = 4000 };

            //var fakeCustomers = new Faker<Customer>()
            //    .RuleFor(c => c.Title, f => f.Name.Prefix())
            //    .RuleFor(c => c.FirstName, f => f.Name.FirstName())
            //    .RuleFor(c => c.LastName, f => f.Name.LastName())
            //    .RuleFor(c => c.CompanyName, f => f.Company.CompanyName())
            //    .RuleFor(c => c.SalesPerson, f => f.Internet.Email())
            //    .RuleFor(c => c.EmailAddress, f => f.Internet.Email())
            //    .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber())
            //    .RuleFor(c => c.PasswordHash, f => f.Random.Hash())
            //    .RuleFor(c => c.PasswordSalt, f => f.Random.AlphaNumeric(8))
            //    .RuleFor(c => c.Rowguid, f => Guid.NewGuid());


            //var customerResult = fakeCustomers.Generate(3000);
            //context.BulkInsert(customerResult, bulkConfig);

            var customerDB = context.Customers.ToList();

            //var fakeAddresses = new Faker<Address>()
            //   .RuleFor(c => c.AddressLine1, f => f.Address.StreetAddress())
            //   .RuleFor(c => c.City, f => f.Address.City())
            //   .RuleFor(c => c.StateProvince, f => "Washington")
            //   .RuleFor(c => c.CountryRegion, f => "United States")
            //   .RuleFor(c => c.Rowguid, f => Guid.NewGuid())
            //   .RuleFor(c => c.PostalCode, f => f.Address.ZipCode());

            //var addressesResult = fakeAddresses.Generate(10000);
            //context.BulkInsert(addressesResult, bulkConfig);
            var addressDB = context.Addresses.ToList();


            var fakeCustomerAddresses = new Faker<CustomerAddress>()
               .RuleFor(c => c.Rowguid, f => Guid.NewGuid())
               .RuleFor(c => c.AddressType, f => "Office")
               .RuleFor(c => c.Address, f => f.PickRandom(addressDB))
               .RuleFor(c => c.Customer, f => f.PickRandom(customerDB));

            var customerAddressesResult = fakeCustomerAddresses.Generate(10000);

            //context.BulkInsert(customerAddressesResult, bulkConfig);

            foreach (var item in customerAddressesResult)
            {
                context.CustomerAddresses.Add(item);
                context.SaveChanges();
            }
        }
    }
}
