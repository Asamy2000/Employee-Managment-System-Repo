using System;
using System.ComponentModel;

namespace MVCPL.Models
{
    public class RoleVM
    {
        public string Id { get; set; }
        [DisplayName("Role Name")]
        public string RoleName { get; set; }
        public RoleVM()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
