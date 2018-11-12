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
        private static string Path = @"C:\Log\Logger.txt";
        public static void Log(string msg)
        {
            using (StreamWriter fs = new StreamWriter(Path, true))
            {
                fs.WriteLine($"{DateTime.Now} : {msg}");
            }
        }
    }
}
