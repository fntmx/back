namespace Bmwadforth.Types.Models;

public class Article : BaseEntity
{
    public int ArticleId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid? ThumbnailId { get; set; }
    public Guid? ContentId { get; set; }
}