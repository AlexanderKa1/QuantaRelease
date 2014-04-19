// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace CaliburnMicro.Controls
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;

    public sealed partial class BatteryControl : UserControl
    {
        public BatteryControl()
        {
            this.InitializeComponent();
            this.Loaded += this.BatteryControl_Loaded;
           
        }

        private double Full;
        private double OnePercent;
        void BatteryControl_Loaded(object sender, RoutedEventArgs e)
        {
             this.Full = this.PrecentGrid.ActualWidth;
             this.OnePercent = this.Full/100;
             this.PercentValue.Text = string.Empty;
             this.PrecentGrid.Width = 0;
             this.PrecentGrid.Visibility = Visibility.Visible;
             this.BatteryImage.Source = new BitmapImage(new Uri("../Images/battery.png",UriKind.RelativeOrAbsolute));
             
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
            get { return (string) this.GetValue(ChargingStateProperty); }
            set { this.SetValue(ChargingStateProperty, value); }
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
            get { return (string) this.GetValue(BatteryPrecentProperty); }
            set { this.SetValue(BatteryPrecentProperty, value); }
        }

        public void SetChargingState(object state)
        {
            if (state == null)
            {
                this.PrecentGrid.Visibility = Visibility.Visible;
                this.BatteryImage.Source = new BitmapImage(new Uri("../Images/battery.png", UriKind.RelativeOrAbsolute));
                return;
                
            }
            if (state.ToString() == "Charging")
            {
                this.PrecentGrid.Visibility = Visibility.Collapsed;
                this.BatteryImage.Source = new BitmapImage(new Uri("../Images/batterycharging.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                this.PrecentGrid.Visibility = Visibility.Visible;
                this.BatteryImage.Source = new BitmapImage(new Uri("../Images/battery.png", UriKind.RelativeOrAbsolute));
            }
        }

        public void SetBatteryPrecent(object percentobject)
        {
            if (percentobject == null)
            {
                this.PercentValue.Text = string.Empty;
                this.PrecentGrid.Width = 0;
                return;
            }
            var percent = percentobject.ToString();
            int result = 0;
            int.TryParse(percent, out result);
            if (this.PrecentGrid != null && this.PrecentGrid.HorizontalAlignment != HorizontalAlignment.Left)
            {
                this.PrecentGrid.HorizontalAlignment = HorizontalAlignment.Left;
            }
            this.PercentValue.Text = result + "%";
            var gridWidth = result*this.OnePercent;
            if (this.PrecentGrid != null) this.PrecentGrid.Width = gridWidth;
        }
    }
}
