namespace NmhNetAssignment.Application.Requests
{
    public class StoreRequest
    {
        public int Key { get; set; }
        public object Value { get; set; } = null!;
    }
}
