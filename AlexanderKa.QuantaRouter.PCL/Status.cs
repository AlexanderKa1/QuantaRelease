
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AlexanderKa.QuantaRouter.PCL;
using AlexanderKa.QuantaRouter.PCL.Classes;

namespace AlexanderKa.QuantaRouter.PCL
{

    /// <summary>
    /// Статусы с устройства
    /// </summary>
    public class Status : BaseViewModel
    {
        public void CleanValues()
        {
            this.PropertiesCollection = new ObservableCollection<KeyValuePair<string, string>>();
            this.AsicVersion = this.PropertiesCollection.FirstOrDefault(i => i.Key == "AsicVersion").Value;
            this.BatteryLevel = this.PropertiesCollection.FirstOrDefault(i => i.Key == "BatteryLevel").Value;
            this.BatteryState = this.PropertiesCollection.FirstOrDefault(i => i.Key == "BatteryState").Value;
            this.CGI = this.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.CGI").Value;
            this.CI = this.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.CI").Value;
            this.CSGT = this.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.CSGT").Value;
            this.CenterFreq = this.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.CenterFreq").Value;
            this.ConnectedTime = this.PropertiesCollection.FirstOrDefault(i => i.Key == "ConnectedTime").Value;
            this.CurDownlinkThroughput = this.PropertiesCollection.FirstOrDefault(i => i.Key == "CurDownlinkThroughput").Value;
            this.CurUplinkThroughput = this.PropertiesCollection.FirstOrDefault(i => i.Key == "CurUplinkThroughput").Value;
            this.DHCP = this.PropertiesCollection.FirstOrDefault(i => i.Key == "DHCP").Value;
            this.DNS = this.PropertiesCollection.FirstOrDefault(i => i.Key == "DNS").Value;
            this.DefaultGateway = this.PropertiesCollection.FirstOrDefault(i => i.Key == "DefaultGateway").Value;
            this.DeviceName = this.PropertiesCollection.FirstOrDefault(i => i.Key == "DeviceName").Value;
            this.FirmwareVersion = this.PropertiesCollection.FirstOrDefault(i => i.Key == "FirmwareVersion").Value;
            this.HNBN = this.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.HNBN").Value;
            this.IMEI = this.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.IMEI").Value;
            this.IMEISV = this.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.IMEISV").Value;
            this.IMSI = this.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.IMSI").Value;
            this.IP = this.PropertiesCollection.FirstOrDefault(i => i.Key == "IP").Value;
            this.InterfaceType = this.PropertiesCollection.FirstOrDefault(i => i.Key == "InterfaceType").Value;
            this.IsIdle = this.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.IsIdle").Value;
            this.IsReadyForUpdate = this.PropertiesCollection.FirstOrDefault(i => i.Key == "IsReadyForUpdate").Value;
            this.MCC = this.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.MCC").Value;
            this.MNC = this.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.MNC").Value;
            this.MSISDN = this.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.MSISDN").Value;
            this.MaxDownlinkThroughput = this.PropertiesCollection.FirstOrDefault(i => i.Key == "MaxDownlinkThroughput").Value;
            this.MaxUplinkThroughput = this.PropertiesCollection.FirstOrDefault(i => i.Key == "MaxUplinkThroughput").Value;
            this.PLMN = this.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.PLMN").Value;
            this.RSRP = this.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.RSRP").Value;
            this.RSRQ = this.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.RSRQ").Value;
            this.RSSI = this.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.RSSI").Value;
            this.ReceivedBytes = this.PropertiesCollection.FirstOrDefault(i => i.Key == "ReceivedBytes").Value;
            this.RfVersion = this.PropertiesCollection.FirstOrDefault(i => i.Key == "RfVersion").Value;
            this.RoamingStatus = this.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.RoamingStatus").Value;
            this.SINR = this.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.SINR").Value;
            this.SPN = this.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.SPN").Value;
            this.SentBytes = this.PropertiesCollection.FirstOrDefault(i => i.Key == "SentBytes").Value;
            this.SessionID = this.PropertiesCollection.FirstOrDefault(i => i.Key == "SessionID").Value;
            this.State = this.PropertiesCollection.FirstOrDefault(i => i.Key == "State").Value;
            this.SubnetMask = this.PropertiesCollection.FirstOrDefault(i => i.Key == "SubnetMask").Value;
            this.SucceededHandoversCount = this.PropertiesCollection.FirstOrDefault(i => i.Key == "SucceededHandoversCount").Value;
            this.SupportsConnectDisabling = this.PropertiesCollection.FirstOrDefault(i => i.Key == "SupportsConnectDisabling").Value;
            this.TotalHandoversCount = this.PropertiesCollection.FirstOrDefault(i => i.Key == "TotalHandoversCount").Value;
            this.TxPWR = this.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.TxPWR").Value;
            this.UICCID = this.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.UICC-ID").Value;
            this.UpdateProgress = this.PropertiesCollection.FirstOrDefault(i => i.Key == "UpdateProgress").Value;
            this.UpdateState = this.PropertiesCollection.FirstOrDefault(i => i.Key == "UpdateState").Value;
            this.WebGuiUrl = this.PropertiesCollection.FirstOrDefault(i => i.Key == "WebGuiUrl").Value;
            this.WifiSecurityMode = this.PropertiesCollection.FirstOrDefault(i => i.Key == "WifiSecurityMode").Value;
            this.WifiShareMode = this.PropertiesCollection.FirstOrDefault(i => i.Key == "WifiShareMode").Value;
            this.WifiStatus = this.PropertiesCollection.FirstOrDefault(i => i.Key == "WifiStatus").Value;
            this.WifiUsers = this.PropertiesCollection.FirstOrDefault(i => i.Key == "WifiUsers").Value;
            this.eNBID = this.PropertiesCollection.FirstOrDefault(i => i.Key == "WifiUsers").Value;
            this.Wifi_Channel = this.PropertiesCollection.FirstOrDefault(i => i.Key == "Wifi_Channel").Value;
            this.Wifi_SSID = this.PropertiesCollection.FirstOrDefault(i => i.Key == "Wifi_SSID").Value;
            this.MTU = this.PropertiesCollection.FirstOrDefault(i => i.Key == "MTU").Value;
            this.MacAddrTable = new ObservableCollection<MacAddrTableItem>();
            this.Wifi_Mac = this.PropertiesCollection.FirstOrDefault(i => i.Key == "Wifi_Mac").Value;
            this.DevicesNotConnected = true;
        }
        private string _InterfaceType;
        public string InterfaceType
        {
            get { return _InterfaceType; }
            set
            {
                if (_InterfaceType != value)
                {
                    _InterfaceType = value;
                    OnPropertyChanged(() => InterfaceType);
                }
            }
        }

