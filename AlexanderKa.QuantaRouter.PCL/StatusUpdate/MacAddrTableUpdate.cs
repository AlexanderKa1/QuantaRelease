using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
#if Mono
using System.Threading.Tasks;
#endif
using AlexanderKa.QuantaRouter.PCL.Classes;
using AlexanderKa.QuantaRouter.PCL.Interfaces;

namespace AlexanderKa.QuantaRouter.PCL.StatusUpdate
{
    using System.Threading.Tasks;

    public class MacAddrTableUpdate : IStatusUpdate
    {
        public async Task<bool> ParseStatus(string html)
        {
            try
            {
                //TODO: парсинг DNS клиента
                int numclients = 0;
                int.TryParse(html.GetPrase("dhs_client_num:'", "',"), out numclients);
                if (numclients == 0) return true;

                var resultCollection = new ObservableCollection<MacAddrTableItem>();
                for (int i = 0; i < numclients; i++)
                {
                    var content = html.GetPrase("dhs_client" + i.ToString() + ":'", "',");
                    var itemData = content.Split(';');
                    resultCollection.Add(new MacAddrTableItem() { MAC = itemData[0], IP = itemData[1], Host = itemData[2], Time = itemData[3] });
                }


                UIContext.Post(delegate(object state)
                    {
                        var newTable = (ObservableCollection<MacAddrTableItem>)state;

                        LoadStatusFromHtml(newTable);



                    }, resultCollection);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }



        public SynchronizationContext UIContext { get; set; }
        public Router router { get; set; }
        public string url { get { return "http://status.yota.ru/status/client_table.htm"; } }

        /// <summary>
        /// Обновляем статус
        /// </summary>

        internal void LoadStatusFromHtml(ObservableCollection<MacAddrTableItem> resultCollection)
        {

            //Теперь сравним
            //только сначала удалим то чего нет
            if (resultCollection.Any())
            {
                router.Status.DevicesNotConnected = false;
            }
            else
            {
                router.Status.DevicesNotConnected = true;
            }
             var toDelete = router.Status.MacAddrTable.Where(x => !resultCollection.Select(y => y.MAC).Contains(x.MAC));
            foreach (var itemtodelete in toDelete.ToList())
            {
                router.Status.MacAddrTable.Remove(itemtodelete);
            }
            
            foreach (var macAddrTableItem in resultCollection)
            {

                if (router.Status.MacAddrTable.All(i => i.MAC != macAddrTableItem.MAC))
                {
                    router.Status.MacAddrTable.Add(macAddrTableItem);
                    return;
                }
                var itemToUpdate = router.Status.MacAddrTable.FirstOrDefault(i => i.MAC == macAddrTableItem.MAC);

                if (itemToUpdate.IP != macAddrTableItem.IP)
                {
                    itemToUpdate.IP = macAddrTableItem.IP;
                }
                if (itemToUpdate.Host != macAddrTableItem.Host)
                {
                    itemToUpdate.Host = macAddrTableItem.Host;
                }
                if (itemToUpdate.Time != macAddrTableItem.Time)
                {
                    itemToUpdate.Time = macAddrTableItem.Time;
                }
              
            }
        
          

        }


    }
}
