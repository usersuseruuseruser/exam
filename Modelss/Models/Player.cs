using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Modelss.Models.Abstractions;

namespace Modelss.Models;

public class Player: IUnit
{
    public int Id { get; set; }
    [Required]
    [MaxLength(20, ErrorMessage = "The max length is 20")]
    // [DisplayName("Name")]
    public string Name { get; set; }
    [Required]
    [Range(0,int.MaxValue,ErrorMessage = "must be positive")]
    // [DisplayName("Hit points")]
    public int HitPoints { get; set; }
    [Required]
    [Range(0,int.MaxValue,ErrorMessage = "must be positive")]
    // [DisplayName("Attack modifier")]
    public int AttackModifier { get; set; }
    [Required]
    [Range(0,int.MaxValue,ErrorMessage = "must be positive")]
    // [DisplayName("Attacks per round")]
    public int AttacksPerRound { get; set; }
    [Required]
    [RegularExpression(@"\d+d\d+", ErrorMessage = "mist be {number}d{number}")]
    // [DisplayName("Damage")]
    public string Damage { get; set; }
    [Required]
    [Range(0,int.MaxValue,ErrorMessage = "must be positive")]
    // [DisplayName("Damage modifier")]
    public int DamageModifier { get; set; }
    [Required]
    [Range(0,int.MaxValue,ErrorMessage = "must be positive")]
    // [DisplayName("Armor")]
    public int Armor { get; set; }
}