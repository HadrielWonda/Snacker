using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Snacker.Application.Menus.Commands.CreateMenu;

    public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
    {
        public CreateMenuCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(130);

             RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(1000);

             RuleFor(x => x.Sections).NotEmpty();
        }
    }
