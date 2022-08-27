using Microsoft.AspNetCore.Mvc;
using FirmaYonetimSistemi.Entities;
using FirmaYonetimSistemi.Business.Abstract;
using FirmaYonetimSistemi.DataAccess;
using System.Web;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace FirmaYonetimSistemi.API.Controllers
{
    public class LoginController : Controller
    {
        IPersonelService personelService;
        public LoginController(IPersonelService service)
        {
            personelService = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GirisYap(Personel p)
        {
            var personel = personelService.GetPersonelByUsernamePassword(p);
            if (personel != null)
            {
                string rol = "Personel";
                if (personel.DepartmanId == 1)
                {
                    rol = "Müdür";
                }
                else if (personel.DepartmanId == 2)
                {
                    rol = "İK";
                }
                var useridentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                useridentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, p.KullaniciAdi));
                useridentity.AddClaim(new Claim(ClaimTypes.Name, p.KullaniciAdi));
                useridentity.AddClaim(new Claim(ClaimTypes.Role, rol));
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                    IsPersistent = true,
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                    new ClaimsPrincipal(principal), authProperties);
                bool b = HttpContext.User.Identity.IsAuthenticated;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Mesaj = "Kullanıcı adı/şifre hatalı!";
            return View("Index");
        }
    }
}
