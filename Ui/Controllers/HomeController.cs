using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Modelss.Models;
using Ui.Models;

namespace Ui.Controllers;

public class HomeController : Controller
{
    [Route("/")]
    public IActionResult Index()
    {
        return View();
    }
    [Route("/")]
    [HttpPost]
    public async Task<IActionResult> Index(Player player)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        HttpClient httpClient = new HttpClient();
        var httpResult = await httpClient.PostAsJsonAsync("http://localhost:5224/api/fight", player);
        
        var result = await httpResult.Content.ReadFromJsonAsync<Result>();
        
        return View(result);
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