namespace ORA_Data.Model
{
    public class AccountBioDM
    {
        public int AccountBioID { get; set; }

        public string ProfileImage { get; set; }

        public string AccountStatus { get; set; }

        public string BannerBackgroundImg { get; set; }

        public string AboutMe { get; set; }

        public EmployeeDM employee { get; set; }
    }
}
