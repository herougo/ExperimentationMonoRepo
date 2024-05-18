using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextView
{
    public class ListTextLogger : ITextLogger
    {
        List<string> _log = new List<string>();

        public void LogText(string text)
        {
            _log.Add(text);
        }

        public string GetLog()
        {
            return string.Join("", _log);
        }
    }
}
