using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace AlexanderKa.QuantaRouter.WindowsStore.Controls
{
    public sealed partial class AntennaControl : UserControl
    {
        public static readonly DependencyProperty SignalProperty =
            DependencyProperty.Register("Signal", typeof (string), typeof (AntennaControl),
                                        new PropertyMetadata(default(string), SignalPropertyChangedCallback));

        public static readonly DependencyProperty ProviderProperty =
            DependencyProperty.Register("Provider", typeof (string), typeof (AntennaControl),
                                        new PropertyMetadata(default(string), ProviderPropertyChangedCallback));

        public AntennaControl()
        {
            InitializeComponent();
            Loaded += AntennaControl_Loaded;
        }

        public string Signal
        {
            get { return (string) GetValue(SignalProperty); }
            set { SetValue(SignalProperty, value); }
        }

        public string Provider
        {
            get { return (string) GetValue(ProviderProperty); }
            set { SetValue(ProviderProperty, value); }
        }

        private void AntennaControl_Loaded(object sender, RoutedEventArgs e)
        {
            ClearSignalLevel();
        }

        private static void SignalPropertyChangedCallback(DependencyObject dependencyObject,
                                                          DependencyPropertyChangedEventArgs
                                                              dependencyPropertyChangedEventArgs)
        {
            var control = dependencyObject as AntennaControl;
            if (control != null) control.SetSignalLevel(dependencyPropertyChangedEventArgs.NewValue);
        }

        public void SetSignalLevel(object state)
        {
            ClearSignalLevel();
            if (string.IsNullOrEmpty(state.ToString())) return;
            if (int.Parse(state.ToString()) >= 1)
                Singnal1.Visibility = Visibility.Visible;
            if (int.Parse(state.ToString()) >= 2)
                Singnal2.Visibility = Visibility.Visible;
            if (int.Parse(state.ToString()) >= 3)
                Singnal3.Visibility = Visibility.Visible;
            if (int.Parse(state.ToString()) >= 4)
                Singnal4.Visibility = Visibility.Visible;
            if (int.Parse(state.ToString()) >= 5)
                Singnal5.Visibility = Visibility.Visible;
            UpdateLayout();
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
                    control.X.Visibility = Visibility.Visible;
                    control.ClearSignalLevel();
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