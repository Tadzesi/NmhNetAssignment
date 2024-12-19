namespace NmhNetAssignment.Application.Interfaces
{
    public interface ICalculationResult
    {
        decimal ComputedValue { get; set; }
        decimal InputValue { get; set; }
        decimal PreviousValue { get; set; }
    }
}
