using System;
using System.Collections.Generic;
using System.Linq;
#if !WINDOWS_PHONE71
using System.Net.Http;
using Windows.UI.Popups;
#endif
using System.Text;
using System.Threading.Tasks;
using AlexanderKa.QuantaRouter.PCL;
using Caliburn.Micro;

#if !WINDOWS_PHONE
namespace AlexanderKa.QuantaRouter.WindowsStore.ViewModels
{
    using System.ComponentModel;

#endif
#if WINDOWS_PHONE
namespace CaliburnMicro.ViewModels
{
    using System.ComponentModel;
    
#endif

    public class ConnectedDevicesViewModel : ViewModelBase,INotifyPropertyChanged
    {
        public ConnectedDevicesViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public ConnectedDevicesViewModel(INavigationService navigationService, Router router)
            : base(navigationService)
        {
            Router = router;

          
        }

       

    }
}
