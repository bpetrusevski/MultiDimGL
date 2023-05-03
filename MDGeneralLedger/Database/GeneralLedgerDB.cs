using Azure;
using MDGeneralLedger.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;

namespace MDGeneralLedger.Database
{
    public class GeneralLedgerDB : DbContext
    {

        public GeneralLedgerDB(DbContextOptions<GeneralLedgerDB> options)
            : base(options)
        {
        }

        //public bool EnableServiceProviderCaching { get; set; } = true;

        public DbSet<GlAccount> Accounts { get; set; }
        public DbSet<ClassificationSchema> AcctDim { get; set; }
        public DbSet<ClassificationValue> AcctDimValue { get; set; }


        //public DbSet<PeriodBalance> PeriodBalances { get; set; }


        /*
        public void MyUpgrade()
        {
            foreach (var d in _model.AcctDim)
            {
                this.Database.ExecuteSqlRaw($"Alter table Accounts add {d.SchemaId} varchar(10)");                
            }
        }
        */
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.EnableServiceProviderCaching(false);

            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /*
            modelBuilder.Entity<GlAccount>(builder =>
            {                
                foreach(var d in _model.AcctDim)
                    builder.IndexerProperty<string>(d.SchemaId);

            });
            */

            modelBuilder.Entity<GlAccount>(b =>
                {
                    b.HasOne(x => x.Currency)
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne(x => x.Residency)
                        .WithMany()
                        .HasForeignKey("ResidencyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne(x => x.OU)
                        .WithMany()
                        .HasForeignKey("OUId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne(x => x.Tenure)
                        .WithMany()
                        .HasForeignKey("TenureId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne(x => x.Category)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .IsRequired(true)
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne(x => x.Product)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity<ClassificationSchema>(x =>
            {
                x.Property(p => p.SchemaId).HasMaxLength(15)
                 .HasColumnType("varchar");

                x.Property(p => p.Name).HasMaxLength(100);

                x.HasOne(x => x.ParentSchema)
                    .WithMany()
                    .HasForeignKey("ParentSchemaId")
                    .OnDelete(DeleteBehavior.Restrict);

                x.HasDiscriminator(f => f.SchemaId);
            });

            modelBuilder.Entity<ClassificationValue>(x =>
            {
                //x.HasKey(p=> new { p.Schema, p.ID });

                x.Property(p => p.ID).HasMaxLength(10)
                 .HasColumnType("varchar");

                x.Property(p => p.Name).HasMaxLength(100);

                x.HasOne(x => x.Parent)
                    .WithMany()
                    .HasForeignKey("ParentId")
                    .OnDelete(DeleteBehavior.Restrict);

                x.Property(p => p.SchemaId)
                    .HasColumnType("varchar")
                    .HasMaxLength(15);

                x.HasDiscriminator<string>(f=>f.SchemaId);

                /*
                x.HasOne(x => x.Schema)
                    .WithMany()
                    .HasForeignKey("SchemaId")
                    .IsRequired(true);
                */
            });


            modelBuilder.Entity<PostingEntry>(x =>
            {
                x.Property(p => p.Id).UseIdentityColumn();

                x.Property(p => p.BookingDate).HasColumnType("Date");
                x.Property(p => p.Credit).HasPrecision(18, 2);
                x.Property(p => p.Debit).HasPrecision(18, 2);
                x.Property(p => p.FCredit).HasPrecision(18, 2);
                x.Property(p => p.FDebit).HasPrecision(18, 2);
                x.Property(p => p.FDebit).HasPrecision(18, 2);

                x.Property(p => p.JournalID).HasColumnType("varchar").HasMaxLength(36);

                x.HasOne(p => p.Currency)
                 .WithMany()
                 .OnDelete(DeleteBehavior.NoAction);
            });




            base.OnModelCreating(modelBuilder);
        }
    }
}