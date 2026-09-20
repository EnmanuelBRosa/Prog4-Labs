namespace MiApiCuadrado;

    public class CalculaelMCD  {
        public int calcularMCD(int divisor, int dividendo) {
            while (dividendo != 0)
            {
                int residuo = divisor % dividendo;
                divisor = dividendo;
                dividendo = residuo;
            }
            return divisor;
        }      
    }

