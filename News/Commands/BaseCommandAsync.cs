using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace News.Commands
{
    internal abstract class BaseCommandAsync : ICommand
    {
        public bool CanExecuting
        {
            get => _canExecuting;
            set
            {
                _canExecuting = value;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler CanExecuteChanged;

        public BaseCommandAsync(Action<Exception> onException)
        {
            _onException = onException;
        }

        public bool CanExecute(object parameter) => !CanExecuting;

        public async void Execute(object parameter)
        {
            CanExecuting = true;
            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception ex)
            {
                _onException?.Invoke(ex);
            }
            CanExecuting = false;
        }

        public abstract Task ExecuteAsync(object parametr);

        private bool _canExecuting;

        protected Action<Exception> _onException;
    }
}
