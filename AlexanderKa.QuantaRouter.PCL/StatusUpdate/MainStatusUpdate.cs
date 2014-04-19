using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
#if Mono
using System.Threading.Tasks;
#endif
using AlexanderKa.QuantaRouter.PCL.Interfaces;

namespace AlexanderKa.QuantaRouter.PCL.StatusUpdate
{
    using System.Threading.Tasks;

    public class MainStatusUpdate : IStatusUpdate 
    {
        public async Task<bool> ParseStatus(string html)
        {
            try
            {
                UIContext.Post(delegate(object state)
                    {


                        LoadStatusFromHtml((string)state);



                    }, html);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public SynchronizationContext UIContext { get; set; }
        public Router router { get; set; }
        public string url { get { return "http://status.yota.ru/status"; } }

        /// <summary>
        /// Обновляем статус
        /// </summary>
        /// <param name="htmlContent">html код http://status.yota.ru/status </param>
        internal void LoadStatusFromHtml(string htmlContent)
        {
            var z = HtmlToStatusFields(htmlContent);
            router.Status.PropertiesCollection = new ObservableCollection<KeyValuePair<string, string>>(z);
            router.Status.AsicVersion = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "AsicVersion").Value;
            router.Status.BatteryLevel = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "BatteryLevel").Value;
            router.Status.BatteryState = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "BatteryState").Value;
            router.Status.CGI = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.CGI").Value;
            router.Status.CI = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.CI").Value;
            router.Status.CSGT = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.CSGT").Value;
            router.Status.CenterFreq = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.CenterFreq").Value;
            router.Status.ConnectedTime = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "ConnectedTime").Value;
            router.Status.CurDownlinkThroughput = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "CurDownlinkThroughput").Value;
            router.Status.CurUplinkThroughput = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "CurUplinkThroughput").Value;
            router.Status.DHCP = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "DHCP").Value;
            router.Status.DNS = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "DNS").Value;
            router.Status.DefaultGateway = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "DefaultGateway").Value;
            router.Status.DeviceName = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "DeviceName").Value;
            router.Status.FirmwareVersion = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "FirmwareVersion").Value;
            router.Status.HNBN = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.HNBN").Value;
            router.Status.IMEI = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.IMEI").Value;
            router.Status.IMEISV = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.IMEISV").Value;
            router.Status.IMSI = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.IMSI").Value;
            router.Status.IP = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "IP").Value;
            router.Status.InterfaceType = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "InterfaceType").Value;
            router.Status.IsIdle = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.IsIdle").Value;
            router.Status.IsReadyForUpdate = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "IsReadyForUpdate").Value;
            router.Status.MCC = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.MCC").Value;
            router.Status.MNC = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.MNC").Value;
            router.Status.MSISDN = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.MSISDN").Value;
            router.Status.MaxDownlinkThroughput = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "MaxDownlinkThroughput").Value;
            router.Status.MaxUplinkThroughput = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "MaxUplinkThroughput").Value;
            router.Status.PLMN = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.PLMN").Value;
            router.Status.RSRP = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.RSRP").Value;
            router.Status.RSRQ = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.RSRQ").Value;
            router.Status.RSSI = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.RSSI").Value;
            router.Status.ReceivedBytes = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "ReceivedBytes").Value;
            router.Status.RfVersion = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "RfVersion").Value;
            router.Status.RoamingStatus = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.RoamingStatus").Value;
            router.Status.SINR = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.SINR").Value;
            router.Status.SPN = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.SPN").Value;
            router.Status.SentBytes = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "SentBytes").Value;
            router.Status.SessionID = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "SessionID").Value;
            router.Status.State = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "State").Value;
            router.Status.SubnetMask = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "SubnetMask").Value;
            router.Status.SucceededHandoversCount = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "SucceededHandoversCount").Value;
            router.Status.SupportsConnectDisabling = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "SupportsConnectDisabling").Value;
            router.Status.TotalHandoversCount = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "TotalHandoversCount").Value;
            router.Status.TxPWR = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.TxPWR").Value;
            router.Status.UICCID = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "3GPP.UICC-ID").Value;
            router.Status.UpdateProgress = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "UpdateProgress").Value;
            router.Status.UpdateState = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "UpdateState").Value;
            router.Status.WebGuiUrl = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "WebGuiUrl").Value;
            router.Status.WifiSecurityMode = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "WifiSecurityMode").Value;
            router.Status.WifiShareMode = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "WifiShareMode").Value;
            router.Status.WifiStatus = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "WifiStatus").Value;
            router.Status.WifiUsers = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "WifiUsers").Value;
            router.Status.eNBID = router.Status.PropertiesCollection.FirstOrDefault(i => i.Key == "WifiUsers").Value;
        }
        /// <summary>
        /// Преобразовывем код из формата параметр = значение в лист
        /// </summary>
        /// <param name="sourcecode">исходный код</param>
        /// <returns></returns>
        private List<KeyValuePair<string, string>> HtmlToStatusFields(string sourcecode)
        {
            return (from line in sourcecode.Split('\n') where line.Contains("=") select line.Split('=') into splited select new KeyValuePair<string, string>(splited[0], splited[1])).ToList();
        }
    }
}