        private string _IMSI;
        public string IMSI
        {
            get { return _IMSI; }
            set
            {
                if (_IMSI != value)
                {
                    _IMSI = value;
                    OnPropertyChanged(() => IMSI);
                }
            }
        }

        private string _UICCID;
        public string UICCID
        {
            get { return _UICCID; }
            set
            {
                if (_UICCID != value)
                {
                    _UICCID = value;
                    OnPropertyChanged(() => UICCID);
                }
            }
        }

        private string _IMEI;

        public string IMEI
        {
            get { return _IMEI; }
            set
            {
                if (_IMEI != value)
                {
                    _IMEI = value;
                    OnPropertyChanged(() => IMEI);
                }
            }
        }

        private string _IMEISV;

        public string IMEISV
        {
            get { return _IMEISV; }
            set
            {
                if (_IMEISV != value)
                {
                    _IMEISV = value;
                    OnPropertyChanged(() => IMEISV);
                }
            }
        }

        private string _MSISDN;

        public string MSISDN
        {
            get { return _MSISDN; }
            set
            {
                if (_MSISDN != value)
                {
                    _MSISDN = value;
                    OnPropertyChanged(() => MSISDN);
                }
            }
        }

        private string _State;

        public string State
        {
            get { return _State; }
            set
            {
                if (_State != value)
                {
                    _State = value;
                    OnPropertyChanged(() => State);
                }
            }
        }

