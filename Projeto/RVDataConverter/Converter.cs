using System;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using RVDataConverter.Modelos;

namespace RVDataConverter
{
    public class Converter
    {
        public void ConvertToJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Arquivo não encontrado: {filePath}");
                return;
            }

            var data = ReadRvdata2(filePath);

            string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            string jsonFilePath = Path.ChangeExtension(filePath, ".json");
            File.WriteAllText(jsonFilePath, json);
            Console.WriteLine($"Arquivo convertido e salvo em: {jsonFilePath}");
        }

        private RPGData ReadRvdata2(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(stream))
            {
                // Ler o cabeçalho do arquivo
                string header = new string(reader.ReadChars(8));
                if (header != "RVData2")
                {
                    throw new InvalidDataException("Arquivo não é um .rvdata2 válido.");
                }

                RPGData rpgData = new RPGData();

                // Ler ID
                rpgData.Id = reader.ReadInt32();
                rpgData.Name = ReadString(reader);

                // Ler parâmetros
                int parametersCount = reader.ReadInt32();
                for (int i = 0; i < parametersCount; i++)
                {
                    Parameter param = new Parameter
                    {
                        Type = ReadString(reader),
                        Value = reader.ReadInt32()
                    };
                    rpgData.Parameters.Add(param);
                }

                // Ler comandos de eventos
                int commandsCount = reader.ReadInt32();
                for (int i = 0; i < commandsCount; i++)
                {
                    EventCommand command = ReadEventCommand(reader);
                    rpgData.EventCommands.Add(command);
                }

                // Ler eventos comuns
                int commonEventsCount = reader.ReadInt32();
                for (int i = 0; i < commonEventsCount; i++)
                {
                    CommonEvent commonEvent = ReadCommonEvent(reader);
                    rpgData.CommonEvents.Add(commonEvent);
                }

                return rpgData;
            }
        }

        private EventCommand ReadEventCommand(BinaryReader reader)
        {
            int code = reader.ReadInt32();
            int indent = reader.ReadInt32();
            string parameters = ReadString(reader);
            return new EventCommand(code, indent, parameters);
        }

        private CommonEvent ReadCommonEvent(BinaryReader reader)
        {
            CommonEvent commonEvent = new CommonEvent();
            commonEvent.Id = reader.ReadInt32();
            commonEvent.Name = ReadString(reader);
            commonEvent.Trigger = reader.ReadInt32();
            commonEvent.CommandList = ReadCommandList(reader);
            return commonEvent;
        }

        private List<EventCommand> ReadCommandList(BinaryReader reader)
        {
            List<EventCommand> commands = new List<EventCommand>();
            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                commands.Add(ReadEventCommand(reader));
            }
            return commands;
        }

        private string ReadString(BinaryReader reader)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            byte b;
            while ((b = reader.ReadByte()) != 0)
            {
                sb.Append((char)b);
            }
            return sb.ToString();
        }
    }
}