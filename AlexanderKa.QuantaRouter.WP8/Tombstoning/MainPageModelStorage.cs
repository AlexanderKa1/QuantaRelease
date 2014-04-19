using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using CaliburnMicro.ViewModels;

namespace CaliburnMicro.Tombstoning
{
    public class MainPageModelStorage: StorageHandler<MainPageViewModel>
    {
        public override void Configure()
        {
            //Property(x => x.Surname)
            //    .InPhoneState();
        }
    }
}
