using System;
using System.Windows.Input;

namespace Contacts.ViewModels.Commands
{
	public class RelayCommand : ICommand
	{
		private readonly Action _execute;
		private readonly Func<bool> _canExecute;

		public event EventHandler CanExecuteChanged;

		public virtual bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;
		public virtual void Execute(object parameter) => _execute.Invoke();

		public RelayCommand(Action execute)
		{
			_execute = execute;
		}

		public RelayCommand(Action execute, Func<bool> canExecute)
			: this(execute)
		{
			_canExecute = canExecute;
		}

		public virtual void OnCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}
	}

	public class RelayCommand<T> : RelayCommand
	{
		private readonly Func<T, bool> _canExecuet;
		private readonly Action<T> _execute;

		public RelayCommand(Action<T> execute) 
			: base(null)
		{
			_execute = execute;
		}

		public RelayCommand(Action<T> execute, Func<T, bool> canExecuet)
			: this(execute)
		{
			_canExecuet = canExecuet;
		}

		public override bool CanExecute(object parameter)
		{
			return (_canExecuet?.Invoke((T)parameter)) ?? true;
		}

		public override void Execute(object parameter)
		{
			_execute((T) parameter);
		}

	}

}
