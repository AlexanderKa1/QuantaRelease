using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AlexanderKa.QuantaRouter.PCL;
using AlexanderKa.QuantaRouter.PCL.Interfaces;

namespace AlexanderKa.QuantaRouter.WindowsStore.Classes
{
    using System.IO;
    using System.Net;

    using Windows.Networking;
    using Windows.Networking.Sockets;

    public class HttpClientExtension : HttpClient, IHttpClient
    {
        private string IPAddr { get; set; }
       

        public async Task<string> GetStringAsync(string url)
        {
            try
            {
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
            }
            catch (Exception)
            {


            }
            try
            {
                return base.GetStringAsync(url).Result;
            }
            catch (Exception)
            {

                return string.Empty;
            }
              
            
           
        }

        public async Task<string> GetStringAsyncPost(string url, string postdata)
        {

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

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "text";
            request.Method = "POST";

            using (var requestStream = await request.GetRequestStreamAsync())
            {
                var writer = new StreamWriter(requestStream);
                writer.Write(postdata);
                writer.Flush();
                using (var response = await request.GetResponseAsync())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        var reader = new StreamReader(responseStream);
                        var answer = reader.ReadToEnd();
                        request.Abort();
                        response.Dispose();

                        return answer;
                    }
                }
            }


        }




        public static bool GetHostName(string ipOrhost, out HostName hostName)
        {
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
            }
            finally
            {
                hostName = internalHostName;
            }
            return isValidHost;
        }
        private static int resolveCounter = 0;
        public static async Task<string> ResolveDNS(string remoteHostName)
        {
            resolveCounter++;
            if (resolveCounter > 3)
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(remoteHostName))
                return string.Empty;
            Uri temp = new Uri(remoteHostName, UriKind.RelativeOrAbsolute);
            remoteHostName = temp.Host;
            string ipAddress = string.Empty;

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
                ipAddress = string.Empty;
            }

            return ipAddress;
        }

       
    }
}
