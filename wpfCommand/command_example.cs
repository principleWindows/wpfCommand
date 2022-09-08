using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace wpfCommand
{
    internal class Command_example : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public Command_example(Action<object> executeAction, Func<object, bool> changeFunction)
        {
            this._executeAction = executeAction;
            this._changeFunction = changeFunction;
        }

        public void Execute(object parameter) => this._executeAction?.Invoke(parameter);

        public bool CanExecute(object parameter)
        {
            if (_changeFunction != null)
                return  this._changeFunction.Invoke(parameter);
            return false;
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        private readonly Action<object> _executeAction;
        private readonly Func<object, bool> _changeFunction;
    }
}
