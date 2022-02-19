using FluentValidation;
using RealEstate.API.Services;

namespace RealEstate.API.DTOs.Validators
{
    public class PropertyStatisticsQueryDtoValidator : AbstractValidator<PropertyStatisticsQueryDto>
    {
        public PropertyStatisticsQueryDtoValidator(IPropertyTypeService propertyTypeService)
        {
            RuleFor(p => p.PropertyType).NotEmpty()
                .MustAsync(async (propertyTypeName, cancellation) => await propertyTypeService.PropertyTypeExists(propertyTypeName));
        }
    }
}
