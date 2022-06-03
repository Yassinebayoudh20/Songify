using FluentValidation;

namespace Application.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommandValidator : AbstractValidator<CreateAlbumCommand>
    {
        public CreateAlbumCommandValidator()
        {
            RuleFor(r => r.Title)
            .NotEmpty().WithMessage("Title shouldn't be empty.")
            .MaximumLength(20).WithMessage("Title must not exceed 20 characters.");

            RuleFor(r => r.ArtistId).NotEmpty();

        }
    }
}