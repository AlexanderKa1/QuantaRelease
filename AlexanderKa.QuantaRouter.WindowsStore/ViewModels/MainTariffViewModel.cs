using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexanderKa.QuantaRouter.WindowsStore.ViewModels
{
    using AlexanderKa.QuantaRouter.PCL;

    using Caliburn.Micro;

    public class MainTariffViewModel : ViewModelBase
    {
        public MainTariffViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }

        public MainTariffViewModel(INavigationService navigationService, Router router)
            : base(navigationService, router)
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
    }
}
