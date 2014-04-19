using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if Mono
using System.Threading.Tasks;
#endif

namespace AlexanderKa.QuantaRouter.PCL.Classes
{
    public class MacAddrTableItem : BaseViewModel
    {
        private string _MAC { get; set; }

        public string MAC
        {
            get { return _MAC; }
            set
            {
                if (_MAC != value)
                {
                    _MAC = value;
                    OnPropertyChanged(() => MAC);
                }
            }
        }

        private string _IP { get; set; }

        public string IP
        {
            get { return _IP; }
            set
            {
                if (_IP != value)
                {
                    _IP = value;
                    OnPropertyChanged(() => IP);
                }
            }
        }

        private string _Host { get; set; }

        public string Host
        {
            get { return _Host; }
            set
            {
                if (_Host != value)
                {
                    _Host = value;
                    OnPropertyChanged(() => Host);
                }
            }
        }

        private string _Time { get; set; }

        public string Time
        {
            get { return _Time; }
            set
            {
                if (_Time != value)
                {
                    _Time = value;
                    OnPropertyChanged(() => Time);
                }
            }
        }
    }
}
