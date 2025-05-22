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
        juego ahorcado = new juego();
        ahorcado.inicializarJuego();
        HttpContext.Session.SetString("ahorcado", Objeto.ObjectToString(ahorcado));
        

        ViewBag.palabraVacia = ahorcado.palabraVacia;
        ViewBag.letrasUsadas = ahorcado.letrasUsadas;
        ViewBag.errores = ahorcado.errores;

        return View();
    }
    public IActionResult Jugar(char letra, string palabra)
    {
        juego ahorcado = Objeto.StringToObject<juego>(HttpContext.Session.GetString("ahorcado"));
        if(letra == '\0' && palabra == null){
            ViewBag.letrasUsadas = ahorcado.letrasUsadas;
            ViewBag.errores = ahorcado.errores;
            ViewBag.palabraVacia = ahorcado.palabraVacia;

        return View("Juego");
        }
        bool aux = true;

        if (palabra != null)
        {
            aux = ahorcado.comprobarPalabra(palabra.ToUpper());
            if (!aux) return View("Perder"); else return View("Ganar");
        }

       
        letra = Char.ToUpper(letra);
        if(letra != null)
        {
            ahorcado.comprobarLetra(letra);
        } 
        if(ahorcado.errores < 6 && ahorcado.palabraVacia != ahorcado.palabra)
        {
        ViewBag.letrasUsadas = ahorcado.letrasUsadas;
        ViewBag.errores = ahorcado.errores;
        ViewBag.palabraVacia = ahorcado.palabraVacia;
        HttpContext.Session.SetString("ahorcado", Objeto.ObjectToString(ahorcado));
        return View("Juego");
        }else if(ahorcado.errores > 6){
            return View("Perder");
        }
        else return View("Ganar");
        
    }

}
