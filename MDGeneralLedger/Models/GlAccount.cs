using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace MDGeneralLedger.Models
{
    // chart of accounts
    public class GlAccount 
    {
        // The inner dictionary.
        private readonly Dictionary<string, object> _dimFields
            = new Dictionary<string, object>();

        [Key]
        public string Account { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        // Accounting Category
        public ClassificationValue<AccounbtingCategory> Category { get; set; }
        public ClassificationValue<Currency> Currency { get; set; }
        public ClassificationValue<OrganizationUnit> OU { get; set; }
        public ClassificationValue<Product> Product { get; set; }
        public ClassificationValue<Residency> Residency { get; set; }
        public ClassificationValue<Tenure> Tenure { get; set; }


        public object this[string key]
        {
            get => _dimFields[key];
            set => _dimFields[key] = value;
        }

        
        /*
        // If you try to get a value of a property
        // not defined in the class, this method is called.
        public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            string name = binder.Name.ToLower();

            // If the property name is found in a dictionary,
            // set the result parameter to the property value and return true.
            // Otherwise, return false.
            return _dimFields.TryGetValue(name, out result);
        }

        // If you try to set a value of a property that is
        // not defined in the class, this method is called.
        public override bool TrySetMember(
            SetMemberBinder binder, object value)
        {
            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            _dimFields[binder.Name.ToLower()] = value;

            // You can always add a value to a dictionary,
            // so this method always returns true.
            return true;
        }
        
        */
    }
}
