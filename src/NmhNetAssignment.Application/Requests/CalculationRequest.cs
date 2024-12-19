using MediatR;
using NmhNetAssignment.Application.Responses;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NmhNetAssignment.Application.Requests
{
    public class CalculationRequest : IRequest<CalculationResponse>
    {
        [JsonIgnore]
        public int Key { get; set; }
        [Required]
        public decimal Input { get; set; }
    }
}
