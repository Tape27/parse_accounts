using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class LogError
    {
        string path = string.Empty;
        public LogError(string path) 
        {
            this.path = path;
        }

        public void WriteLog(string error)
        {
            System.IO.File.AppendAllText(path, $"{DateTime.Now}:  {error}\n");
        }
    }
}
