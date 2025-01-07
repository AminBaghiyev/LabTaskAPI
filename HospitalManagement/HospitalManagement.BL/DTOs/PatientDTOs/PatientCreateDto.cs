using FluentValidation;
using HospitalManagement.Core.Enums;

namespace HospitalManagement.BL.DTOs;

public record PatientCreateDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime DOB { get; set; }
    public Gender Gender { get; set; }
    public BloodGroup BloodGroup { get; set; }
    public string PhoneNumber { get; set; }
    public string SeriaNumber { get; set; }
    public string RegistrationAddress { get; set; }
    public string CurrentAddress { get; set; }
    public int InsuranceId { get; set; }
    public string Email { get; set; }
}

public class PatientCreateDtoValidation : AbstractValidator<PatientCreateDto>
{
    public PatientCreateDtoValidation()
    {
        RuleFor(e => e.Name)
            .NotEmpty().NotNull().WithMessage("Name should be written!");

        RuleFor(e => e.Surname)
            .NotEmpty().NotNull().WithMessage("Surname should be written!");

        RuleFor(e => e.DOB)
            .Must(BeAValidAge).WithMessage("Age must be between 0 and 170 years old!");

        RuleFor(e => e.Gender)
            .Must(BeAValidGender).WithMessage("Invalid gender!");

        RuleFor(e => e.BloodGroup)
            .Must(BeAValidBloodGroup).WithMessage("Invalid blood group!");

        RuleFor(e => e.PhoneNumber)
            .Matches(@"^(?:\+994\s?|0)(50|51|55|70|77|10|99|60)\s?\d{3}\s?\d{2}\s?\d{2}$").WithMessage("Only Azerbaijani mobile phone numbers are valid!");

        RuleFor(e => e.SeriaNumber)
            .NotEmpty().NotNull().WithMessage("Seria number cannot be empty!")
            .Length(7, 7).WithMessage("Seria number must be 7 symbols long!");

        RuleFor(e => e.RegistrationAddress)
            .NotEmpty().NotNull().WithMessage("Registration address cannot be empty!");

        RuleFor(e => e.CurrentAddress)
            .NotEmpty().NotNull().WithMessage("Current address cannot be empty!");

        RuleFor(e => e.Email)
            .NotEmpty().NotNull().WithMessage("Email cannot be empty!")
            .EmailAddress().WithMessage("A valid email is required!")
            .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("A valid email is required!");
    }

    bool BeAValidGender(Gender gender)
    {
        return (gender == Gender.Male || gender == Gender.Female);
    }

    bool BeAValidBloodGroup(BloodGroup bloodGroup)
    {
        return Enum.IsDefined(typeof(BloodGroup), bloodGroup);
    }

    bool BeAValidAge(DateTime birthdate)
    {
        int age = CalculateAge(birthdate);
        return age >= 0 && age <= 170;
    }

    int CalculateAge(DateTime birthdate)
    {
        DateTime today = DateTime.Now;
        int age = today.Year - birthdate.Year;

        if (today.Month < birthdate.Month || (today.Month == birthdate.Month && today.Day < birthdate.Day))
        {
            age--;
        }

        return age;
    }
}