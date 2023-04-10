using System.ComponentModel.DataAnnotations;

namespace PositionKeeping.Models
{
    public class PositionTypes
    {
        [Key]
        public int Id { get; set; }      
        public string Name { get; set; }
        public AssetsLiabilityFlag AL { get; set; }

    }
}
