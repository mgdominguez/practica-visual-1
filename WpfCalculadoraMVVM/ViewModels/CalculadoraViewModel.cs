using Azure;
using System.ComponentModel;
using System.Windows.Input;
using WpfCalculadoraMVVM.Commands;
using WpfCalculadoraMVVM.Models;

namespace WpfCalculadoraMVVM.ViewModels
{
    public class CalculadoraViewModel : INotifyPropertyChanged
    {
        private CalculadoraModel _calculadora;

        public event PropertyChangedEventHandler? PropertyChanged;

        private string _primerNumero;
        private string _segundoNumero;
        private string _resultado;
        private string _mensajeError;

        public ICommand SumarCommand { get; }
        public ICommand RestarCommand { get; }
        public ICommand MultiplicarCommand { get; }
        public ICommand DividirCommand { get; }
        public ICommand LimpiarCommand { get; }

        public CalculadoraViewModel()
        {
            _calculadora = new CalculadoraModel();
            SumarCommand = new RelayCommand(Sumar);
            RestarCommand = new RelayCommand(Restar);
            MultiplicarCommand = new RelayCommand(Multiplicar);
            DividirCommand = new RelayCommand(Dividir);
            LimpiarCommand = new RelayCommand(Limpiar);
        }

        private void Limpiar(Object parameter)
        {
            //limpiar los campos
            PrimerNumero = string.Empty;
            SegundoNumero = string.Empty;
            Resultado = string.Empty;
            MensajeError = string.Empty;
        }

        private void Dividir(Object parameter)
        {
            OperacionMatematica((a, b) => _calculadora.Dividir(a, b));
        }

        private void Multiplicar(Object parameter)
        {
            OperacionMatematica((a, b) => _calculadora.Multiplicar(a, b));
        }

        private void Restar(Object parameter)
        {
            OperacionMatematica((a, b) => _calculadora.Restar(a, b));
        }

        private void Sumar(Object parameter)
        {
            OperacionMatematica((a, b) => _calculadora.Sumar(a, b));
        }

        private void OperacionMatematica(Func<double, double, double> operacion)
        {
            try
            {
                //limpiar mensaje de error
                MensajeError = string.Empty;

                //validacion
                if (!double.TryParse(PrimerNumero, out double n1)
                    || !double.TryParse(SegundoNumero, out double n2))
                {
                    MensajeError = "Ingrese numeros validos";
                    return;
                }

                //realizar la operacion
                double resultado = operacion(n1, n2);
                Resultado = resultado.ToString();

                // Guardar la operación en la base de datos
                GuardarOperacion(Convert.ToInt32(n1), Convert.ToInt32(n2), operacion.Method.Name, Convert.ToInt32(resultado));
            }
            catch (DivideByZeroException ex)
            {
                MensajeError = ex.Message;
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
        }

        public string PrimerNumero
        {
            get => _primerNumero;
            set
            {
                _primerNumero = value;
                OnPropertyChanged(nameof(PrimerNumero));
            }
        }

        public string SegundoNumero
        {
            get => _segundoNumero;
            set
            {
                _segundoNumero = value;
                OnPropertyChanged(nameof(SegundoNumero));
            }
        }

        public string Resultado
        {
            get => _resultado;
            set
            {
                _resultado = value;
                OnPropertyChanged(nameof(Resultado));
            }
        }

        public string MensajeError
        {
            get => _mensajeError;
            set
            {
                _mensajeError = value;
                OnPropertyChanged(nameof(MensajeError));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void GuardarOperacion(int numero1, int numero2, string accion, int resultado)
        {
            using (var context = new Data.AppDbContext())
            {
                var Calculadora = new Calculadora
                {
                    Numero1 = numero1,
                    Numero2 = numero2,
                    Operacion = accion,
                    Resultado = resultado
                };
                context.Calculadora.Add(Calculadora);
                context.SaveChanges();
            }
        }
    }
}