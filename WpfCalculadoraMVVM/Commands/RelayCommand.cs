using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfCalculadoraMVVM.Commands
{
    /// <summary>
    /// Implementación de ICommand que permite enlazar comandos UI con métodos en el ViewModel.
    /// Es un patrón común en MVVM para manejar acciones del usuario desde la Vista.
    /// </summary>
    public class RelayCommand : ICommand
    {
        // Delegados para las acciones de ejecución y verificación de si se puede ejecutar
        private readonly Action<object> _execute;

        private readonly Predicate<object> _canExecute;

        /// <summary>
        /// Constructor que inicializa un nuevo comando.
        /// </summary>
        /// <param name="execute">Acción a ejecutar cuando se invoca el comando</param>
        /// <param name="canExecute">Función que determina si el comando puede ejecutarse (opcional)</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// Evento que se dispara cuando cambian las condiciones que determinan si el comando puede ejecutarse.
        /// Se registra con el CommandManager para que los controles de UI puedan actualizarse automáticamente.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Determina si el comando puede ejecutarse en su estado actual.
        /// </summary>
        /// <param name="parameter">Parámetro pasado al comando</param>
        /// <returns>True si el comando puede ejecutarse, False en caso contrario</returns>
        public bool CanExecute(object parameter)
        {
            // Si no hay una función de validación, siempre se puede ejecutar
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>
        /// Ejecuta la acción asociada al comando.
        /// </summary>
        /// <param name="parameter">Parámetro pasado al comando</param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}