using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace PositionKeeping.Models
{
    public class AccountUnit
    {
        [Key]
        public long Id { get; set; }
        //link with the external arrangements
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public AccountingUnitType Type { get; set; }
        public decimal AccruedInterest { get; set; }

        public List<AccountUnit> Offsets { get; set; } 

        //optional, AU may not be part of financial accounting 
        public GLAccount GL { get; set; }

        // additional attributes
        public ClassificationValue<OrganizationUnit> OU { get; set; }
        public ClassificationValue<MaturitySegment> MaturitySegment { get; set; }        
        public ClassificationValue<CustomerType> CustomerType { get; set; }
        public ClassificationValue<ProductFamily> ProductFamily { get; set; }
    }
}
