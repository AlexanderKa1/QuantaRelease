using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

#if !WINDOWS_PHONE
namespace AlexanderKa.QuantaRouter.WindowsStore.ViewModels
{
#endif
#if WINDOWS_PHONE
namespace CaliburnMicro.ViewModels
{
#endif
    using AlexanderKa.QuantaRouter.PCL;

    public class ViewModelBase : Screen  
    {
        private readonly INavigationService _navigationService;

        public ViewModelBase(INavigationService navigationService)
        {
            _navigationService = navigationService;

        }
     
        public ViewModelBase(INavigationService navigationService, Router router)
           
        {
            Router = router;
          

        }

     


        private Router _Router { get; set; }

        public Router Router
        {
            get { return _Router; }
            set
            {
                if (_Router != value)
                {
                    _Router = value;
                    NotifyOfPropertyChange(() => Router);
                }
            }
        }
    

        public void GoBack()
        {
            _navigationService.GoBack();
        }

        public bool CanGoBack
        {
            get { return _navigationService.CanGoBack; }
        }


        public class BaseViewModel : INotifyPropertyChanged
        {





            protected void OnPropertyChanged<T>(Expression<Func<T>> action)
            {
                var propertyName = GetPropertyName(action);
                OnPropertyChanged(propertyName);
            }

            private static string GetPropertyName<T>(Expression<Func<T>> action)
            {
                var expression = (MemberExpression)action.Body;
                var propertyName = expression.Member.Name;
                return propertyName;
            }

            private void OnPropertyChanged(string propertyName)
            {
                var handler = PropertyChanged;
                if (handler == null) return;
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }

            public event PropertyChangedEventHandler PropertyChanged;



        }

        public class ObservableObject<T> : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(Expression<Func<T, object>> property)
            {
                if (property == null || property.Body == null) return;

                var memberExp = property.Body as MemberExpression;
                if (memberExp == null)
                {
                    UnaryExpression unary = property.Body as UnaryExpression;
                    if (unary != null) memberExp = unary.Operand as MemberExpression;
                    if (memberExp == null) return;
                }

                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new PropertyChangedEventArgs(memberExp.Member.Name));
            }
        }



    }
}
