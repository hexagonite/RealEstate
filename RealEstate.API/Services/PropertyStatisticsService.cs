using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstate.API.Contexts;
using RealEstate.API.DTOs;
using RealEstate.API.Entities;
using static System.Decimal;

namespace RealEstate.API.Services;

public class PropertyStatisticsService : IPropertyStatisticsService
{
    private readonly IPropertyTypeService _propertyTypeService;
    private readonly IRealEstateContext _dbContext;

    public PropertyStatisticsService(IPropertyTypeService propertyTypeService, IRealEstateContext dbContext)
    {
        _propertyTypeService = propertyTypeService;
        _dbContext = dbContext;
    }

    public async Task<PropertyStatisticsDto> GetPropertyStatistics(PropertyStatisticsQueryDto propertyStatisticsQueryDto)
    {
        var propertyType = await _propertyTypeService.GetPropertyType(propertyStatisticsQueryDto.PropertyType);

        var propertiesQuery = _dbContext.Properties.Where(x => x.PropertyType == propertyType);
        if (propertyStatisticsQueryDto.StartDateTime != null)
        {
            propertiesQuery = propertiesQuery.Where(x => x.UploadedAt >= propertyStatisticsQueryDto.StartDateTime);
        }
        if (propertyStatisticsQueryDto.EndDateTime != null)
        {
            propertiesQuery = propertiesQuery.Where(x => x.UploadedAt <= propertyStatisticsQueryDto.EndDateTime);
        }

        var propertiesForStatistics = await propertiesQuery.ToListAsync();

        if (propertiesForStatistics.Count > 0)
        {
            return new PropertyStatisticsDto()
            {
                AveragePrice = CalculateAveragePrice(propertiesForStatistics),
                AveragePricePerSquareMeter = CalculateAveragePriceForSquareMeter(propertiesForStatistics)
            };
        }
        else
        {
            return new PropertyStatisticsDto();
        }

    }

    private decimal CalculateAveragePrice(ICollection<Property> properties)
    {
        return Round(properties.Average(x => x.Price), 2);
    }

    private decimal CalculateAveragePriceForSquareMeter(ICollection<Property> properties)
    {
        return Round(properties.Sum(x => x.Price) / properties.Sum(x => x.Size), 2);
    }


}