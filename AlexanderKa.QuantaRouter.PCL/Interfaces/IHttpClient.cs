using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if Mono
using System.Threading.Tasks;
#endif

namespace AlexanderKa.QuantaRouter.PCL.Interfaces
{
    using System.Threading.Tasks;

    /// <summary>
    /// Интрефейс реализующий загрузку html т.к. работа стандартного PLC ацтой.
    /// </summary>
    public interface IHttpClient
    {
        /// <summary>
        /// Загрузка html документа 
        /// </summary>
        /// <param name="url">url документа</param>
        /// <returns>HTML документа</returns>
        Task<string> GetStringAsync(string url);

        Task<string> GetStringAsyncPost(string url, string postdata);
    }
}
