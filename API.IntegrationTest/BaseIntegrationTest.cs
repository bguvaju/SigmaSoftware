using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Data;
using Microsoft.Extensions.DependencyInjection;

namespace API.IntegrationTest
{
    public class BaseIntegrationTest
    {

        protected readonly WebApplicationFactoryTest _applicationFactory;
        protected readonly DatabaseFixture _databaseFixture;
        protected ApplicationDbContext _context;
        protected HttpClient _client;
        protected HttpClient _loginClient;

        public BaseIntegrationTest(string dbName)
        {
            _applicationFactory = new WebApplicationFactoryTest(dbName);
            CreateDbContext();
            HttpClientConfiguration();
            LoginClientConfiguration();
        }
        public void CreateDbContext()
        {
            var serviceScope = _applicationFactory.Services.CreateScope();
            _context = _databaseFixture.CreateDbContext(serviceScope);
        }

        void HttpClientConfiguration()
        {
            _client = _applicationFactory.CreateClient();
        }
        void LoginClientConfiguration()
        {
            _loginClient = _applicationFactory.CreateClient();
        }
    }
}
