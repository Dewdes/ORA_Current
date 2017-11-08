using System;
using System.IO;
using System.Web;

namespace ORA_Data
{
    public class ErrorLog
    {
        public void ErrorLogger(string level, DateTime timeStamp, string errorMsg)
        {
            string path = HttpContext.Current.Server.MapPath(@"~\Tools\ErrorLogDAL.txt");
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
