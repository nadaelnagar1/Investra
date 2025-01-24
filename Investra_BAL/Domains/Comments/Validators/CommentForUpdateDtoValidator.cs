namespace Investra_BAL.Domains.Comments.Validators
{
    public class CommentForUpdateDtoValidator : AbstractValidator<CommentForUpdateDto>
    {
        public CommentForUpdateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required");
            RuleFor(x => x.CreatedOn).NotEmpty().WithMessage("CreatedOn is required");
        }
    }
}
