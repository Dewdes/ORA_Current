namespace ORA.Models
{
    public class AccountBioVM
    {
        public int AccountBioID { get; set; }

        public string ProfileImage { get; set; }

        public string AccountStatus { get; set; }

        public string BannerBackgroundImg { get; set; }

        public string AboutMe { get; set; }

        public EmployeeVM employee { get; set; }

    }
}