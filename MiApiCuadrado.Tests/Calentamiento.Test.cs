using Xunit;

namespace MiApiCuadrado.Tests;

public class CalentamientoTests
{
    [Fact]
    public void Sumar_DosNumeros_DebeRetornarResultadoCorrecto()
    {
        var a = 10; var b = 20;              // Arrange
        var resultado = a + b;               // Act
        Assert.Equal(30, resultado);         // Assert
    }
}