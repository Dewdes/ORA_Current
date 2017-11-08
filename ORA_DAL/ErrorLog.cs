using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace ORA_Data
{
    public class ErrorLog
    {
        public void ErrorLogger(string level, DateTime timeStamp, string errorMsg)
        {
            string path = HttpContext.Current.Server.MapPath(@"~\ErrorLogDAL.txt");
            using (FileStream outputFileStream = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(outputFileStream))
                {
                    writer.WriteLine("Level: " + level + "   Time: " + timeStamp + "   Error: " + errorMsg);
                }
            }
        }
    }
}
