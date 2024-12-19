namespace NmhNetAssignment.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public Image? Image { get; set; }
    }
}
