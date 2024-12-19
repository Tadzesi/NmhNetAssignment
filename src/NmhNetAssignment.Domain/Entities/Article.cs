namespace NmhNetAssignment.Domain.Entities
{
    public class Article : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public ICollection<Author> Authors { get; set; } = new List<Author>();
        public long? SiteId { get; set; }
        public Site? Site { get; set; }
    }
}
