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

    //Геолокация
    public interface IGeoLocator
    {

        Task<GeoPosition> GetGeoPositionAsync();
    }

    public class GeoPosition : BaseViewModel
    {
        /// <summary>
        /// Точность
        /// </summary>
        public double Accuracy { get; set; }
        
        /// <summary>
        /// Широта
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// Долгота
        /// </summary>
        public double Longitude { get; set; }
        /// <summary>
        /// Штамп времени
        /// </summary>
        public DateTimeOffset TimeStamp { get; set; }
    }
}
