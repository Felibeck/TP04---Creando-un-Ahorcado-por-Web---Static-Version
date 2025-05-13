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
    public IActionResult Juego(char letra, string palabra)
    {
        juego.inicializarJuego();
        ViewBag.palabraVacia = juego.palabraVacia;
        ViewBag.letrasUsadas = juego.letrasUsadas;

        bool aux = juego.comprobarLetra(letra);
        if (aux == false) {
            juego.errores++;
        }
        bool aux2 = juego.comprobarPalabra(palabra);
        if (aux2 == false){
            juego.errores = 7;
        }
        
        ViewBag.errores = juego.errores;

        return View();
    }

}
