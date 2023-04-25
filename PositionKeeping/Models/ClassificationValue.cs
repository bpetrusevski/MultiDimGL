using System.ComponentModel.DataAnnotations;

namespace PositionKeeping.Models
{
    
    public abstract class ClassificationValue
    {
        [Key]
        public int ID { get; set; }
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }

        public int Schema { get; set; }
    }

    public class ClassificationValue<T>: ClassificationValue where T : ClassificationSchema
    {
        //public override ClassificationSchema Schema { get; set; }
    }


}
