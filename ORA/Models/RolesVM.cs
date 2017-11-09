using System.ComponentModel;

namespace ORA.Models
{
    public class RolesVM
    {
        public int RoleId { get; set; }

        [DisplayName("Role Name")]
        public string RoleName { get; set; }

        [DisplayName("Role Description")]
        public string RoleDescription { get; set; }
    }
}