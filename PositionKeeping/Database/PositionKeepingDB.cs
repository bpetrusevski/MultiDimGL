using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using PositionKeeping.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace PositionKeeping.Database
{

    public class PositionKeepingDB : DbContext
    {
        public PositionKeepingDB(DbContextOptions<PositionKeepingDB> options)
            : base(options)
        {
        }


        public DbSet<PostingEntry> PostingEntries { get; set; }
        public DbSet<AccountUnit> AccountUnits { get; set; }
        public DbSet<AccountingUnitType> AccountingUnitTypes { get; set; }
        public DbSet<GLAccount> ChartOfAccounts { get; set; }
        public DbSet<ClassificationSchema> ClassificationSchemas { get; set; }
        public DbSet<ClassificationValue<ClassificationSchema>> ClassificationValues { get; set; }

        //public DbSet<PeriodBalance> PeriodBalances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountingUnitType>()
                .Property(e => e.Name).HasMaxLength(20);

            modelBuilder.Entity<AccountUnit>()
                .Property(e => e.AccruedInterest).HasPrecision(18, 4);


            modelBuilder.Entity<AccountUnit>()
                .Property(e => e.AccountNumber).HasColumnType("VARCHAR").HasMaxLength(20);
                
            modelBuilder.Entity<AccountUnit>()
    .           Property(e => e.Currency).HasColumnType("VARCHAR").HasMaxLength(3);
            
            modelBuilder.Entity<ClassificationValue>()
                .Property(e => e.Code).HasColumnType("VARCHAR").HasMaxLength(20);

            modelBuilder.Entity<ClassificationValue>()
                .Property(e => e.Name).HasMaxLength(100);

            modelBuilder.Entity<ClassificationValue>()
                .HasDiscriminator<int>("Schema")
                .HasValue<ClassificationValue<ClassificationSchema>>(0)
                .HasValue<ClassificationValue<MaturitySegment>>(1)
                .HasValue<ClassificationValue<ProductFamily>>(2)
                .HasValue<ClassificationValue<CustomerType>>(3)
                .HasValue<ClassificationValue<AccountingCategory>>(4)
                .HasValue<ClassificationValue<TransactionType>>(5)
                .HasValue<ClassificationValue<OrganizationUnit>>(6);

           
            

            modelBuilder.Entity<ClassificationSchema>()
                .Property(e => e.Name).HasMaxLength(100);
            modelBuilder.Entity<ClassificationSchema>()
                .HasDiscriminator(x => x.Code);
            modelBuilder.Entity<ClassificationSchema>()
                .Property(e => e.Code).HasColumnType("VARCHAR").HasMaxLength(20);

            //modelBuilder.Entity<ClassificationValue<ClassificationSchema>>()
            //    .Property(e => e.).HasMaxLength(100);

            modelBuilder.Entity<GLAccount>()
                .Property(e => e.AccountNumber).HasColumnType("VARCHAR").HasMaxLength(15);

            modelBuilder.Entity<GLAccount>()
                .Property(e => e.Name).HasMaxLength(100);

            modelBuilder.Entity<PostingEntry>()
                .Property(e => e.PostingId).ValueGeneratedOnAdd();

            modelBuilder.Entity<PostingEntry>()
                .Property(e => e.Description).HasMaxLength(255);

            modelBuilder.Entity<PostingEntry>()
                .Property(e => e.Amount).HasPrecision(18,2);

            //modelBuilder.Entity<PostingEntry>()
            //    .HasOne<AccountUnit>(x => x.AccountUnitId)
            //    .WithMany()
            //    .HasForeignKey(x => x.AccountUnitId);

            /*
                .Property(e => e.AccountNumber).HasColumnType("VARCHAR").HasMaxLength(20)
                .HasOne<Account>(x => x.Account)
                .WithMany()
                .HasForeignKey(x=>x.AccountId);
            */
            //modelBuilder.Entity<Account>().ToTable("Account");
            //modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            //modelBuilder.Entity<Student>().ToTable("Student");



            // for the other conventions, we do a metadata model loop
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                //entityType.SetTableName(entityType.DisplayName());

                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }

            base.OnModelCreating(modelBuilder);
        }
    }


}