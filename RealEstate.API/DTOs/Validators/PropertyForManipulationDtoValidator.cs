using System.Threading.Tasks;
using FluentValidation;
using RealEstate.API.Services;

namespace RealEstate.API.DTOs.Validators
{
    public class PropertyForManipulationDtoValidator : AbstractValidator<PropertyForManipulationDto>
    {
        public PropertyForManipulationDtoValidator(IPropertyTypeService propertyTypeService)
        {
            RuleFor(p => p.Price).NotEmpty().GreaterThan(0).ScalePrecision(2, 18);
            RuleFor(p => p.Description).NotEmpty().Length(5, 2000);
            RuleFor(p => p.RoomAmount).NotEmpty().InclusiveBetween(1, 30);
            RuleFor(p => p.Size).NotEmpty().InclusiveBetween(2, 500_000);
            RuleFor(p => p.PropertyType).NotEmpty()
                .MustAsync(async (propertyTypeName, cancellation) => await propertyTypeService.PropertyTypeExists(propertyTypeName));
        }

    }
}
