using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PositionKeeping.Models
{
    public class ClassificationSchema
    {
        [Key]
        [ReadOnly(true)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class MaturitySegment : ClassificationSchema { }
    public class ProductFamily : ClassificationSchema { }
    public class CustomerType : ClassificationSchema { }
    public class OrganizationUnit : ClassificationSchema { }
    public class AccountingCategory : ClassificationSchema { }
    public class TransactionType : ClassificationSchema { }
    
}
