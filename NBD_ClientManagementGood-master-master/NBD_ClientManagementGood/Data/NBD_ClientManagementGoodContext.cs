using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NBD_ClientManagementGood.Models;

namespace NBD_ClientManagementGood.Data
{
    public class NBD_ClientManagementGoodContext : DbContext
    {
        public NBD_ClientManagementGoodContext(DbContextOptions<NBD_ClientManagementGoodContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<InvBid> InvBids { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<ProductionItem> ProductionItems { get; set; }
        public DbSet<LabourUnit> LabourUnits { get; set; }
        public DbSet<LabourDepartment> LabourDepartments { get; set; }
        public DbSet<LabourStaff> LabourStaffs { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Labour> Labours { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Plant> Plant { get; set; }
        public DbSet<Pottery> Pottery { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<LabourReport> LabourReport { get; set; }
        public DbSet<DesignDaily> DesignDaily { get; set; }
        public DbSet<DesignBudget> DesignBudget { get; set; }
        public DbSet<ProductionWorkReport> ProductionWorkReport { get; set; }
        public DbSet<ProDLabour> ProDLabour { get; set; }
        public DbSet<ProDMaterial> ProDMaterial { get; set; }
        public DbSet<ProductionStageReport> ProductionStageReports { get; set; }
        public DbSet<BidStageReport> BidStageReports { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("CMO");

            modelBuilder.Entity<InvBid>()
                .HasKey(b => new { b.BidID, b.ItemID });

            //Doesn't Do anything ATM, changing intos something else later.
            modelBuilder.Entity<Product>()
                .HasKey(b => new { b.ItemID, b.MaterialID, b.PlantID, b.PotteryID, b.ToolID });

            modelBuilder.Entity<LabourStaff>()
                .HasKey(b => new { b.LabourDeparmentID, b.StaffID });

            modelBuilder.Entity<Labour>()
                .HasKey(b => new { b.LabourUnitID, b.ProductionID });

            //modelBuilder.Entity<ProjectTeam>()
            //    .HasKey(b => new { b.LabourDepartmentID, b.ProductionID });

            modelBuilder.Entity<ProductionItem>()
                .HasKey(b => new { b.ItemID, b.ProductionID });

            //Prevent Cascade Delete from Country to City
            //This prevents deleting a Country with a City assigned 
            modelBuilder.Entity<Country>()
                .HasMany<City>(d => d.Cities)
                .WithOne(p => p.Country)
                .HasForeignKey(p => p.CountryID)
                .OnDelete(DeleteBehavior.Restrict);

            //Prevent Cascade Delete from City to Client
            //This prevents deleting a City with a Client assigned 
            modelBuilder.Entity<City>()
                .HasMany<Client>(d => d.Clients)
                .WithOne(p => p.City)
                .HasForeignKey(p => p.CityID)
                .OnDelete(DeleteBehavior.Restrict);

            //Add a unique index to the Client Email
            modelBuilder.Entity<Client>()
                .HasIndex(p => p.eMail)
                .IsUnique();
        }
    }
}
