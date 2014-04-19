using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelfHostedWcfClient
{
    using System.Threading;

    using PortableTPL;

    using SelfHostedWcfClient.ServiceReference1;

    public static class ServiceClient
    {

        private static List<Service1Client> Clients = new List<Service1Client>();


        public static async void InvokeMethodOnServer<TResult>(
            Action<object> onSuccess,
            Action<Exception> onError,
          int i)
        {

            ThreadInvoke newThreadInvoke = new ThreadInvoke();
            newThreadInvoke.CompleteAction = onSuccess;
            newThreadInvoke.ErrorAction = onError;
            Task.Factory.StartNew(() => newThreadInvoke.StartThread(i));





        }

        static void newClient_GetDataCompleted(object sender, GetDataCompletedEventArgs e)
        {

        }


    }



    public class ThreadInvoke
    {
        public string wcfMethod { get; set; }
        public Action<object> CompleteAction { get; set; }
        public Action<Exception> ErrorAction { get; set; }

        private Service1Client s;
        public void StartThread(params object[] args)
        {
            s = new Service1Client();
            s.GetDataCompleted += s_GetDataCompleted;
            s.GetDataAsync((int)args[0]);
        }

        void s_GetDataCompleted(object sender, GetDataCompletedEventArgs e)
        {
            s.GetDataCompleted -= s_GetDataCompleted;
            this.CompleteAction(e.Result);

        }
    }
}
