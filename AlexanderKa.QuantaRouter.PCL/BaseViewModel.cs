using System;
using System.ComponentModel;
using System.Linq.Expressions;
#if MONO 
using System.Windows.Input;
#endif 
namespace AlexanderKa.QuantaRouter.PCL
{
    using System.Windows.Input;

    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Propertychanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged<T>(Expression<Func<T>> action)
        {
            string propertyName = GetPropertyName(action);
            OnPropertyChanged(propertyName);
        }

        private static string GetPropertyName<T>(Expression<Func<T>> action)
        {
            var expression = (MemberExpression) action.Body;
            string propertyName = expression.Member.Name;
            return propertyName;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler == null) return;
            var e = new PropertyChangedEventArgs(propertyName);
            handler(this, e);
        }

        #endregion

        #region Commands 

        public class BaseCommand : ICommand
        {
            private readonly Func<bool> _CanExecute;
            private readonly Action _Command;

            public BaseCommand(Action command, Func<bool> canExecute = null)
            {
                if (command == null)
                    throw new ArgumentNullException("command");
                _CanExecute = canExecute;
                _Command = command;
            }

            public void Execute(object parameter)
            {
                _Command();
            }

            public bool CanExecute(object parameter)
            {
                return _CanExecute == null || _CanExecute();
            }

            public event EventHandler CanExecuteChanged;
        }

        public class DelegateCommand : ICommand
        {
            private readonly Action<object> _executeDelegate;


            public DelegateCommand(Action<object> executeDelegate)
            {
                _executeDelegate = executeDelegate;
            }


            public void Execute(object parameter)
            {
                _executeDelegate(parameter);
            }


            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;
        }

        public class RelayCommand : ICommand
        {
            #region Fields

            private readonly Predicate<object> _canExecute;
            private readonly Action<object> _execute;

            #endregion // Fields

            #region Constructors

            public RelayCommand(Action<object> execute)
                : this(execute, null)
            {
            }

            public RelayCommand(Action<object> execute, Predicate<object> canExecute)
            {
                if (execute == null)
                    throw new ArgumentNullException("execute");

                _execute = execute;
                _canExecute = canExecute;
            }

            #endregion // Constructors

            #region ICommand Members

            public bool CanExecute(object parameter)
            {
                return _canExecute == null ? true : _canExecute(parameter);
            }

            public event EventHandler CanExecuteChanged;


            public void Execute(object parameter)
            {
                _execute(parameter);
            }

            #endregion // ICommand Members

        }
        #endregion


    }
}