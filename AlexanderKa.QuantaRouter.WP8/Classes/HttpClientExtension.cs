using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnMicro.Classes
{
    using System.Diagnostics;
    using System.IO;
    using System.Net;

    using Windows.Networking;
    using Windows.Networking.Sockets;
#if !WINDOWS_PHONE71
using System.Net.Http;
   
#endif
    using System.Net.Http;

    using AlexanderKa.QuantaRouter.PCL;
    using AlexanderKa.QuantaRouter.PCL.Interfaces;

    using Microsoft.Phone.Net.NetworkInformation;



    public class HttpClientExtension : HttpClient, IHttpClient
    {
        private string IPAddr { get; set; }


        public new async Task<string> GetStringAsync(string url)
        {


#if !WINDOWS_PHONE71
 if (!String.IsNullOrEmpty(IPAddr))
            {



                Uri path = new Uri(url, UriKind.RelativeOrAbsolute);

                Uri temp = new Uri("http://" + IPAddr + path.PathAndQuery);
                url = temp.ToString();
            }
            else
            {
                IPAddr = await ResolveDNS(url);
            }
#else
            IPAddr = string.Empty;
#endif





            try
            {

                if (base.GetStringAsync(url) != null)
                {
                    var result = base.GetStringAsync(url).Result;
                    base.CancelPendingRequests();
                    return result;
                }
                return string.Empty;


            }
            catch (Exception ex)
            {
                return string.Empty;
                Debug.WriteLine(ex);
            }


        }

        public async Task<string> GetStringAsyncPost(string url, string postdata)
        {



#if !WINDOWS_PHONE71
 if (!String.IsNullOrEmpty(IPAddr))
            {



                Uri path = new Uri(url, UriKind.RelativeOrAbsolute);

                Uri temp = new Uri("http://" + IPAddr + path.PathAndQuery);
                url = temp.ToString();
            }
            else
            {
                IPAddr = await ResolveDNS(url);
            }
#else
            IPAddr = string.Empty;
#endif


            var values = new List<KeyValuePair<string, string>>();
            try
            {



                foreach (var keyValuePair in postdata.Split('&'))
                {
                    if (!String.IsNullOrEmpty(keyValuePair))
                    {
                        var key = keyValuePair.Split('=')[0];
                        var value = keyValuePair.Split('=')[1];
                        values.Add(new KeyValuePair<string, string>(key, value));
                    }

                }

            }
            catch (Exception)
            {
            }



            var httpClient = new HttpClient(new HttpClientHandler());
            HttpResponseMessage response =  httpClient.PostAsync(url, new FormUrlEncodedContent(values)).Result;
            response.EnsureSuccessStatusCode();
            var responseString =  response.Content.ReadAsStringAsync().Result;
            response.Dispose();
            return responseString;
        }




        public static bool GetHostName(string ipOrhost, out string hostName)
        {


 #if !WINDOWS_PHONE71
            HostName internalHostName = null;
            bool isValidHost = false;

            try
            {
                internalHostName = new HostName(ipOrhost);
                isValidHost = true;
            }
            catch (Exception ex)
            {
                isValidHost = false;
                internalHostName = null;
                // Exception Invalid Host name
                Debug.WriteLine(ex);
            }
            finally
            {
                hostName = internalHostName.ToString();
            }
            return isValidHost;
#endif
            hostName = ipOrhost;
            return true;
        }
        public static async Task<string> ResolveDNS(string remoteHostName)
        {
            if (string.IsNullOrEmpty(remoteHostName))
                return string.Empty;
            Uri temp = new Uri(remoteHostName, UriKind.RelativeOrAbsolute);
            remoteHostName = temp.Host;
            string ipAddress = string.Empty;

#if DEBUG
            return "127.0.0.1";
#else
            try
            {

                IReadOnlyList<EndpointPair> data =
                  await DatagramSocket.GetEndpointPairsAsync(new HostName(remoteHostName), "0");

                if (data != null && data.Count > 0)
                {
                    foreach (EndpointPair item in data)
                    {
                        if (item != null && item.RemoteHostName != null &&
                                      item.RemoteHostName.Type == HostNameType.Ipv4)
                        {
                            return item.RemoteHostName.CanonicalName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                ipAddress = string.Empty;

            }

            return ipAddress;
#endif
        }


    }
}
