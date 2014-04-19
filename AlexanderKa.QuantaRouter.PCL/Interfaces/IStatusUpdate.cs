using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
#if Mono
using System.Threading.Tasks;
#endif

namespace AlexanderKa.QuantaRouter.PCL.Interfaces
{
    using System.Threading.Tasks;

    /// <summary>
    /// Интерфейс обновления какого то из статусов
    /// </summary>
    public interface IStatusUpdate
    {
        /// <summary>
        /// метод который парсит параметры и вносит обновенные данные в router класс
        /// </summary>
        /// <param name="html">что парсить</param>
        /// <returns>результат</returns>
        Task<bool> ParseStatus(string html);
        /// <summary>
        /// Контекст синхронизации UI т.к. INotyfyPropertyChanged для параметров роутера
        /// </summary>
        SynchronizationContext UIContext { get; set; }
        /// <summary>
        /// Класс роутера
        /// </summary>
        Router router { get; set; }
        /// <summary>
        /// URL откуда брать html для парсинга
        /// </summary>
        string url { get; }
    }
}
