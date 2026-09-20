using Microsoft.AspNetCore.Mvc;
using MiApiCuadrado;

namespace MiApiCuadrado.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MCDController : ControllerBase
{       
    [HttpGet("{divisor}/{dividendo}")]
    public IActionResult MCD(int divisor, int dividendo)
    {
        CalculaelMCD calculadora = new ();

        int mcd = calculadora.calcularMCD(divisor, dividendo);

        return Ok($"El MCD es {mcd}");
    }
}