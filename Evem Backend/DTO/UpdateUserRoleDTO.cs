using System.ComponentModel.DataAnnotations;

namespace Evem_Backend.DTO
{
    public class UpdateUserRoleDTO
    {
        [Required]
        public string EmployeeRole { get; set; }

    }
}
