using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Moq.EntityFrameworkCore;
using RealEstate.API.Contexts;
using RealEstate.API.DTOs;
using RealEstate.API.Entities;
using RealEstate.API.Services;
using Xunit;

namespace RealEstate.UnitTests
{
    public class PropertyStatisticsServiceTests
    {
        [Fact]
        public async Task GetPropertyStatistics_NoProperties_ReturnsEmptyStatistics()
        {
            var propertyTypeServiceMock = new Mock<IPropertyTypeService>();
            propertyTypeServiceMock.Setup(x => x.GetPropertyType(It.IsAny<string>())).ReturnsAsync((PropertyType)null!);
            var dbContextMock = new Mock<IRealEstateContext>();
            dbContextMock.Setup(x => x.Properties).ReturnsDbSet(new List<Property>());

            var propertyStatisticsService = new PropertyStatisticsService(propertyTypeServiceMock.Object, dbContextMock.Object);
            var result = await propertyStatisticsService.GetPropertyStatistics(new PropertyStatisticsQueryDto());

            result.Should().BeEquivalentTo(new PropertyStatisticsDto());
        }

        [Fact]
        public async Task GetPropertyStatistics_NoDatesInQuery_ReturnsStatistics()
        {
            var coopPropertyType = new PropertyType() { Name = "Co-op" };

            var properties = new List<Property>()
            {
                new()
                {
                    Price = 150_000,
                    Size = 70,
                    PropertyType = coopPropertyType,
                },
                new()
                {
                    Price = 250_000,
                    Size = 125,
                    PropertyType = coopPropertyType,
                },
            };

            var propertyTypeServiceMock = new Mock<IPropertyTypeService>();
            propertyTypeServiceMock.Setup(x => x.GetPropertyType(coopPropertyType.Name))
                .ReturnsAsync(coopPropertyType);
            var dbContextMock = new Mock<IRealEstateContext>();
            dbContextMock.Setup(x => x.Properties).ReturnsDbSet(properties);

            var propertyStatisticsService = new PropertyStatisticsService(propertyTypeServiceMock.Object, dbContextMock.Object);
            var result = await propertyStatisticsService.GetPropertyStatistics(new PropertyStatisticsQueryDto() { PropertyType = coopPropertyType.Name });

            result.Should().BeEquivalentTo(new PropertyStatisticsDto() { AveragePrice = 200_000, AveragePricePerSquareMeter = 2051.28M });
        }

        [Fact]
        public async Task GetPropertyStatistics_BothDatesInQuery_ReturnsStatistics()
        {
            var coopPropertyType = new PropertyType() { Name = "Co-op" };

            var properties = new List<Property>()
            {
                new()
                {
                    UploadedAt = new DateTime(2022, 2, 17, 0, 0, 0, DateTimeKind.Utc),
                    Price = 150_000,
                    Size = 70,
                    PropertyType = coopPropertyType,
                },
                new()
                {
                    UploadedAt = new DateTime(2022, 2, 18, 0, 0, 0, DateTimeKind.Utc),
                    Price = 250_000,
                    Size = 125,
                    PropertyType = coopPropertyType,
                },
                new()
                {
                    UploadedAt = new DateTime(2022, 2, 19, 0, 0, 0, DateTimeKind.Utc),
                    Price = 300_000,
                    Size = 123,
                    PropertyType = coopPropertyType,
                },
            };

            var propertyTypeServiceMock = new Mock<IPropertyTypeService>();
            propertyTypeServiceMock.Setup(x => x.GetPropertyType(coopPropertyType.Name))
                .ReturnsAsync(coopPropertyType);
            var dbContextMock = new Mock<IRealEstateContext>();
            dbContextMock.Setup(x => x.Properties).ReturnsDbSet(properties);

            var propertyStatisticsService = new PropertyStatisticsService(propertyTypeServiceMock.Object, dbContextMock.Object);
            var propertyStatisticsQueryDto = new PropertyStatisticsQueryDto()
            {
                PropertyType = coopPropertyType.Name,
                StartDateTime = new DateTime(2022, 2, 17, 0, 0, 0, DateTimeKind.Utc),
                EndDateTime = new DateTime(2022, 2, 18, 0, 0, 0, DateTimeKind.Utc),
            };
            var result = await propertyStatisticsService.GetPropertyStatistics(propertyStatisticsQueryDto);

            result.Should().BeEquivalentTo(new PropertyStatisticsDto() { AveragePrice = 200_000, AveragePricePerSquareMeter = 2051.28M });
        }

        [Fact]
        public async Task GetPropertyStatistics_TwoPropertyTypesAndNoDatesInQuery_ReturnsStatistics()
        {
            var coopPropertyType = new PropertyType() { Name = "Co-op" };
            var flatPropertyType = new PropertyType() { Name = "Flat" };

            var properties = new List<Property>()
            {
                new()
                {
                    Price = 150_000,
                    Size = 70,
                    PropertyType = coopPropertyType,
                },
                new()
                {
                    Price = 250_000,
                    Size = 125,
                    PropertyType = coopPropertyType,
                },
                new()
                {
                    Price = 195_000,
                    Size = 79,
                    PropertyType = flatPropertyType,
                },
            };

            var propertyTypeServiceMock = new Mock<IPropertyTypeService>();
            propertyTypeServiceMock.Setup(x => x.GetPropertyType(coopPropertyType.Name))
                .ReturnsAsync(coopPropertyType);
            var dbContextMock = new Mock<IRealEstateContext>();
            dbContextMock.Setup(x => x.Properties).ReturnsDbSet(properties);

            var propertyStatisticsService = new PropertyStatisticsService(propertyTypeServiceMock.Object, dbContextMock.Object);
            var result = await propertyStatisticsService.GetPropertyStatistics(new PropertyStatisticsQueryDto() { PropertyType = coopPropertyType.Name });

            result.Should().BeEquivalentTo(new PropertyStatisticsDto() { AveragePrice = 200_000, AveragePricePerSquareMeter = 2051.28M });
        }

    }
}