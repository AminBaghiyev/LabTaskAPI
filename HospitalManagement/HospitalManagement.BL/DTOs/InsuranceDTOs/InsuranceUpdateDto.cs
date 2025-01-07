using FluentValidation;

namespace HospitalManagement.BL.DTOs;

public record InsuranceUpdateDto
{
    public int Id { get; set; }
    public string PersonInsurance { get; set; }
    public float Discount { get; set; }
}

public class InsuranceUpdateDtoValidation : AbstractValidator<InsuranceUpdateDto>
{
    public InsuranceUpdateDtoValidation()
    {
        RuleFor(e => e.Id)
            .GreaterThan(0).WithMessage("Id must be positive number!");

        RuleFor(e => e.PersonInsurance)
            .NotEmpty().NotNull().WithMessage("PersonInsurance should be written!");

        RuleFor(e => e.Discount)
            .GreaterThanOrEqualTo(0).WithMessage("Discount must be 0 or positive number!");
    }
}