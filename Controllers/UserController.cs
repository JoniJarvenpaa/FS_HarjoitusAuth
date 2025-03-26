using Microsoft.AspNetCore.Mvc;
using SecondMVC.Models;

namespace SecondMVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            ViewData["message"] = "Hei vaan";
            var viewModel = new UserIndexViewModel();
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Register(UserRegisterViewModel vm)
        {
            if (ModelState.IsValid) { 
                if(vm.name.ToLower() == "admin")
                {
                    ViewData["error"] = "Hei, etsä voi olla admin bro";
                    return View(vm);
                }
                return RedirectToAction("Index");
            }
            else
                return View(vm);
        }
    }
}
