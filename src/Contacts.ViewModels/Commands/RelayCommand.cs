using System;
using System.Windows.Input;

namespace Contacts.ViewModels.Commands
{
	public class RelayCommand : ICommand
	{
		private readonly Action<object> _execute;
		private readonly Predicate<object> _canExecute;

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter) => _canExecute.Invoke(parameter);
		public void Execute(object parameter) => _execute.Invoke(parameter);
		
		public RelayCommand(Action<object> execute, Predicate<object> canExecute)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		public void RaiseCanExecuteChangedEvent()
		{
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}
