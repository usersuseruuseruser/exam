using System.ComponentModel.DataAnnotations;
using Modelss.Models.Abstractions;

namespace Modelss.Models.Implementations;

public class Unit : IUnit
{
    public int Id { get; set; } = -1;
    [Required] public string Name { get; set; } = null!;
    [Required] public int HitPoints { get; set; }
    [Required] public int AttackModifier { get; set; }
    [Required] public int AttacksPerRound { get; set; }
    [Required] public string Damage { get; set; } = null!;
    [Required] public int DamageModifier { get; set; }
    [Required] public int Armor { get; set; }
}