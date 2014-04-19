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
    using System.Diagnostics;

    using AlexanderKa.QuantaRouter.WindowsStore.Classes;

#endif
#if WINDOWS_PHONE
namespace CaliburnMicro.ViewModels
{
    using System.Diagnostics;
    using System.Windows;

    using CaliburnMicro.Classes;
    using Microsoft.Phone.Controls;
#endif
    using System.Collections.ObjectModel;
    using System.Threading;

    using Yandex.Metrica;

    public class MainViewModel : Conductor<IScreen>.Collection.OneActive
    {
        private INavigationService _navigationService;
        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

        }

        private ConnectedDevicesViewModel _ConnectedDevicesViewModel { get; set; }

        public ConnectedDevicesViewModel ConnectedDevicesViewModel
        {
            get
            {
                return _ConnectedDevicesViewModel;
            }
            set
            {
                if (_ConnectedDevicesViewModel != value)
                {
                    _ConnectedDevicesViewModel = value;
                    NotifyOfPropertyChange(() => ConnectedDevicesViewModel);
                }
            }
        }

        private MainInfoViewModel _MainInfoViewModel { get; set; }

        public MainInfoViewModel MainInfoViewModel
        {
            get
            {
                return _MainInfoViewModel;
            }
            set
            {
                if (_MainInfoViewModel != value)
                {
                    _MainInfoViewModel = value;
                    NotifyOfPropertyChange(() => MainInfoViewModel);
                }
            }
        }

        private MainStatusViewModel _MainStatusViewModel { get; set; }

        public MainStatusViewModel MainStatusViewModel
        {
            get
            {
                return _MainStatusViewModel;
            }
            set
            {
                if (_MainStatusViewModel != value)
                {
                    _MainStatusViewModel = value;
                    NotifyOfPropertyChange(() => MainStatusViewModel);
                }
            }
        }



        private MainStatisticsViewModel _MainStatisticsViewModel { get; set; }

        public MainStatisticsViewModel MainStatisticsViewModel
        {
            get
            {
                return _MainStatisticsViewModel;
            }
            set
            {
                if (_MainStatisticsViewModel != value)
                {
                    _MainStatisticsViewModel = value;
                    NotifyOfPropertyChange(() => MainStatisticsViewModel);
                }
            }
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

        }
        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
            this.Init();
        }

        public SynchronizationContext UISynchronizationContext;

        public async void Init()
        {
            HttpClientExtension httpClient = new HttpClientExtension();
            httpClient.DefaultRequestHeaders.ExpectContinue = false;
            Router = new Router(httpClient);
            UISynchronizationContext = SynchronizationContext.Current;
#if WINDOWS_PHONE
            Counter.Start(6493);
#endif 
#if WINDOWS8
             Counter.Start(6490);
           
#endif

            Menu = new ObservableCollection<MenuItem>();
            MainInfoViewModel = new MainInfoViewModel(_navigationService, Router);
            MainStatusViewModel = new MainStatusViewModel(_navigationService, Router);
            ConnectedDevicesViewModel = new ConnectedDevicesViewModel(_navigationService, Router);
            MainStatisticsViewModel = new MainStatisticsViewModel(_navigationService, Router);
            Menu.Add(new MenuItem() { Description = "Информация", PartialView = MainInfoViewModel });
            Menu.Add(new MenuItem() { Description = "Подключенные устройства", PartialView = ConnectedDevicesViewModel });
            Menu.Add(new MenuItem() { Description = "Роутер", PartialView = MainStatusViewModel });
            Menu.Add(new MenuItem() { Description = "Статистика", PartialView = MainStatisticsViewModel });
            // Menu.Add(new MenuItem() {Description = "Тариф", PartialView = MainTariffViewModel});
            selectedMenuItem = Menu.LastOrDefault();
            selectedMenuItem = Menu.FirstOrDefault();

            await Task.Run(() => this.TryFirstConnect());



        }
#if !WINDOWS_PHONE
        public const int TryFirstConnectCount = 10;
#else
        public const int TryFirstConnectCount = 3;
#endif
        public async void TryFirstConnect()
        {
            var TryCount = 1;
            while (TryCount <= TryFirstConnectCount)
            {
                try
                {
                    HttpClientExtension httpClient = new HttpClientExtension();
                    httpClient.DefaultRequestHeaders.ExpectContinue = false;
                    var FirstResult = await httpClient.GetStringAsync("http://status.yota.ru/status");
                    TryCount = TryFirstConnectCount + 1;
                }

                catch (Exception exception)
                {
                    TryCount++;
                    if (TryCount == TryFirstConnectCount)
                    {
                        if (UISynchronizationContext != null)
                            UISynchronizationContext.Post(state =>
                                {
                                    string notconnectedmessage =
                                        "Нет подключения к поддерживаемому устройству. \nУбедитесь в том, что устройство включено и вы подключены к сети.";
#if !WINDOWS_PHONE
                               MessageDialog DeviceNotConnectedDialog = new MessageDialog(notconnectedmessage);
                               DeviceNotConnectedDialog.ShowAsync();
#endif
#if WINDOWS_PHONE
                                    MessageBox.Show(notconnectedmessage, "Ошибка", MessageBoxButton.OK);


#endif
                                }, null);
                        Debug.WriteLine(exception);

                    }

                }
            }
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

        private ObservableCollection<MenuItem> _Menu { get; set; }

        public ObservableCollection<MenuItem> Menu
        {
            get { return _Menu; }
            set
            {
                if (_Menu != value)
                {
                    _Menu = value;
                    NotifyOfPropertyChange(() => Menu);
                }
            }
        }


        private object _selectedMenuItemView { get; set; }

        public object selectedMenuItemView
        {
            get { return _selectedMenuItemView; }
            set
            {
                if (_selectedMenuItemView != value)
                {
                    _selectedMenuItemView = value;
                    NotifyOfPropertyChange(() => selectedMenuItemView);
                }
            }
        }

        private object _selectedMenuItem { get; set; }

        public object selectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                if (_selectedMenuItem != value && value != null)
                {
                    _selectedMenuItem = value as MenuItem;
                    var menuItem = value as MenuItem;
                    if (menuItem != null)
                    {
                        this.selectedMenuItemView = menuItem.PartialView;
                    }
                    NotifyOfPropertyChange(() => selectedMenuItem);

                }
            }
        }

        public class MenuItem
        {
            public string Description { get; set; }
            public object PartialView { get; set; }
        }



    }
}
