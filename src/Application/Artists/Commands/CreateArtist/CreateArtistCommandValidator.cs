using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace projects.Application.Artists.Commands.CreateArtist;
public class CreateArtistCommandValidator : AbstractValidator<CreateArtistCommand>
{
    public CreateArtistCommandValidator()
    {
           RuleFor(r => r.Name)
            .NotEmpty().WithMessage("Artist name shouldn't be empty.")
            .MaximumLength(20).WithMessage("Name must not exceed 20 characters.");
    }
}
