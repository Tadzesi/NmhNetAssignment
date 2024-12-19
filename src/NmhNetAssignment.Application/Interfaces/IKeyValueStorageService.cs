namespace NmhNetAssignment.Application.Interfaces
{
    public interface IKeyValueStorageService
    {
        bool TryGetValue<T>(int key, out T? value);
        void SetValue(int key, IStorageEntry value);
        void Remove(int key);
        bool ContainsKey(int key);
        IStorageEntry GetOrAdd(int key, IStorageEntry entry);
    }
}