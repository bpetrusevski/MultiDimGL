using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;

namespace Accounts.Database
{
    public class PaymentOrderDb : DbContext
    {
        public PaymentOrderDb(DbContextOptions<PaymentOrderDb> options)
            : base(options)
        {
        }
    }
}
