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
        public static string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        public LogError() 
        {

        }

        public static void WriteLog(string error)
        {
            System.IO.File.AppendAllText(path + "\\Logs.txt", $"{DateTime.Now}:  {error}\n");
        }
    }
}
