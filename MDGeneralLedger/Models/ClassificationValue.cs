using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MDGeneralLedger.Models
{

    public class ClassificationValue
    {
        [Required]
        public string ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string SchemaId { get; set; }
        public ClassificationValue Parent { get; set; }
    }


    public class ClassificationValue<T> : ClassificationValue where T : ClassificationSchema
    {
    }


}
