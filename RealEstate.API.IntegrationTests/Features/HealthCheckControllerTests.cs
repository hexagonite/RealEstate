using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace RealEstate.API.IntegrationTests.Features
{
    public class HealthCheckControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public HealthCheckControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task Get_ReturnsHealthy()
        {
            var response = await _client.GetAsync("api/healthcheck");
            var content = await response.Content.ReadAsStringAsync();

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            content.Should().Be("Healthy");
        }
    }
}
