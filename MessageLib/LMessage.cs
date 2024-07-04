using System.Text.Json;

namespace MessageLib
{
    public class LMessage : ICloneable
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
