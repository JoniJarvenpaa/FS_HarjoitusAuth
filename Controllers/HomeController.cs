using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using SecondMVC.Models;
using SecondMVC.Models.Services;

namespace SecondMVC.Controllers;

public class HomeController : Controller
{

    public IActionResult Index() // K‰ytt‰j‰ tulee ensikerran sivulle
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    public IActionResult _Register() // Ainoastaan ajax "Sivuvaihtoa varten"
    {
        return PartialView();
    }
    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Register(UserRegisterViewModel vm)
    {
        vm.Register = true;
        if (ModelState.IsValid)
        {
            var uusiKayttaja = new User()
            {
                username = vm.name,
                password = vm.password
            };
            uusiKayttaja.user_dogs = new List<Doggo>();
            uusiKayttaja.user_dogs.Add(new Doggo()
            {
                name = "Ruska",
                age = 11,
                color = "Brown"
            });
            uusiKayttaja.user_dogs.Add(new Doggo()
            {
                name = "Tuska",
                age = 112,
                color = "Black"
            });
            MongoManipulator.SaveUser(uusiKayttaja);
            return RedirectToAction("Index");
        }
        return View("Index", vm);
    }

    [HttpPost]
    public IActionResult _Login()// Ainoastaan ajax "Sivuvaihtoa varten"
    {
        return PartialView();
    }
    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Login(UserRegisterViewModel vm)
    {
        vm.Register = false;
        if (ModelState.IsValid)
        {
            var vastaavuus = MongoManipulator.GetUserByUsername(vm.name);
            if(vastaavuus != null)
            {
                if (vastaavuus.password == vm.password)
                {
                    bool login = true; // Kutsutaan authentication funktiota
                    return RedirectToAction("Privacy");
                }
            }
            ViewData["error"] = "K‰ytt‰j‰tunnus tai salasana v‰‰r‰";
        }
        return View("Index", vm);
    }


    public string test()
    {
        var dogi = new Doggo()
        {
            name = "Ruska",
            age = 11,
            color = "Brown"
        };
        dogi = MongoManipulator.SaveDoggo(dogi);
        return JsonSerializer.Serialize(dogi);
    }
}
