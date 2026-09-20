using Xunit;
using MiApiCuadrado;

namespace MiApiCuadrado.Tests;

public class MCDTests
{
    [Fact]
    public void MCD_De_12_y_18_DebeSer_6()
    {
        var calculadora = new CalculaelMCD();      // Arrange
        var resultado = calculadora.calcularMCD(12, 18);  // Act
        Assert.Equal(6, resultado);                // Assert
    }

    [Theory]
    [InlineData(8, 4, 4)]
    [InlineData(20, 15, 5)]
    [InlineData(7, 7, 7)]
    public void MCD_VariosCasos_DebeSerCorrecto(int divisor, int dividendo, int esperado)
    {
        var calculadora = new CalculaelMCD();                        // Arrange
        var resultado = calculadora.calcularMCD(divisor, dividendo); // Act
        Assert.Equal(esperado, resultado);                           // Assert
    }
}
