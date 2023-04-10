using System.ComponentModel.DataAnnotations;

namespace Accounts.Models.Commands
{
    public class CreateAccountCommandBody
    {
        [Required]
        public string CustomerID { get; set; }
    }
}
