using BarclaysPayments.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarclaysPayments.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IConfiguration _configuration)
            : base(options)
        {
            configuration = _configuration;
        }

        public IConfiguration configuration { get; }
        public DbSet<BarclaysErrorCode> BarclaysErrorCode { get; set; }
        public DbSet<BarclaysPayment> BarclaysPayment { get; set; }
        public DbSet<BarclaysResponse> BarclaysResponse { get; set; }
        public DbSet<Config> Config { get; set; }
        public DbSet<IELTSOrder> IELTSOrder { get; set; }
        public DbSet<IELTSPrice> IELTSPrice { get; set; }
        public DbSet<IELTSTestType> IELTSTestType { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<PaymentReason> PaymentReason { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }
        public DbSet<StaffMember> StaffMember { get; set; }
        public DbSet<SystemSettings> SystemSettings { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Needed to add composite key
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Config>()
                .HasKey(c => new { c.AcademicYear });

            modelBuilder.Entity<PaymentStatus>()
                .HasAlternateKey(c => new { c.Code });

            modelBuilder.Entity<StaffMember>()
                .HasKey(c => new { c.StaffRef });

            modelBuilder.Entity<SystemSettings>()
                .HasNoKey();

            //Prevent creating table in EF Migration
            modelBuilder.Entity<Config>(entity => {
                entity.ToView("Config", "dbo");
            });

            //Prevent creating table in EF Migration
            modelBuilder.Entity<StaffMember>(entity => {
                entity.ToView("StaffMember", "dbo");
            });

            //Prevent creating table in EF Migration
            modelBuilder.Entity<SystemSettings>(entity => {
                entity.ToView("SystemSettings", "dbo");
            });

            //Prevent creating table in EF Migration
            modelBuilder.Entity<Transaction>(entity => {
                entity.ToView("Transaction", "dbo");
            });
        }

        //Rename migration history table
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsHistoryTable("__PAY_EFMigrationsHistory", "dbo"));

        //Rename migration history table
    }
}
