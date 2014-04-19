using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    using System.Net;

    class Program
    {
        static void Main(string[] args)
        {
          var t =  HttpWebRequest.CreateHttp(
                @"http://zeus2.china-cdn88nmbwacdnln8hq8qwe.com/view/FkZhasyN20BL7JuZuzW2mg/1384140769/95028.mp4").GetResponse();
        }
    }
}
