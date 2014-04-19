using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlexanderKa.QuantaRouter.WindowsStore.ViewModels;
using AlexanderKa.QuantaRouter.WindowsStore.Views;
using Caliburn.Micro;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.DataTransfer.ShareTarget;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace AlexanderKa.QuantaRouter.WindowsStore
{
    using Yandex.Metrica;

    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : CaliburnApplication
    {
        private WinRTContainer container;

        public App()
        {
            //ServicePointManager.DefaultConnectionLimit = 120;
            //ServicePointManager.SetTcpKeepAlive(false, 0, 0);
            //ServicePointManager.UseNagleAlgorithm = true;

            //ServicePointManager.Expect100Continue = false;

            InitializeComponent();
            
        }

        protected override void Configure()
        {
#if DEBUG
            //App.Current.DebugSettings.EnableFrameRateCounter = true;
            //App.Current.DebugSettings.IsBindingTracingEnabled = true;
           // App.Current.DebugSettings.IsOverdrawHeatMapEnabled = true;
#endif
            container = new WinRTContainer();
            container.RegisterWinRTServices();
            container.PerRequest<MainViewModel>();
       //     container.PerRequest<PolicyViewModel>();
            //container.RegisterSharingService();

            //container.RegisterSettingsService()
            //    .RegisterCommand<PolicyViewModel>("Заявление о конфиденциальности");

            //Yandex.Metrica Start
           
            //container.PerRequest<SettingsViewModel>();
            //container
            //    .PerRequest<ActionsViewModel>()
            //    .PerRequest<BindingsViewModel>()
            //    .PerRequest<CoroutineViewModel>()
            //    .PerRequest<ExecuteViewModel>()
            //    .PerRequest<MenuViewModel>()
            //    .PerRequest<NavigationTargetViewModel>()
            //    .PerRequest<NavigationViewModel>()
            //    .PerRequest<SampleSettingsViewModel>()
            //    .PerRequest<SearchViewModel>()
            //    .PerRequest<SettingsViewModel>()
            //    .PerRequest<SetupViewModel>()
            //    .PerRequest<ShareSourceViewModel>()
            //    .PerRequest<ShareTargetViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = container.GetInstance(service, key);
            if (instance != null)
                return instance;

            throw new Exception("Could not locate any instances.");
         }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }
         
        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override void PrepareViewFirst(Frame rootFrame)
        {
            container.RegisterNavigationService(rootFrame);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            DisplayRootView<MainView>();
        }

        protected override void OnSearchActivated(SearchActivatedEventArgs args)
        {
            DisplayRootView<MainView>(args.QueryText);
        }

        protected override void OnShareTargetActivated(ShareTargetActivatedEventArgs args)
        {
            // Normally wouldn't need to do this but need the container to be initialised
            Initialise();

            // replace the share operation in the container
          //  container.UnregisterHandler(typeof(ShareOperation), null);
            container.Instance(args.ShareOperation);

            DisplayRootViewFor<MainView>();
        }
    }
}
