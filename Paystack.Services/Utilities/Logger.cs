using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Business.Utilities
{
    public class Logger
    {
        public static void ProcessError(Exception ex, string contentRootPath)
        {
            var errorFile = Path.Combine(contentRootPath, "logs", "applog-" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
            using (StreamWriter sw = (File.Exists(errorFile)) ? File.AppendText(errorFile) : File.CreateText(errorFile))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd h:mm:tt ") + ex.ToString());
            }
        }
    }
}
