namespace WpfCalculadoraMVVM.Models
{
    /// <summary>
    /// Modelo que contiene la lógica de negocio para las operaciones matemáticas.
    /// En MVVM, el Modelo no conoce ni tiene referencia al ViewModel o a la Vista.
    /// </summary>
    public class CalculadoraModel
    {
        /// <summary>
        /// Realiza la operación de suma entre dos números
        /// </summary>
        /// <param name="a">Primer sumando</param>
        /// <param name="b">Segundo sumando</param>
        /// <returns>Resultado de la suma</returns>
        public double Sumar(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// Realiza la operación de resta entre dos números
        /// </summary>
        /// <param name="a">Minuendo</param>
        /// <param name="b">Sustraendo</param>
        /// <returns>Resultado de la resta</returns>
        public double Restar(double a, double b)
        {
            return a - b;
        }

        /// <summary>
        /// Realiza la operación de multiplicación entre dos números
        /// </summary>
        /// <param name="a">Primer factor</param>
        /// <param name="b">Segundo factor</param>
        /// <returns>Resultado de la multiplicación</returns>
        public double Multiplicar(double a, double b)
        {
            return a * b;
        }

        /// <summary>
        /// Realiza la operación de división entre dos números
        /// </summary>
        /// <param name="a">Dividendo</param>
        /// <param name="b">Divisor</param>
        /// <returns>Resultado de la división</returns>
        /// <exception cref="DivideByZeroException">Se lanza cuando el divisor es cero</exception>
        public double Dividir(double a, double b)
        {
            // Validación para evitar división por cero
            if (b == 0)
                throw new DivideByZeroException("No se puede dividir por cero");

            return a / b;
        }
    }
}