        private string _SupportsConnectDisabling;

        public string SupportsConnectDisabling
        {
            get { return _SupportsConnectDisabling; }
            set
            {
                if (_SupportsConnectDisabling != value)
                {
                    _SupportsConnectDisabling = value;
                    OnPropertyChanged(() => SupportsConnectDisabling);
                }
            }
        }

        private string _SINR;

        public string SINR
        {
            get { return _SINR; }
            set
            {
                if (_SINR != value)
                {
                    _SINR = value;
                    OnPropertyChanged(() => SINR);
                }
            }
        }

        private string _RSSI;

        public string RSSI
        {
            get { return _RSSI; }
            set
            {
                if (_RSSI != value)
                {
                    _RSSI = value;
                    OnPropertyChanged(() => RSSI);
                }
            }
        }

        private string _RSRP;

        public string RSRP
        {
            get { return _RSRP; }
            set
            {
                if (_RSRP != value)
                {
                    _RSRP = value;
                    OnPropertyChanged(() => RSRP);
                }
            }
        }

        private string _RSRQ;

        public string RSRQ
        {
            get { return _RSRQ; }
            set
            {
                if (_RSRQ != value)
                {
                    _RSRQ = value;
                    OnPropertyChanged(() => RSRQ);
                }
            }
        }

        private string _MCC;

        public string MCC
        {
            get { return _MCC; }
            set
            {
                if (_MCC != value)
                {
                    _MCC = value;
                    OnPropertyChanged(() => MCC);
                }
            }
        }

        private string _MNC;

        public string MNC
        {
            get { return _MNC; }
            set
            {
                if (_MNC != value)
                {
                    _MNC = value;
                    OnPropertyChanged(() => MNC);
                }
            }
        }

        private string _PLMN;

        public string PLMN
        {
            get { return _PLMN; }
            set
            {
                if (_PLMN != value)
                {
                    _PLMN = value;
                    OnPropertyChanged(() => PLMN);
                }
            }
        }

        private string _RoamingStatus;

        public string RoamingStatus
        {
            get { return _RoamingStatus; }
            set
            {
                if (_RoamingStatus != value)
                {
                    _RoamingStatus = value;
                    OnPropertyChanged(() => RoamingStatus);
                }
            }
        }

        private string _CGI;

        public string CGI
        {
            get { return _CGI; }
            set
            {
                if (_CGI != value)
                {
                    _CGI = value;
                    OnPropertyChanged(() => CGI);
                }
            }
        }

        private string _CI;

        public string CI
        {
            get { return _CI; }
            set
            {
                if (_CI != value)
                {
                    _CI = value;
                    OnPropertyChanged(() => CI);
                }
            }
        }

        private string _eNBID;

        public string eNBID
        {
            get { return _eNBID; }
            set
            {
                if (_eNBID != value)
                {
                    _eNBID = value;
                    OnPropertyChanged(() => eNBID);
                }
            }
        }

        private string _HNBN;

        public string HNBN
        {
            get { return _HNBN; }
            set
            {
                if (_HNBN != value)
                {
                    _HNBN = value;
                    OnPropertyChanged(() => HNBN);
                }
            }
        }

        private string _CSGT;

        public string CSGT
        {
            get { return _CSGT; }
            set
            {
                if (_CSGT != value)
                {
                    _CSGT = value;
                    OnPropertyChanged(() => CSGT);
                }
            }
        }

        private string _CenterFreq;

