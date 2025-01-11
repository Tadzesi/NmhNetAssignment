using NmhNetAssignment.Application.Interfaces;
using NmhNetAssignment.Infrastructure.Models;
using NmhNetAssignment.Infrastructure.Results;

namespace NmhNetAssignment.Infrastructure.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly IKeyValueStorageService _keyValueStorageService;
        public CalculationService(IKeyValueStorageService keyValueStorageService)
        {
            _keyValueStorageService = keyValueStorageService;
        }
        public ICalculationResult ProcessCalculation(int key, decimal input)
        {
            var now = DateTime.UtcNow;
            var entry = _keyValueStorageService.GetOrAdd(key, new StorageEntry { Value = 2, LastUpdated = now });

            decimal previousValue = entry.Value;
            decimal computedValue = ComputeValue(input, previousValue, entry);

            _keyValueStorageService.SetValue(key, entry);

            return new CalculationResult
            {
                ComputedValue = computedValue,
                InputValue = input,
                PreviousValue = previousValue
            };
        }

        private static decimal ComputeValue(decimal input, decimal previousValue, IStorageEntry entry)
        {
            if (IsExpired(entry))
            {
                return 2;
            }

            decimal.TryParse(Math.Pow(Math.Log((double)input / (double)previousValue), 1.0 / 3.0).ToString(), out decimal calculatedValue);

            return calculatedValue;
        }

        private static bool IsExpired(IStorageEntry entry)
        {
            return DateTime.UtcNow.Subtract(entry.LastUpdated).TotalSeconds > 15;
        }
    }
}
