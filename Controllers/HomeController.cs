using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using SecondMVC.Models;

namespace SecondMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult _FirstPartial(int maara)
    {
        return PartialView(maara);
    }
    [HttpPost]
    public IActionResult _SecondPartial()
    {
        return PartialView();
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


    public string testi_tallennus() // Test!
    {
        var kayttis = new kayttaja()
        {
            username = "Joni",
            password = "secret_ebin"
        };
        TallennaKayttaja(kayttis);
        return JsonSerializer.Serialize(kayttis);
    }
    public void TallennaKayttaja(kayttaja kayttaja)
    {
        try
        {
            var kaikkiKayttajat = LueKayttajat();
            kaikkiKayttajat.Add(kayttaja);
            System.IO.File.WriteAllText("kayttajat.json", JsonSerializer.Serialize(kaikkiKayttajat));
        }
        catch
        {
            System.IO.File.WriteAllText("kayttajat.json", JsonSerializer.Serialize(new List<kayttaja>()));
        }
    }
    public List<kayttaja> LueKayttajat()
    {
        var kayttajaLista = System.IO.File.ReadAllText("kayttajat.json");
        if (kayttajaLista == null) return new List<kayttaja>();
        try{ return JsonSerializer.Deserialize<List<kayttaja>>(kayttajaLista); }
        catch { return new List<kayttaja>(); }
    }
}
