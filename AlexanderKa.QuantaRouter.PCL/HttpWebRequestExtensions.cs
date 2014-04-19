using System;
using System.IO;
using System.Net;
#if MONO
using System.Threading.Tasks;
#endif
using System.Threading.Tasks;
namespace AlexanderKa.QuantaRouter.PCL
{
    public static class HttpWebRequestExtensions
    {
	 

        public static Task<Stream> GetRequestStreamAsync(this HttpWebRequest request)
        {
            var tcs = new TaskCompletionSource<Stream>();


            try
            {
                request.BeginGetRequestStream(iar =>
                    {
                        try
                        {
                            Stream response = request.EndGetRequestStream(iar);

                            tcs.SetResult(response);
                        }

                        catch (Exception exc)
                        {
                            tcs.SetException(exc);
                        }
                    }, null);
            }

            catch (Exception exc)
            {
                tcs.SetException(exc);
            }


            return tcs.Task;
        }


        public static Task<HttpWebResponse> GetResponseAsync(this HttpWebRequest request)
        {
            var tcs = new TaskCompletionSource<HttpWebResponse>();


            try
            {
               
                        request.BeginGetResponse(iar =>
                            {
                                try
                                {
                                  
                                    var response = (HttpWebResponse) request.EndGetResponse(iar);

                                    tcs.SetResult(response);
                                }

                                catch (Exception exc)
                                {
                                    tcs.SetException(exc);
                                }
                            }, null);
                  

            }

            catch (Exception exc)
            {
                tcs.SetException(exc);
            }


            return tcs.Task;
        }
    }
}