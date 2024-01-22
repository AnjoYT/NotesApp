using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotesApp.Commands
{
    internal class RelayCommands : ICommand
    {
        private Action _operation;
        public event EventHandler? CanExecuteChanged;
        public RelayCommands(Action operation)
        {
            _operation = operation;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _operation();
        }
    }
}
