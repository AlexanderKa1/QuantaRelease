using System;
using System.Collections.Generic;
using System.Linq;
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
    public class MainStatusViewModel : ViewModelBase
    {
        public MainStatusViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
         public MainStatusViewModel(INavigationService navigationService, Router router)
            : base(navigationService)
        {
            Router = router;
          

        }

     


       
    }
 
}
