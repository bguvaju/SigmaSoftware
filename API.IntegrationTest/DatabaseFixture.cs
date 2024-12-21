using API.IntegrationTest.SeedData;
using Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace API.IntegrationTest
{
    public class DatabaseFixture
    {
        public ApplicationDbContext CreateDbContext(IServiceScope serviceScope)
        {
            var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            SeedData(dbContext);
            return dbContext;
        }
        public void SeedData(ApplicationDbContext dbContext)
        {
            CandidateData.AgentsSeedData(dbContext);
            dbContext.SaveChanges();
        }
    }
}
