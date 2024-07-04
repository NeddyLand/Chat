using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Chat
{
    public class LMessage :ICloneable
    {
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public string NicknameFrom { get; set; }
        public string NicknameTo { get; set; }

        public string SerializeMessageToJson() => JsonSerializer.Serialize(this);
        public static LMessage? DeserializeFromJson(string message) => JsonSerializer.Deserialize<LMessage>(message);
        public void Print()
        {
            Console.WriteLine($"{this.DateTime} Получено сообщение: {this.Text} от {this.NicknameFrom}");
        }
        public object Clone()
        {
            return new LMessage();
        }
    }
}
