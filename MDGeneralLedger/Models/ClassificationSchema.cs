using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MDGeneralLedger.Models
{
    public class ClassificationSchema
    {
        [Key]
        public string SchemaId { get; set; }

        [Required]
        public string Name { get; set; }

        public ClassificationSchema ParentSchema { get; set; }

    }

    public class AccounbtingCategory : ClassificationSchema { }

    public class Currency : ClassificationSchema { }

    public class OrganizationUnit : ClassificationSchema { }

    public class Product : ClassificationSchema { }
    public class Residency : ClassificationSchema { }
    public class Tenure : ClassificationSchema { }

}
