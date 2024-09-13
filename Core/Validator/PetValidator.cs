using Core.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validator
{
    public class PetValidator : AbstractValidator<CreatePetDto>
    {
        public PetValidator() 
        {
            RuleFor(x => x.Name)
               .NotEmpty()
               .NotNull();
            RuleFor(x => x.YearsOld)
                .GreaterThan(0)
                .LessThan(30);
            RuleFor(x => x.Breed)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Description)
                .NotNull();
            RuleFor(x => x.ImageUrl)
                .NotEmpty()
                .NotNull()
                .Must(ValidateUri).WithMessage("Image URL must be a valid address.");
        }

        public bool ValidateUri(string? uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                return true;
            }
            return Uri.TryCreate(uri, UriKind.Absolute, out _);
        }
    }
}
