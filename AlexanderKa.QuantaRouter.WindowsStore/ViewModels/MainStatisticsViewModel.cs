using System;
#if !WINDOWS_PHONE
namespace AlexanderKa.QuantaRouter.WindowsStore.ViewModels
{
using Windows.UI.Xaml;
#endif
using System.Windows.Threading;

#if WINDOWS_PHONE
namespace CaliburnMicro.ViewModels
{
#endif
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Globalization;

using AlexanderKa.QuantaRouter.PCL;

    using Caliburn.Micro;

    using Sparrow.Chart;

    public class MainStatisticsViewModel : ViewModelBase
    {
        public MainStatisticsViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }

        public MainStatisticsViewModel(INavigationService navigationService, Router router)
            : base(navigationService, router)
        {
            Router = router;
            starTime = DateTime.Now.AddSeconds(-60);
            this.RSRPCollection = new ObservableCollection<Data>();
            for (int i = 0; i < 60; i++)
            {
                this.RSRPCollection.Add(new Data(DateTime.Now, (DateTime.Now - starTime).TotalSeconds, 0, 0, 0,0,0,0));

            }
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += TimerOnTick;
            timer.Start();
        }

        private DateTime starTime;
        double rsrp;
        double rsrq;
        double rssi;
        double sinr;
        double downloaded;
        double sent;
        private void TimerOnTick(object sender, object o)
        {

          
            double.TryParse(Router.Status.RSRP, NumberStyles.Any, CultureInfo.InvariantCulture, out rsrp);
            double.TryParse(Router.Status.RSRQ, NumberStyles.Any, CultureInfo.InvariantCulture, out rsrq);
            double.TryParse(Router.Status.RSSI, NumberStyles.Any, CultureInfo.InvariantCulture, out rssi);
            double.TryParse(Router.Status.SINR, NumberStyles.Any, CultureInfo.InvariantCulture, out sinr);
            double.TryParse(Router.Status.SentBytes,NumberStyles.Any,CultureInfo.InvariantCulture,out sent);
            double.TryParse(Router.Status.ReceivedBytes, NumberStyles.Any, CultureInfo.InvariantCulture, out downloaded);

            
            RSRQLabel = "RSRQ " + rsrq.ToString("F")+ " dB";
            RSRPLabel = "RSRP " + rsrp.ToString("F") + " dBm";
            RSSILabel = "RSSI " + rssi.ToString("F") + " dBm";
            SINRLabel = "SINR " + sinr.ToString("F") + " dB";
            DownloadedLabel = "Получено "+(downloaded/1048576).ToString("F") + "Мб";
            SentLabel = "Отправлено "+(sent/1048576).ToString("F")	 + " Мб";
           
            this.RSRPCollection.Add(new Data(DateTime.Now, (DateTime.Now - starTime).TotalSeconds, rsrp, rssi, rsrq, sinr, Math.Round(downloaded / 1048576, 2), Math.Round(sent / 1048576, 2)));
            this.RSRPCollection.RemoveAt(0);
           
            


        }

        private double _MinValue { get; set; }

        public double MinValue
        {
            get
            {
                return _MinValue;
            }
            set
            {
                if (_MinValue != value)
                {
                    _MinValue = value;
                    NotifyOfPropertyChange(() => MinValue);
                }
            }
        }

        private double _MaxValue { get; set; }

        public double MaxValue
        {
            get
            {
                return _MaxValue;
            }
            set
            {
                if (_MaxValue != value)
                {
                    _MaxValue = value;
                    NotifyOfPropertyChange(() => MaxValue);
                }
            }
        }

        private string _DownloadedLabel { get; set; }

        public string DownloadedLabel
        {
            get
            {
                return this._DownloadedLabel;
            }
            set
            {
                if (this._DownloadedLabel != value)
                {
                    this._DownloadedLabel = value;
                    NotifyOfPropertyChange(() => this.DownloadedLabel);
                }
            }
        }

        private string _SentLabel { get; set; }

        public string SentLabel
        {
            get
            {
                return this._SentLabel;
            }
            set
            {
                if (this._SentLabel != value)
                {
                    this._SentLabel = value;
                    NotifyOfPropertyChange(() => this.SentLabel);
                }
            }
        }

        private string _RSRQLabel { get; set; }

