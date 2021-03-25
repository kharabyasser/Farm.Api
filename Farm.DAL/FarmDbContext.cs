using Microsoft.EntityFrameworkCore;
using Farm.Data.Models;
using Farm.DAL.Interfaces;

namespace Farm.DAL
{
    public class FarmDbContext : DbContext, IFarmDbContext
    {
        public FarmDbContext(DbContextOptions<FarmDbContext> options) : base(options) { }
        public DbSet<Farmland> Farmlands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Equipment> Equipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EquipmentFarmland>()
                .HasKey(bc => new { bc.EquipmentId, bc.FarmlandId });
            modelBuilder.Entity<EquipmentFarmland>()
                .HasOne(bc => bc.Equipment)
                .WithMany(b => b.EquipmentFarmlands)
                .HasForeignKey(bc => bc.EquipmentId);
            modelBuilder.Entity<EquipmentFarmland>()
                .HasOne(bc => bc.Farmland)
                .WithMany(c => c.EquipmentFarmlands)
                .HasForeignKey(bc => bc.FarmlandId);
        }
    }
}
