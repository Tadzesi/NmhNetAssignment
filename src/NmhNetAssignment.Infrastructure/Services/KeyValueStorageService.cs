using NmhNetAssignment.Application.Interfaces;
using NmhNetAssignment.Infrastructure.Models;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace NmhNetAssignment.Infrastructure.Services
{
    public class KeyValueStorageService : IKeyValueStorageService
    {
        private readonly ConcurrentDictionary<int, StorageEntry> _storage = new();

        public bool TryGetValue<T>(int key, [NotNullWhen(true)] out T? value)
        {
            if (IsValidEntry<T>(key, out var typedValue))
            {
                value = typedValue;
                return true;
            }

            // Remove expired entry
            _storage.TryRemove(key, out _);
            value = default;
            return false;
        }

        private bool IsValidEntry<T>(int key, [NotNullWhen(true)] out T? value)
        {
            if (_storage.TryGetValue(key, out var entry) && entry.LastUpdated > DateTime.UtcNow && entry.Value is T typedValue)
            {
                value = typedValue;
                return true;
            }

            value = default;
            return false;
        }

        public void SetValue(int key, IStorageEntry value)
        {
            _storage[key] = (StorageEntry)value;
        }

        public void Remove(int key)
        {
            _storage.TryRemove(key, out _);
        }

        public bool ContainsKey(int key)
        {
            return _storage.ContainsKey(key);
        }

        public IStorageEntry GetOrAdd(int key, IStorageEntry entry)
        {
            return _storage.GetOrAdd(key, (StorageEntry)entry);
        }
    }
}