        public string CenterFreq
        {
            get { return _CenterFreq; }
            set
            {
                if (_CenterFreq != value)
                {
                    _CenterFreq = value;
                    OnPropertyChanged(() => CenterFreq);
                }
            }
        }

        private string _TxPWR;

        public string TxPWR
        {
            get { return _TxPWR; }
            set
            {
                if (_TxPWR != value)
                {
                    _TxPWR = value;
                    OnPropertyChanged(() => TxPWR);
                }
            }
        }

        private string _SPN;

        public string SPN
        {
            get { return _SPN; }
            set
            {
                if (_SPN != value)
                {
                    _SPN = value;
                    OnPropertyChanged(() => SPN);
                }
            }
        }

        private string _ConnectedTime;

        
        public string ConnectedTime
        {
            get { return _ConnectedTime; }
            set
            {
                if (_ConnectedTime != value)
                {
                    _ConnectedTime = value;
                    OnPropertyChanged(() => ConnectedTime);
                }
            }
        }

        private string _SessionID;

        public string SessionID
        {
            get { return _SessionID; }
            set
            {
                if (_SessionID != value)
                {
                    _SessionID = value;
                    OnPropertyChanged(() => SessionID);
                }
            }
        }

        private string _IsIdle;

        public string IsIdle
        {
            get { return _IsIdle; }
            set
            {
                if (_IsIdle != value)
                {
                    _IsIdle = value;
                    OnPropertyChanged(() => IsIdle);
                }
            }
        }

        private string _IP;

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

        private string _SubnetMask;

        public string SubnetMask
        {
            get { return _SubnetMask; }
            set
            {
                if (_SubnetMask != value)
                {
                    _SubnetMask = value;
                    OnPropertyChanged(() => SubnetMask);
                }
            }
        }

        private string _DefaultGateway;

        public string DefaultGateway
        {
            get { return _DefaultGateway; }
            set
            {
                if (_DefaultGateway != value)
                {
                    _DefaultGateway = value;
                    OnPropertyChanged(() => DefaultGateway);
                }
            }
        }

        private string _DHCP;

        public string DHCP
        {
            get { return _DHCP; }
            set
            {
                if (_DHCP != value)
                {
                    _DHCP = value;
                    OnPropertyChanged(() => DHCP);
                }
            }
        }

        private string _DNS;

        public string DNS
        {
            get { return _DNS; }
            set
            {
                if (_DNS != value)
                {
                    _DNS = value;
                    OnPropertyChanged(() => DNS);
                }
            }
        }

        private string _SentBytes;

        public string SentBytes
        {
            get { return _SentBytes; }
            set
            {
                if (_SentBytes != value)
                {
                    _SentBytes = value;
                    OnPropertyChanged(() => SentBytes);
                }
            }
        }

        private string _ReceivedBytes;

        public string ReceivedBytes
        {
            get { return _ReceivedBytes; }
            set
            {
                if (_ReceivedBytes != value)
                {
                    _ReceivedBytes = value;
                    OnPropertyChanged(() => ReceivedBytes);
                }
            }
        }

        private string _MaxDownlinkThroughput;

        public string MaxDownlinkThroughput
        {
            get { return _MaxDownlinkThroughput; }
            set
            {
                if (_MaxDownlinkThroughput != value)
                {
                    _MaxDownlinkThroughput = value;
                    OnPropertyChanged(() => MaxDownlinkThroughput);
                }
            }
        }

        private string _MaxUplinkThroughput;

        public string MaxUplinkThroughput
        {
            get { return _MaxUplinkThroughput; }
            set
            {
                if (_MaxUplinkThroughput != value)
                {
                    _MaxUplinkThroughput = value;
                    OnPropertyChanged(() => MaxUplinkThroughput);
                }
            }
        }

        private string _CurDownlinkThroughput;

