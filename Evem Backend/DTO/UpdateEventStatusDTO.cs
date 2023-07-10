using System.ComponentModel.DataAnnotations;

namespace Evem_Backend.DTO
{
    public class UpdateEventStatusDTO
    {
        [Required]
        public Boolean status { get; set; }

    }
}
