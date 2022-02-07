using FluentValidation;

namespace RealEstate.API.DTOs.Validators;

public class AddressForManipulationDtoValidator : AbstractValidator<AddressForManipulationDto>
{
    public AddressForManipulationDtoValidator()
    {
        RuleFor(p => p.AddressLine1).NotEmpty().Length(3, 50);
        RuleFor(p => p.AddressLine2).NotEmpty().Length(3, 50);
        RuleFor(p => p.PostalCode).NotEmpty().Length(4, 10);
        RuleFor(p => p.StateOrProvince).NotEmpty().Length(2, 50);
        RuleFor(p => p.City).NotEmpty().Length(2, 50);
    }
}