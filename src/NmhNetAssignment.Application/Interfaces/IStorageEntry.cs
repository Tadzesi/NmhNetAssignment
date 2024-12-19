namespace NmhNetAssignment.Application.Interfaces
{
    public interface IStorageEntry
    {
        decimal Value { get; set; }
        DateTime LastUpdated { get; set; }
    }
}
