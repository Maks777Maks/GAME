using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Util
{
    public static class Logger
    {
        private static string Path = @"C:\Users\User\Source\Repos\GAME\Game\WCF\bin\Debug\Log.txt";
        public static void Log(string msg)
        {
            using (StreamWriter fs = new StreamWriter(Path, true))
            {
                fs.WriteLine($"{DateTime.Now} : {msg}");
            }
        }
    }
}
