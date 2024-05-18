using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextView
{
    public class ConsoleTextLogger : ITextLogger
    {
        public void LogText(string text)
        {
            Console.Write(text);
        }
    }
}
