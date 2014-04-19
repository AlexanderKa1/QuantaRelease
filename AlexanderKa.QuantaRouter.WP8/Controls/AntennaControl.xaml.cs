
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace CaliburnMicro.Controls
{
    using System.Windows;
    using System.Windows.Controls;

    public sealed partial class AntennaControl : UserControl
    {
        public static readonly DependencyProperty SignalProperty =
            DependencyProperty.Register("Signal", typeof(string), typeof(AntennaControl),
                                        new PropertyMetadata(default(string), SignalPropertyChangedCallback));

        public static readonly DependencyProperty ProviderProperty =
            DependencyProperty.Register("Provider", typeof(string), typeof(AntennaControl),
                                        new PropertyMetadata(default(string), ProviderPropertyChangedCallback));

        public AntennaControl()
        {
            this.InitializeComponent();
            this.Loaded += this.AntennaControl_Loaded;
        }

        public string Signal
        {
            get { return (string)this.GetValue(SignalProperty); }
            set { this.SetValue(SignalProperty, value); }
        }

        public string Provider
        {
            get { return (string)this.GetValue(ProviderProperty); }
            set { this.SetValue(ProviderProperty, value); }
        }

        private void AntennaControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.ClearSignalLevel();
        }

        private static void SignalPropertyChangedCallback(DependencyObject dependencyObject,
                                                          DependencyPropertyChangedEventArgs
                                                              dependencyPropertyChangedEventArgs)
        {
            var control = dependencyObject as AntennaControl;
            if (control != null)
            {
                int state = -1;
                if (dependencyPropertyChangedEventArgs.NewValue != null)
                {
                    int.TryParse(dependencyPropertyChangedEventArgs.NewValue as string, out state);
                    if (state != -1)
                    {
                        control.SetSignalLevel(state);
                    }
                }


            }
        }

        public void SetSignalLevel(int state)
        {
            ClearSignalLevel();
            if (state < 1) return;
            if (state >= 1)
                this.Singnal1.Visibility = Visibility.Visible;
            if (state >= 2)
                this.Singnal2.Visibility = Visibility.Visible;
            if (state >= 3)
                this.Singnal3.Visibility = Visibility.Visible;
            if (state >= 4)
                this.Singnal4.Visibility = Visibility.Visible;
            if (state >= 5)
                this.Singnal5.Visibility = Visibility.Visible;
            this.UpdateLayout();
        }

        public void ClearSignalLevel()
        {
            Singnal1.Visibility = Visibility.Collapsed;
            Singnal2.Visibility = Visibility.Collapsed;
            Singnal3.Visibility = Visibility.Collapsed;
            Singnal4.Visibility = Visibility.Collapsed;
            Singnal5.Visibility = Visibility.Collapsed;
        }

        private static void ProviderPropertyChangedCallback(DependencyObject dependencyObject,
                                                            DependencyPropertyChangedEventArgs
                                                                dependencyPropertyChangedEventArgs)
        {
            var control = dependencyObject as AntennaControl;
            if (dependencyPropertyChangedEventArgs.NewValue == null)
            {
                if (control != null)
                {
                    control.ClearSignalLevel();
                    control.X.Visibility = Visibility.Visible;
                    control.ProviderName.Text = string.Empty;
                }

                return;
            }


            if (control != null)
            {
                control.X.Visibility = Visibility.Collapsed;
                control.ProviderName.Text = dependencyPropertyChangedEventArgs.NewValue.ToString();
            }
        }
    }
}