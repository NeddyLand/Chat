using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBServer
{
    internal class Message
    {
        public int MessageId { get; set; }
        public string Text {  get; set; }
        public DateTime DateSend { get; set; }
        public bool IsSent { get; set; }
        public int IDUserTo { get; set; }
        public int IDUserFrom { get; set; }
    }
}
