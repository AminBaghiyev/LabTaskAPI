using FluentValidation;

namespace HospitalManagement.BL.DTOs;

public record InsuranceCreateDto
{
    public string PersonInsurance { get; set; }
    public float Discount { get; set; }
}

public class InsuranceCreateDtoValidation : AbstractValidator<InsuranceCreateDto>
{
    public InsuranceCreateDtoValidation()
    {
        RuleFor(e => e.PersonInsurance)
            .NotEmpty().NotNull().WithMessage("PersonInsurance should be written!");

        RuleFor(e => e.Discount)
            .GreaterThanOrEqualTo(0).WithMessage("Discount must be positive number!");
    }
}