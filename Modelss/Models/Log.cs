using Models.Dtos;

namespace Modelss.Models;

public class Log
{
    public string CharacterName { get; set; } = "";
    public string EnemyName { get; set; } = "";
    public int AttackModifier { get; set; }
    public int EnemyArmor { get; set; }
    public int DamageModifier { get; set; }
    public int[] DiceRoll { get; set; }
    public int[] Damage { get; set; }
    public AttackType[] AttackType { get; set; }
    public int[] EnemyHp { get; set; }
}