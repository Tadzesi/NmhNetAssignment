using NmhNetAssignment.Application.Interfaces;

namespace NmhNetAssignment.Infrastructure.Models
{
    public class StorageEntry : IStorageEntry
    {
        public decimal Value { get; set; } = default;
        public DateTime LastUpdated { get; set; } = default;
    }
}
