using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using CaliburnMicro.Messages;

namespace CaliburnMicro.ViewModels
{
    public class Page2ViewModel: PropertyChangedBase
    {
        private readonly IEventAggregator eventAggregator;

        public Page2ViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }

        public void SendMessage()
        {
            eventAggregator.Publish(new SampleMessage("Matteo"));
        }
    }
}
