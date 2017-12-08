using System.Collections.Generic;
using System.Web;

namespace ORA.Models
{
    public class AccountBioVM
    {
        public int AccountBioID { get; set; }

        public byte[] ProfileImage { get; set; }

        public string AccountStatus { get; set; }

        public byte[] BannerBackgroundImg { get; set; }

        public string AboutMe { get; set; }

        public string SideMenuImage { get; set; }

        public string SideMenuColor { get; set; }

        public HttpPostedFileBase File { get; set; }

        public EmployeeVM employee { get; set; }

        public List<string> ColorOptions { get; set; }

        public List<string> ImageOptions { get; set; }
    }
}