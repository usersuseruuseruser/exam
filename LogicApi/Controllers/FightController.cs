using System.Diagnostics;
using DB;
using Microsoft.AspNetCore.Mvc;
using LogicApi.Models;
using LogicApi.Services;
using Modelss.Models;
using Modelss.Models.Implementations;

namespace LogicApi.Controllers;

public class FightController : Controller
{
    private readonly ILogger<FightController> _logger;
    private PostgresContext PostgresContext;

    public FightController(ILogger<FightController> logger, PostgresContext postgresContext)
    {
        PostgresContext = postgresContext;
        _logger = logger;
    }
    [Route("api/fight")]
    public JsonResult Fight([FromBody] Player player)
    {
        Random random = new Random();
        var enemyCount = PostgresContext.Units.Count();
        Unit enemy = PostgresContext.Units.Find(random.Next(1, enemyCount + 1))!;
        var result = new Battle(player, enemy).ProcessBattle();
        return new JsonResult(result);
    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}