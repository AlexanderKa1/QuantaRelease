using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
#if Mono
using System.Threading.Tasks;
#endif
using AlexanderKa.QuantaRouter.PCL.Classes;
using AlexanderKa.QuantaRouter.PCL.Interfaces;

namespace AlexanderKa.QuantaRouter.PCL.StatusUpdate
{
    using System.Threading.Tasks;

    public class WlanStatusUpdate : IStatusUpdate 
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
        public string url { get { return "http://status.yota.ru/status/connection_info.htm"; } }

        /// <summary>
        /// Обновляем статус
        /// </summary>
       
        internal void LoadStatusFromHtml(string htmlContent)
        {
            //TODO: парсинг DNS клиента
            router.Status.Wifi_Mac = htmlContent.GetPrase("wifi_mac:'", "',");
            router.Status.Wifi_SSID = htmlContent.GetPrase("wl_ssid:'", "',");
            router.Status.Wifi_Channel = htmlContent.GetPrase("wl_chnid:", ",");
            router.Status.MTU = htmlContent.GetPrase("mtu:'", "',");
            
            
        }
      
     
       
    }
}
