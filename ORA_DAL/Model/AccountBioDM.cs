using System.Web;

namespace ORA_Data.Model
{
    public class AccountBioDM
    {
        public long AccountBioID { get; set; }

        public byte[] ProfileImage { get; set; }

        public string AccountStatus { get; set; }

        public byte[] BannerBackgroundImg { get; set; }

        public string AboutMe { get; set; }

        public string SideMenuImage { get; set; }

        public string SideMenuColor { get; set; }

        public long EmployeeID { get; set; }

        public HttpPostedFileBase File { get; set; }

        public EmployeeDM employee { get; set; }
    }
}
