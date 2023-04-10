using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaymantInitiation.Models
{
    public class AmountType
    {
        [JsonPropertyName("amt")]
        public decimal Amount { get; set; }

        [MaxLength(20)]
        [JsonPropertyName("ccy")]
        public string Currency { get; set; }
    }
}
