using Microsoft.EntityFrameworkCore;
using Modelss.Models.Implementations;

namespace DB;

public class PostgresContext: DbContext
{
    public DbSet<Unit> Units { get; set; } = null!;

    public PostgresContext()
    {
       
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Username=test;Password=test;Database=Mobs");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Unit>().HasData(new Unit()
        {
            Id = 1,
            Name = "Bear",
            Armor = 12,
            Damage = "2d6",
            AttackModifier = 9,
            AttacksPerRound = 2,
            DamageModifier = 5,
            HitPoints = 42
        });
        modelBuilder.Entity<Unit>().HasData(new Unit()
        {
            Id = 2,
            Name = "Berserk",
            Armor = 13,
            Damage = "1d12",
            AttackModifier = 9,
            AttacksPerRound = 1,
            DamageModifier = 3,
            HitPoints = 67
        });
        modelBuilder.Entity<Unit>().HasData(new Unit()
        {
            Id = 3,
            Name = "Warrior",
            Armor = 20,
            Damage = "1d8",
            AttackModifier = 7,
            AttacksPerRound = 2,
            DamageModifier = 3,
            HitPoints = 52
        });
    }
}