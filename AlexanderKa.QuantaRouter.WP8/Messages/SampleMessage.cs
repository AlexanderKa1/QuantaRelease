using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnMicro.Messages
{
    public class SampleMessage
    {
        public string Name { get; set; }
        
        public SampleMessage(string name)
        {
            Name = name;
        }
    }
}
