using NmhNetAssignment.Application.Interfaces;

namespace NmhNetAssignment.Application.Responses
{
    public class CalculationResponse : ICalculationResult
    {
        public decimal ComputedValue { get; set; }
        public decimal InputValue { get; set; }
        public decimal PreviousValue { get; set; }
    }
}
