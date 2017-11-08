using System.Web;

namespace ORA.Tools
{
    public class SessionTool
    {
        //add default settings to app config later
        public static void StartSession()
        {
            HttpContext.Current.Session["LoggedIn"] = false;
            HttpContext.Current.Session["Role"] = "guest";
        }
    }
}