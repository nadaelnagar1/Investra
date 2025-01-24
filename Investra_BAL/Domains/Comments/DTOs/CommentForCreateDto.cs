namespace Investra_BAL.Domains.Comments.DTOs
{
    public class CommentForCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public Guid StockId { get; set; }

    }
}
