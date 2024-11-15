using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVDataConverter.Modelos
{
    public class RPGData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Parameter> Parameters { get; set; }
        public List<EventCommand> EventCommands { get; set; }
        public List<CommonEvent> CommonEvents { get; set; }

        public RPGData()
        {
            Parameters = new List<Parameter>();
            EventCommands = new List<EventCommand>();
            CommonEvents = new List<CommonEvent>();
        }
    }

    public class Parameter
    {
        public string Type { get; set; }
        public int Value { get; set; }
    }

    public class EventCommand
    {
        public int Code { get; set; }
        public int Indent { get; set; }
        public string Parameters { get; set; }

        public EventCommand(int code, int indent, string parameters)
        {
            Code = code;
            Indent = indent;
            Parameters = parameters;
        }
    }

    public class CommonEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Trigger { get; set; }
        public List<EventCommand> CommandList { get; set; }

        public CommonEvent()
        {
            CommandList = new List<EventCommand>();
        }
    }
}
