using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using RealEstate.API.DTOs;
using Xunit;

namespace RealEstate.API.IntegrationTests.Features
{
    public class PropertiesControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public PropertiesControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>().ConfigureAppConfiguration(x=>x.AddJsonFile("appsettings.json").Build()));
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task Create_RandomProperty_ReturnsCreated()
        {
            var propertyTypes = await _client.GetFromJsonAsync<ICollection<PropertyTypeDto>>("/api/PropertyTypes");

            var propertyForCreationDto = new PropertyForCreationDto()
            {
                Address = new AddressForCreationDto()
                {
                    AddressLine1 = GetRandomGuidString(),
                    AddressLine2 = GetRandomGuidString(),
                    City = GetRandomGuidString(),
                    PostalCode = GetRandomGuidString(),
                    StateOrProvince = GetRandomGuidString(),
                },
                Description = GetRandomGuidString(),
                Price = 1_000_000,
                RoomAmount = 5,
                Size = 100,
                PropertyType = propertyTypes.First().Name,
            };

            var response = await _client.PostAsJsonAsync("api/properties", propertyForCreationDto);
            var propertyDto = await response.Content.ReadFromJsonAsync<PropertyDto>();

            response.StatusCode.Should().Be(HttpStatusCode.Created);
            propertyDto.Should().BeEquivalentTo(propertyForCreationDto);
            propertyDto.Id.Should().BeGreaterThan(0);
        }

        private string GetRandomGuidString()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
