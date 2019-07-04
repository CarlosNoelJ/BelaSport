using FluentValidation;

namespace BelaSport.Models.FluentValidator
{
    public class HostValidator : AbstractValidator<Host>
    {
        public HostValidator()
        {
            //RuleFor(host => host.DniHost)
            //.NotEmpty().WithMessage("Can't be Null")
            //.NotEqual(host => host.DniHost).WithMessage("DNI already exists")
            //    .InclusiveBetween(5, 8).WithMessage("Must be 8 numbers maximum");

            RuleFor(host => host.NameHost)
                .NotEmpty().WithMessage("Can't be empty")
                .Length(3,50).WithMessage("Please Complete with more than 3 characters and 50 maximun.");

            RuleFor(host => host.LastNameHost)
                .NotEmpty().WithMessage("Can't be empty")
                .Length(3, 50).WithMessage("Please Complete with more than 3 characters and 50 maximun.");
        }
    }
}
