using Microsoft.EntityFrameworkCore;

namespace NitelikliKahve.Models;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<CoffeeBean> CoffeeBeans { get; set; }
    
    public DbSet<Equipment> Equipments { get; set; }
    
    public DbSet<Recipe> Recipes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<CoffeeBean>()
            .HasMany(c => c.Recipes) 
            .WithOne(r => r.CoffeeBean) 
            .HasForeignKey(r => r.CoffeeBeanId); 
        
        modelBuilder.Entity<Equipment>()
            .HasMany(e => e.Recipes)
            .WithOne(r => r.Equipment) 
            .HasForeignKey(r => r.EquipmentId); 
    }
}
