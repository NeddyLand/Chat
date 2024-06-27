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
    }
}
