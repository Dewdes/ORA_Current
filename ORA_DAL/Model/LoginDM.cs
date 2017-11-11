
namespace ORA_Data.Model
{
    public class LoginDM
    {
        public long LoginId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public long EmployeeId { get; set; }

        public EmployeeDM Employee { get; set; }

        public RolesDM Role { get; set; }
    }
}