        public string CurDownlinkThroughput
        {
            get { return _CurDownlinkThroughput; }
            set
            {
                if (_CurDownlinkThroughput != value)
                {
                    _CurDownlinkThroughput = value;
                    OnPropertyChanged(() => CurDownlinkThroughput);
                }
            }
        }

        private string _CurUplinkThroughput;

        public string CurUplinkThroughput
        {
            get { return _CurUplinkThroughput; }
            set
            {
                if (_CurUplinkThroughput != value)
                {
                    _CurUplinkThroughput = value;
                    OnPropertyChanged(() => CurUplinkThroughput);
                }
            }
        }

        private string _TotalHandoversCount;

        public string TotalHandoversCount
        {
            get { return _TotalHandoversCount; }
            set
            {
                if (_TotalHandoversCount != value)
                {
                    _TotalHandoversCount = value;
                    OnPropertyChanged(() => TotalHandoversCount);
                }
            }
        }

        private string _SucceededHandoversCount;

        public string SucceededHandoversCount
        {
            get { return _SucceededHandoversCount; }
            set
            {
                if (_SucceededHandoversCount != value)
                {
                    _SucceededHandoversCount = value;
                    OnPropertyChanged(() => SucceededHandoversCount);
                }
            }
        }

        private string _IsReadyForUpdate;

        public string IsReadyForUpdate
        {
            get { return _IsReadyForUpdate; }
            set
            {
                if (_IsReadyForUpdate != value)
                {
                    _IsReadyForUpdate = value;
                    OnPropertyChanged(() => IsReadyForUpdate);
                }
            }
        }

        private string _WifiStatus;

        public string WifiStatus
        {
            get { return _WifiStatus; }
            set
            {
                if (_WifiStatus != value)
                {
                    _WifiStatus = value;
                    OnPropertyChanged(() => WifiStatus);
                }
            }
        }

        private string _WifiShareMode;

        public string WifiShareMode
        {
            get { return _WifiShareMode; }
            set
            {
                if (_WifiShareMode != value)
                {
                    _WifiShareMode = value;
                    OnPropertyChanged(() => WifiShareMode);
                }
            }
        }

        private string _WifiSecurityMode;

        public string WifiSecurityMode
        {
            get { return _WifiSecurityMode; }
            set
            {
                if (_WifiSecurityMode != value)
                {
                    _WifiSecurityMode = value;
                    OnPropertyChanged(() => WifiSecurityMode);
                }
            }
        }

        private string _WifiUsers;

        public string WifiUsers
        {
            get { return _WifiUsers; }
            set
            {
                if (_WifiUsers != value)
                {
                    _WifiUsers = value;
                    OnPropertyChanged(() => WifiUsers);
                }
            }
        }

        private string _BatteryState;

        public string BatteryState
        {
            get { return _BatteryState; }
            set
            {
                if (_BatteryState != value)
                {
                    _BatteryState = value;
                    OnPropertyChanged(() => BatteryState);
                }
            }
        }

        private string _BatteryLevel;

        public string BatteryLevel
        {
            get { return _BatteryLevel; }
            set
            {
                if (_BatteryLevel != value)
                {
                    _BatteryLevel = value;
                    OnPropertyChanged(() => BatteryLevel);
                }
            }
            
        }

        private string _DeviceName;

        public string DeviceName
        {
            get { return _DeviceName; }
            set
            {
                if (_DeviceName != value)
                {
                    _DeviceName = value;
                    OnPropertyChanged(() => DeviceName);
                }
            }
        }

        private string _RfVersion;

        public string RfVersion
        {
            get { return _RfVersion; }
            set
            {
                if (_RfVersion != value)
                {
                    _RfVersion = value;
                    OnPropertyChanged(() => RfVersion);
                }
            }
        }

        private string _AsicVersion;

        public string AsicVersion
        {
            get { return _AsicVersion; }
            set
            {
                if (_AsicVersion != value)
                {
                    _AsicVersion = value;
                    OnPropertyChanged(() => AsicVersion);
                }
            }
        }

