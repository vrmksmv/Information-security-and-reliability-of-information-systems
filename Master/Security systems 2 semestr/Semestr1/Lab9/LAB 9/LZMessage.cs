using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_9
{
    public enum Mode
    {
        Bin = 2,
        Quad = 4,
        Hex = 16
    }
    public class LZMessage
    {
        public Mode MessageMode { get; private set; }
        public int Size { get; private set; }
        public string Message { get; private set; }
        public LZMessage(Mode mode, int size, string message)
        {
            MessageMode = mode;
            Size = size;
            Message = message;
        }
        public override string ToString()
        {
            return $"{Message} ";
        }
    }
}
