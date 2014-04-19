using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadClientTest
{
    using System.Diagnostics;

    using SelfHostedWcfClient;

    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                ServiceClient.InvokeMethodOnServer<int>(
               o =>
               {
                   Debug.WriteLine(o.ToString());
               },
               exception =>
               {
                   Debug.WriteLine(exception);
               }, i);
            }

        }
    }
}