        private string _FirmwareVersion;

        public string FirmwareVersion
        {
            get { return _FirmwareVersion; }
            set
            {
                if (_FirmwareVersion != value)
                {
                    _FirmwareVersion = value;
                    OnPropertyChanged(() => FirmwareVersion);
                }
            }
        }

        private string _WebGuiUrl;

        public string WebGuiUrl
        {
            get { return _WebGuiUrl; }
            set
            {
                if (_WebGuiUrl != value)
                {
                    _WebGuiUrl = value;
                    OnPropertyChanged(() => WebGuiUrl);
                }
            }
        }

        private string _UpdateState;

        public string UpdateState
        {
            get { return _UpdateState; }
            set
            {
                if (_UpdateState != value)
                {
                    _UpdateState = value;
                    OnPropertyChanged(() => UpdateState);
                }
            }
        }

        private string _UpdateProgress;

        public string UpdateProgress
        {
            get { return _UpdateProgress; }
            set
            {
                if (_UpdateProgress != value)
                {
                    _UpdateProgress = value;
                    OnPropertyChanged(() => UpdateProgress);
                }
            }
        }
     

        /// <summary>
        /// Коллекция элементов 
        /// </summary>
        private ObservableCollection<KeyValuePair<string, string>> _propertiesCollection;
        public ObservableCollection<KeyValuePair<string, string>> PropertiesCollection
        {
            get
            {
                return this._propertiesCollection;
            }

            set
            {
                if(_propertiesCollection != value)
                {
                this._propertiesCollection = value;
                OnPropertyChanged(() => PropertiesCollection);
                }
            }
        }

        private ObservableCollection<MacAddrTableItem> _macAddrTable = new ObservableCollection<MacAddrTableItem>();
        public ObservableCollection<MacAddrTableItem> MacAddrTable
        {
            get
            {
                return this._macAddrTable;
            }

            set
            {
                if (_macAddrTable != value)
                {
                    this._macAddrTable = value;
                    OnPropertyChanged(() => MacAddrTable);
                }
            }
        }

        private string _Wifi_Mac { get; set; }

        public string Wifi_Mac
        {
            get { return _Wifi_Mac; }
            set
            {
                if (_Wifi_Mac != value)
                {
                    _Wifi_Mac = value;
                    OnPropertyChanged(() => Wifi_Mac);
                }
            }
        }

        private string _Wifi_SSID { get; set; }

        public string Wifi_SSID
        {
            get { return _Wifi_SSID; }
            set
            {
                if (_Wifi_SSID != value)
                {
                    _Wifi_SSID = value;
                    OnPropertyChanged(() => Wifi_SSID);
                }
            }
        }

        private string _Wifi_Channel { get; set; }

        public string Wifi_Channel
        {
            get { return _Wifi_Channel; }
            set
            {
                if (_Wifi_Channel != value)
                {
                    _Wifi_Channel = value;
                    OnPropertyChanged(() => Wifi_Channel);
                }
            }
        }

        private string _MTU { get; set; }

        public string MTU
        {
            get { return _MTU; }
            set
            {
                if (_MTU != value)
                {
                    _MTU = value;
                    OnPropertyChanged(() => MTU);
                }
            }
        }

        private string _SignalLevel { get; set; }

        public string SignalLevel
        {
            get
            {
                return _SignalLevel;
            }
            set
            {
                if (_SignalLevel != value)
                {
                    _SignalLevel = value;
                    OnPropertyChanged(() => SignalLevel);
                }
            }
        }

        private bool _DevicesNotConnected = true;

        public bool DevicesNotConnected
        {
            get
            {
                return _DevicesNotConnected;
            }
            set
            {
                if (_DevicesNotConnected != value)
                {
                    _DevicesNotConnected = value;
                    OnPropertyChanged(() => DevicesNotConnected);
                }
            }
        }
    }

}
