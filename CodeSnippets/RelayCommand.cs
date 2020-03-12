using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Mvvm.Core
{
    public class RelayCommand : ICommand
    {
        public RelayCommand(Action exec, Func<bool> canExec)
        {
            m_Execute = exec;
            m_CanExecute = canExec;
        }

        public bool CanExecute(object parameter)
        {
            return m_CanExecute();
        }

        public event EventHandler CanExecuteChanged;
        private Action m_Execute;
        private Func<bool> m_CanExecute;

        public void Execute(object parameter)
        {
            m_Execute();
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
