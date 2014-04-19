using System;
using System.Collections.Generic;
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

    class SingnalBatteryRoamUpdate: IStatusUpdate , IHavePostData
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
        public string url { get { return "http://status.yota.ru/xmlpost.cgi"; } }
        public RequestType RequestType { get { return RequestType.Post; } }

        /// <summary>
        /// Обновляем статус
        /// </summary>

        internal void LoadStatusFromHtml(string htmlContent)
        {

           router.Status.SignalLevel = htmlContent.GetPrase("signal=", ",");
          // router.Status.BattLevel = htmlContent.GetPrase(",battery=", ",roam");
           // router.Status.RoamingStatus = htmlContent.GetPrase("roam=", "");
          
        }

        public string PostData { get { return "&xmlPId=9"; } }
    }

    public interface IHavePostData
    {
        string PostData { get; }
    }
}
