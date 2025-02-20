using FluentValidation;
using ValidationExample.Models;
using System.Text.RegularExpressions;

namespace ValidationExample.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Phone)
                .Matches(@"^\+?\d{10,13}$")
                .WithMessage("Телефон повинен містити лише цифри та може починатися з '+' (10-13 цифр)")
                .When(x => !string.IsNullOrEmpty(x.Phone));

            RuleFor(x => x.Position)
                .MinimumLength(3)
                .WithMessage("Посада повинна містити не менше 3 символів")
                .Matches(@"^[^\d\W][a-zA-Zа-яА-ЯіІїЇєЄ\s]*$")
                .WithMessage("Посада не може починатися з цифри або містити спецсимволи")
                .When(x => !string.IsNullOrEmpty(x.Position));

            RuleFor(x => x.FileName)
                .Matches(@"\.(jpg|png|webp|jpeg)$")
                .WithMessage("Файл повинен мати допустиме розширення: .jpg, .png, .webp, .jpeg")
                .When(x => !string.IsNullOrEmpty(x.FileName));
        }
    }
}
