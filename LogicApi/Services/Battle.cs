using Models.Dtos;
using Modelss.Models;
using Modelss.Models.Abstractions;
using Modelss.Models.Implementations;

namespace LogicApi.Services;

public class Battle : IBattle
{
    private Player player;
    private Unit enemy;
    public Battle(Player player, Unit unit)
    {
        this.player = player;
        this.enemy = unit;
    }

    public Result ProcessBattle()
    {
        var result = new Result() { Rounds = new List<Round>()};
        var currentRound = 1;
        while (player.HitPoints > 0 && enemy.HitPoints > 0)
        {
            Round round = new Round() { RoundNumber = currentRound, Logs = new List<Log>()};
            var playerLog = ProcessTurn(player, enemy);
            round.Logs.Add(playerLog);
            if (enemy.HitPoints > 0)
            {
                var enemyLog = ProcessTurn(player, enemy, false);
                round.Logs.Add(enemyLog);
            }
            result.Rounds.Add(round);
            currentRound++;
        }
        result.Winner = player.HitPoints > 0 ? player.Name : enemy.Name;
        result.Player = player;
        return result;
    }

    public Log ProcessTurn(Player player, Unit unit, bool isPlayerTurn = true)
    {
        IUnit attackingOne = isPlayerTurn ? player : unit;
        IUnit defendingOne = isPlayerTurn ? unit : player;
        
        var log = new Log();
        log.DiceRoll = new int[attackingOne.AttacksPerRound];
        log.Damage = new int[attackingOne.AttacksPerRound];
        log.AttackType = new AttackType[attackingOne.AttacksPerRound];
        log.EnemyHp = new int[attackingOne.AttacksPerRound];
        log.CharacterName = attackingOne.Name;
        log.EnemyName = defendingOne.Name;
        log.AttackModifier = attackingOne.AttackModifier;
        log.EnemyArmor = defendingOne.Armor;
        log.DamageModifier = attackingOne.DamageModifier;
        var dices = attackingOne.Damage.Split("d").Select(int.Parse).ToList();
        for (int i = 0; i < attackingOne.AttacksPerRound; i++)
        {
            int currentDamage = 0;
            // разобраться, неоптимально
            var random = new Random();
            var diceRoll = random.Next(1, 21);
            log.DiceRoll[i] = diceRoll;
            if (diceRoll == 1)
            {
                log.AttackType[i] = AttackType.Miss;
            }
            else if (diceRoll == 20)
            {
                for (int j = 0; j < dices[0]; j++)
                {
                    currentDamage += random.Next(1, dices[1] + 1);
                }

                log.AttackType[i] = AttackType.Critical;
                log.Damage[i] = attackingOne.DamageModifier * 2 + currentDamage;
                log.EnemyHp[i] = defendingOne.HitPoints - (attackingOne.DamageModifier * 2 + currentDamage);
                enemy.HitPoints = defendingOne.HitPoints - (attackingOne.DamageModifier * 2 + currentDamage);
            }
            else
            {
                var penetration = diceRoll + attackingOne.AttackModifier;
                if (penetration < defendingOne.Armor)
                {
                    log.AttackType[i] = AttackType.Miss;
                }
                else
                {
                    for (int j = 0; j < dices[0]; j++)
                    {
                        currentDamage += random.Next(1, dices[1] + 1);
                    }

                    log.AttackType[i] = AttackType.Hit;
                    log.Damage[i] = attackingOne.DamageModifier + currentDamage;
                    log.EnemyHp[i] = defendingOne.HitPoints - (attackingOne.DamageModifier + currentDamage);
                    enemy.HitPoints = defendingOne.HitPoints - (attackingOne.DamageModifier + currentDamage);
                }
            }
        }
        return log;
    }
    
}