using FluentValidation;

namespace Application.Albums.Commands.UpdateAlbum
{
    public class UpdateAlbumCommandValidator : AbstractValidator<UpdateAlbumCommand>
    {
        public UpdateAlbumCommandValidator()
        {
             RuleFor(r => r.Title)
            .NotEmpty().WithMessage("Title shouldn't be empty.")
            .MaximumLength(20).WithMessage("Title must not exceed 20 characters.");

            RuleFor(r => r.ArtistId).NotEmpty();
        }
    }
}