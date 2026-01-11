using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.CodeBaseManagement
{
    internal class IdGenerator
    {
        private int _counter = 0;

        public IdGenerator() { }

        public string GetNext()
        {
            int result = _counter;
            _counter++;
            return result.ToString();
        }
    }
}
