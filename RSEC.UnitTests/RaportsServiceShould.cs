using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using RSEC.Data;
using RSEC.Models;
using RSEC.Services;
using Microsoft.EntityFrameworkCore;

using Xunit;
using Microsoft.AspNetCore.Identity;

namespace RSEC.UnitTests
{
    public class RaportsServiceShould
    {

        [Fact]
        public async Task AddNewRaportAsIncompleteWithDueDate()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_AddNewRaport").Options;
            // Set up a context (connection to the "DB") for writing 
            using (var context = new ApplicationDbContext(options))
            {
                var service = new RaportsService(context);
                var fakeUser = new IdentityUser//ApplicationUser
                {
                    Id = "fake-000",
                    UserName = "fake@example.com"
                };
                await service.AddRaportAsync(new Raport {
                    Id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"),
                    BusNumber = "TestingNumber",
                    EnergyConsumed = 999,
                    ChargingTime = 100,
                    ChargingPower ="TestPower"
                });
            }

            // Use a separate context to read the data back from the DB
            using (var inMemoryContext = new ApplicationDbContext(options))
            {
                Assert.Equal(1, await inMemoryContext.Raports.CountAsync());

                var item = await inMemoryContext.Raports.FirstAsync();
                Assert.Equal(Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"), item.Id);
                Assert.Equal("TestingNumber", item.BusNumber);
                Assert.Equal(999, item.EnergyConsumed);
                Assert.Equal(100.ToString(), item.ChargingTime.ToString());
                Assert.Equal("TestPower", item.ChargingPower);

            }

        }

    }
}
