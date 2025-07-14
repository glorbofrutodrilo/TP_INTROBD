using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP_BD.Models;
using Microsoft.AspNetCore.Http;
using System.Reflection.Metadata.Ecma335;

namespace TP_BD.Controllers;

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

    public IActionResult Login(string email, string password)
    {
        Integrante integrante = BD.LevantarIntegrante(email, password);
        if (integrante != null && integrante.Email == email && integrante.Password == password)
        {
            string integranteStr = Objeto.ObjectToString(integrante);
            HttpContext.Session.SetString("integrante", integranteStr);
            string foto = "";
            if (integrante.Nombre.ToLower().Contains("augusto"))
                foto = "AUGUSTO.PNG.png";
            else if (integrante.Nombre.ToLower().Contains("uriel"))
                foto = "URI.PNG.png";
            else if (integrante.Nombre.ToLower().Contains("felipe"))
                foto = "FELI.PNG.png";
            HttpContext.Session.SetString("foto", foto);
            return RedirectToAction("Info");
        }
        else
        {
            return View("Index");
        }
    }

    public IActionResult Info()
    {
        string? integranteStr = HttpContext.Session.GetString("integrante");
        Integrante? integrante = Objeto.StringToObject<Integrante>(integranteStr);
        ViewBag.Integrante = integrante;
        ViewBag.Foto = HttpContext.Session.GetString("foto");
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return View("Index");
    }
}

