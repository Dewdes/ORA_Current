using System;
using System.IO;

namespace ORA_Data
{
    public class ErrorLog
    {
        public void ErrorLogger(string level, DateTime timeStamp, string errorMsg)
        {
            using (StreamWriter writer = new StreamWriter("C:\\Users\\Onshore\\Desktop\\ORA_Version_0.1\\ORA\\Tools\\ErrorLogDAL.txt", true))
            {
                writer.WriteLine("Level: " + level + "   Time: " + timeStamp + "   Error: " + errorMsg);
            }
        }
    }
}
