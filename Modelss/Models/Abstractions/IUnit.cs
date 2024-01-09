namespace Modelss.Models.Abstractions;

public interface IUnit
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int HitPoints { get; set; }
    public int AttackModifier { get; set; }
    public int AttacksPerRound { get; set; }
    public string Damage { get; set; } 
    public int DamageModifier { get; set; }
    public int Armor { get; set; }
}