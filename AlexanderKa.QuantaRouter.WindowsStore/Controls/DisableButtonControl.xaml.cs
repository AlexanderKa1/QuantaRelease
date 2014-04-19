using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace AlexanderKa.QuantaRouter.WindowsStore.Controls
{
    using System.Threading.Tasks;

    public sealed partial class DisableButtonControl : UserControl
    {
        public DisableButtonControl()
        {
            this.InitializeComponent();
            ProgressSwitch.IsActive = false;
        }

        public static readonly DependencyProperty DisableCommandProperty =
           DependencyProperty.Register("DisableCommand", typeof(ICommand), typeof(DisableButtonControl), new PropertyMetadata(default(ICommand)));

        public ICommand DisableCommand
        {
            get
            {
                return (ICommand)GetValue(DisableCommandProperty);
            }
            set
            {
                SetValue(DisableCommandProperty, value);
            }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(string), typeof(DisableButtonControl), new PropertyMetadata(default(string), StateChangedCallBack));

        private static void StateChangedCallBack(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var obj = dependencyObject as DisableButtonControl;
            if (obj == null) return;


            if (dependencyPropertyChangedEventArgs.NewValue == null || dependencyPropertyChangedEventArgs.NewValue.ToString() == "NoNetwork"
                 )
            {

                obj.ToggleLTE.IsOn = false;
                obj.IsStateChanged = true;
            }
            else
            {
                obj.IsStateChanged = true;
                obj.ToggleLTE.IsOn = true;
            }
            
            obj.ProgressSwitch.IsActive = false;
        }

        public bool IsStateChanged = true;
        public string State
        {
            get
            {
                return (string)GetValue(StateProperty);
            }
            set
            {
                SetValue(StateProperty, value);
            }
        }

        private DispatcherTimer timer = new DispatcherTimer(); 

        private async void ToggleLTE_OnToggled(object sender, RoutedEventArgs e)
        {
            if (!IsStateChanged &&   ProgressSwitch.IsActive == false)
            {
                if (DisableCommand != null)
                {
                    ProgressSwitch.IsActive = true;

                    try
                    {
                        timer = new DispatcherTimer();
                        timer.Interval = TimeSpan.FromSeconds(15);
                        timer.Tick += TimerOnTick;
                        timer.Start();  
                     DisableCommand.Execute(null);

                    }
                    catch (Exception exception)
                    {
                        ProgressSwitch.IsActive = false;
                    }





                }
            }
            IsStateChanged = false;

        }

        private void TimerOnTick(object sender, object o)
        {
            ProgressSwitch.IsActive = false;
        }
    }
}
