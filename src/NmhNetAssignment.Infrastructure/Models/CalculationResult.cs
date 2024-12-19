using NmhNetAssignment.Application.Interfaces;

namespace NmhNetAssignment.Infrastructure.Results
{
    public class CalculationResult : ICalculationResult
    {
        public decimal ComputedValue { get; set; }
        public decimal InputValue { get; set; }
        public decimal PreviousValue { get; set; }
    }
}
