using Microsoft.AspNetCore.Mvc;
using PottencialApi.Domain.Account;
using PottencialApi.WebUI.ViewModel;

namespace PottencialApi.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthenticate _authenticate;

        public HomeController(IAuthenticate authenticate)
        {
            _authenticate = authenticate;
        }

        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model, string returnUrl)
        {
            var result = await _authenticate.Authenticate(model.Email, model.Password);

            if(result)
            {
                /* tratar falha de redirecionamento aberto
                if(Url.IsLocalUrl("/Produtos/Index"))
                {
                    return RedirectToAction("Index", "Produtos");
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
                */
                return RedirectToAction("Index", "Produtos");

            }
            else
            {
                ModelState.AddModelError(String.Empty, "Falha no login!");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(RegistrarVM model)
        {
            var result = await _authenticate.RegisterUser(model.Email, model.Password);

            if(result)
            {
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Falha no registro do user");
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _authenticate.Logout();
            return LocalRedirect("/");
        }
    }
}