using Modelss.Models.Abstractions;
using Modelss.Models.Implementations;

namespace Modelss.Models;

public class Result
{
    public List<Round>? Rounds { get; set; } = null!;
    public string? Winner { get; set; }
    public Player Player = null!;
}