        public string RSRQLabel
        {
            get
            {
                return _RSRQLabel;
            }
            set
            {
                if (_RSRQLabel != value)
                {
                    _RSRQLabel = value;
                    NotifyOfPropertyChange(() => RSRQLabel);
                }
            }
        }

        private string _RSRPLabel { get; set; }

        public string RSRPLabel
        {
            get
            {
                return _RSRPLabel;
            }
            set
            {
                if (_RSRPLabel != value)
                {
                    _RSRPLabel = value;
                    NotifyOfPropertyChange(() => RSRPLabel);
                }
            }
        }

        private string _RSSILabel { get; set; }

        public string RSSILabel
        {
            get
            {
                return _RSSILabel;
            }
            set
            {
                if (_RSSILabel != value)
                {
                    _RSSILabel = value;
                    NotifyOfPropertyChange(() => RSSILabel);
                }
            }
        }

        private string _SINRLabel { get; set; }

        public string SINRLabel
        {
            get
            {
                return _SINRLabel;
            }
            set
            {
                if (_SINRLabel != value)
                {
                    _SINRLabel = value;
                    NotifyOfPropertyChange(() => SINRLabel);
                }
            }
        }

        private ObservableCollection<Data> rsrpCollection;
        public ObservableCollection<Data> RSRPCollection
        {
            get { return this.rsrpCollection; }
            set { this.rsrpCollection = value; this.NotifyOfPropertyChange(() => this.RSRPCollection); }
        }

       


        private DispatcherTimer timer;
      



    }

    public class Data
    {
        public Data()
        {

        }
        public Data(DateTime date, double value, double rsrp, double rssi, double rsrq,double sinr,double downloaded, double sent)
        {
            Date = DateTime.Now;
            Value = value;
            RSRP = rsrp;
            RSSI = rssi;
            RSRQ = rsrq;
            SINR = sinr;
            Downloaded = downloaded;
            Sent = sent;
        }

        public DateTime Date
        {
            get;
            set;
        }
        public double Value
        {
            get;
            set;
        }

        public double RSRP
        {
            get;
            set;
        }
        public double RSSI
        {
            get;
            set;
        }
        public double RSRQ
        {
            get;
            set;
        }
        public double SINR { get; set; }

        public double Downloaded { get; set; }
        public double Sent { get; set; }

    }

    public class Datas
    {
        public static ObservableCollection<Data> FourierSeries(double amplitude, double phaseShift, Router router)
        {
            ObservableCollection<Data> doublePoints = new ObservableCollection<Data>();
            var count = 5000;
            var doublePoint = new Data();

            double time = DateTime.Now.Ticks;
            double wn = 2 * Math.PI / (count / 10);

            doublePoint.Value = time;
            double reciviedBytesDouble = new double();
            Double.TryParse(router.Status.RSSI, out reciviedBytesDouble);
            Debug.WriteLine(reciviedBytesDouble);
           
            doublePoints.Add(doublePoint);
            return doublePoints;
        }

        public static ObservableCollection<DoublePoint> EEG(int count, ref double startPhase, double phaseStep)
        {
            var doublePoints = new ObservableCollection<DoublePoint>();
            var rand = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < count; i++)
            {
                var doublePoint = new DoublePoint();

                var time = i / (double)count;
                doublePoint.Data = time;
                doublePoint.Value = 0.05 * (rand.NextDouble() - 0.5) + 1.0;

                doublePoints.Add(doublePoint);
                startPhase += phaseStep;
            }

            return doublePoints;
        }

        public static ObservableCollection<DoublePoint> SquirlyWave()
        {
            var doublePoints = new ObservableCollection<DoublePoint>();
            var rand = new Random((int)DateTime.Now.Ticks);

            const int COUNT = 1000;
            for (int i = 0; i < COUNT; i++)
            {
                var doublePoint = new DoublePoint();

                var time = i / (double)COUNT;
                doublePoint.Data = time;
                doublePoint.Value = time * Math.Sin(2 * Math.PI * i / (double)COUNT) +
                             0.2 * Math.Sin(2 * Math.PI * i / (COUNT / 7.9)) +
                             0.05 * (rand.NextDouble() - 0.5) +
                             1.0;

                doublePoints.Add(doublePoint);
            }

            return doublePoints;
        }
    }
}
