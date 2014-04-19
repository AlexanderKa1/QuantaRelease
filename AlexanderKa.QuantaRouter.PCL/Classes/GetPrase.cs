using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if Mono
using System.Threading.Tasks;
#endif

namespace AlexanderKa.QuantaRouter.PCL.Classes
{
    public static class StringHelper
    {
        public static string GetPrase(this string htmlContent, string startprase, string endphrease)
        {
            if (String.IsNullOrEmpty(htmlContent.Trim())) return string.Empty;
            try
            {
                var startindex = htmlContent.IndexOf(startprase, System.StringComparison.Ordinal) + startprase.Length;
                var lastindex = htmlContent.IndexOf(endphrease, startindex, System.StringComparison.Ordinal);
                return htmlContent.Substring(startindex, lastindex - startindex);
            }
            catch (Exception)
            {

                return string.Empty;
            }
           
        } 
    }
      
}
