using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;

namespace Accounts.Database
{
    public class AccountsDbContext : DbContext
    {
        public AccountsDbContext(DbContextOptions<AccountsDbContext> options)
            : base(options)
        {
        }

        public DbSet<AccountArrangement> Accounts { get; set; }
        //public DbSet<Enrollment> Enrollments { get; set; }
        //public DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {        
            /*
            modelBuilder.Entity<PostingEntry>()
                .HasOne<Account>(x => x.Account)
                .WithMany()
                .HasForeignKey(x=>x.AccountId);
            */
            //modelBuilder.Entity<Account>().ToTable("Account");
            //modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            //modelBuilder.Entity<Student>().ToTable("Student");
        }

    }
}
