using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace projects.Application.Songs.Commands.UpdateSong;
public class UpdateSongCommandValidator : AbstractValidator<UpdateSongCommand>
{
    public UpdateSongCommandValidator()
    {
        RuleFor(r => r.Title)
            .NotEmpty().WithMessage("Song title shouldn't be empty.")
            .MaximumLength(20).WithMessage("Title must not exceed 20 characters.");
    }
}
