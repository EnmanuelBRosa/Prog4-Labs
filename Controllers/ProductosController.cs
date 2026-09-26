using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MiApiCuadrado.Models;

namespace MiApiCuadrado.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly string _connectionString;

    public ProductosController(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DefaultConnection")!;
    }



    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        if (string.IsNullOrEmpty(_connectionString))
        {
            return Ok("DIAGNOSTICO: La connection string llegó VACÍA");
        }

        using var connection = new SqlConnection(_connectionString);
        var productos = await connection.QueryAsync<Producto>(
            "SELECT Id, Nombre, Precio, Stock FROM Productos ORDER BY Id DESC");
        return Ok(productos);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(Producto producto)
    {
        using var connection = new SqlConnection(_connectionString);
        var sql = @"INSERT INTO Productos (Nombre, Precio, Stock)
                    OUTPUT INSERTED.Id
                    VALUES (@Nombre, @Precio, @Stock)";
        producto.Id = await connection.ExecuteScalarAsync<int>(sql, producto);
        return CreatedAtAction(nameof(GetTodos), new { id = producto.Id }, producto);
    }
}