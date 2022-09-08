using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Console;
using Microsoft.VisualStudio.PlatformUI;

namespace wpfCommand
{
    public class ViewModel_example
    {
        public ICommand Command_example => new Command_example(Do_something_in_VM, Can_do_something_in_VM);
                                            // new Action<object>(this.Do_something_in_VM)
                                            // new Func<object, bool>(this.Can_do_something_in_VM)

        // Declaration a command for this ViewModel as public properties
        public DelegateCommand Delegate_command_example { get; private set; }

        // Constructor
        public ViewModel_example ()
        {
            // initialization of the commands
            Delegate_command_example = new DelegateCommand(Action_execute_in_VM, Func_canExecute_in_VM);
        }

        public bool IsCanExec { get; set; } = true;

        private string _title = "title";
        public String Title
        {
            get { return this._title; }
            set
            {
                if (value == this._title) return;

                this._title = value;
            }
        }

        private static Action Action_execute_in_VM = () => {
            Debug.WriteLine("Delegate command Executed!"); };

        private bool Func_canExecute_in_VM ()
        { 
            return IsCanExec;
        }

        private void Do_something_in_VM(object param)
        {
            Debug.WriteLine("Command Executed!");
        }

        private bool Can_do_something_in_VM(object param)
        {
            return IsCanExec;
        }
    }
}
