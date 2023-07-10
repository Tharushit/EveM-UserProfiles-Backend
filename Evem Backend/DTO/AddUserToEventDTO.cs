namespace Evem_Backend.DTO
{
    public class AddUserToEventDTO
    {
        public int? EventId { get; set; }

        public int? EmployeeId { get; set; }

        public string? EmployeeRole { get; set; }
    }
}
