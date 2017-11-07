using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ORA_Data
{
    public class ErrorLog
    {
        public void ErrorLogger(string level, DateTime timeStamp, string errorMsg)
        {
            using (StreamWriter writer = new StreamWriter("DAL_ERROR_LOG.txt", true))
            {
                writer.WriteLine("Level: " + level + "   Time: " + timeStamp + "   Error: " + errorMsg);
            }
        }
    }
}
