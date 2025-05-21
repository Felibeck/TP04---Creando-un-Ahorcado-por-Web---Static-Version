using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP04_Ahorcado.Models;

namespace TP04_Ahorcado.Controllers;

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
    public IActionResult Juego()
    {
        juego.inicializarJuego();
        ViewBag.palabraVacia = juego.palabraVacia;
        ViewBag.letrasUsadas = juego.letrasUsadas;
        ViewBag.errores = juego.errores;

        return View();
    }
    public IActionResult Jugar(char letra, string palabra)
    {
        if(letra == '\0' && palabra == null){
            ViewBag.letrasUsadas = juego.letrasUsadas;
            ViewBag.errores = juego.errores;
            ViewBag.palabraVacia = juego.palabraVacia;

        return View("Juego");
        }
        bool aux = true;

        if (palabra != null)
        {
            aux = juego.comprobarPalabra(palabra.ToUpper());
            if (!aux) return View("Perder"); else return View("Ganar");
        }

       
        letra = Char.ToUpper(letra);
        if(letra != null)
        {
            juego.comprobarLetra(letra);
        } 
        if(juego.errores < 6 && juego.palabraVacia != juego.palabra)
        {
        ViewBag.letrasUsadas = juego.letrasUsadas;
        ViewBag.errores = juego.errores;
        ViewBag.palabraVacia = juego.palabraVacia;

        return View("Juego");
        }else if(juego.errores > 6){
            return View("Perder");
        }
        else return View("Ganar");
    }

}
