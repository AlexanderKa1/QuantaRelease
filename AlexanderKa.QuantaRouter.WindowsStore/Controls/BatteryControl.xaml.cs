using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace AlexanderKa.QuantaRouter.WindowsStore.Controls
{
    public sealed partial class BatteryControl : UserControl
    {
        public BatteryControl()
        {
            this.InitializeComponent();
            this.Loaded += BatteryControl_Loaded;
           
        }

        private double Full;
        private double OnePercent;
        void BatteryControl_Loaded(object sender, RoutedEventArgs e)
        {
             Full = PrecentGrid.ActualWidth;
             OnePercent = Full/100;
             PercentValue.Text = string.Empty;
             PrecentGrid.Width = 0;
             PrecentGrid.Visibility = Visibility.Visible;
             BatteryImage.Source = new BitmapImage(new Uri("ms-appx:///Images/battery.png"));
             
        }

         public static readonly DependencyProperty ChargingStateProperty =
            DependencyProperty.Register("ChargingState", typeof (string), typeof (BatteryControl), new PropertyMetadata(default(string),ChargingStatePropertyChangedCallback));

        private static void ChargingStatePropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var control = dependencyObject as BatteryControl;
            if (control != null) control.SetChargingState(dependencyPropertyChangedEventArgs.NewValue);
        }

        public string ChargingState
        {
            get { return (string) GetValue(ChargingStateProperty); }
            set { SetValue(ChargingStateProperty, value); }
        }

        public static readonly DependencyProperty BatteryPrecentProperty =
            DependencyProperty.Register("BatteryPrecent", typeof(string), typeof(BatteryControl), new PropertyMetadata(default(string), BatteryPrecentPropertyChangedCallback));

        private static void BatteryPrecentPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var control = dependencyObject as BatteryControl;
            if (control != null) control.SetBatteryPrecent(dependencyPropertyChangedEventArgs.NewValue);
        }

        public string BatteryPrecent
        {
            get { return (string) GetValue(BatteryPrecentProperty); }
            set { SetValue(BatteryPrecentProperty, value); }
        }

        public void SetChargingState(object state)
        {
            if (state == null)
            {
                PrecentGrid.Visibility = Visibility.Visible;
                BatteryImage.Source = new BitmapImage(new Uri("ms-appx:///Images/battery.png"));
                return;
                
            }
            if (state.ToString() == "Charging")
            {
                PrecentGrid.Visibility = Visibility.Collapsed; 
                BatteryImage.Source = new BitmapImage(new Uri("ms-appx:///Images/batterycharging.png"));
            }
            else
            {
                PrecentGrid.Visibility = Visibility.Visible;
                BatteryImage.Source = new BitmapImage(new Uri("ms-appx:///Images/battery.png"));
            }
        }

        public void SetBatteryPrecent(object percentobject)
        {
            if (percentobject == null)
            {
                PercentValue.Text = string.Empty;
                PrecentGrid.Width = 0;
                return;
            }
            var percent = percentobject.ToString();
            int result = 0;
            int.TryParse(percent, out result);
            if (PrecentGrid != null && PrecentGrid.HorizontalAlignment != HorizontalAlignment.Left)
            {
                PrecentGrid.HorizontalAlignment = HorizontalAlignment.Left;
            }
            PercentValue.Text = result + "%";
            var gridWidth = result*OnePercent;
            if (PrecentGrid != null) PrecentGrid.Width = gridWidth;
        }
    }
}
