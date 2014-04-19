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
#endif
#if WINDOWS_PHONE
namespace CaliburnMicro.ViewModels
{
#endif

    public class MainInfoViewModel : ViewModelBase
    {
        public MainInfoViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
        
        

        public MainInfoViewModel(INavigationService navigationService, Router router)
            : base(navigationService)
        {
            Router = router;
          

        }

     


       
    }
}
