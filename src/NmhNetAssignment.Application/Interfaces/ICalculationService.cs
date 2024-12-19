namespace NmhNetAssignment.Application.Interfaces
{
    public interface ICalculationService
    {
        ICalculationResult ProcessCalculation(int key, decimal input);
    }
}
