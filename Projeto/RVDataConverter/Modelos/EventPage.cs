using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVDataConverter.Modelos
{
    public class EventPage
    {
        public List<EventCommand> Commands { get; set; }

        public EventPage()
        {
            Commands = new List<EventCommand>();
        }
    }
}
