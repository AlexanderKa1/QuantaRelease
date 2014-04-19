using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    using System.Diagnostics;

    using SelfHostedWcfClient;

    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10000000; i++)
            {
               ServiceClient.InvokeMethodOnServer<string>(s => {Debug.WriteLine(s);},exception => {Debug.WriteLine(exception);},i);
            }
          
        }
    }
}
