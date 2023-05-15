using System.ComponentModel.DataAnnotations;

namespace student_status_server.Models
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(30)] public string FirstName { get; set; } = string.Empty;
        [StringLength(30)] public string LastName { get; set; } = string.Empty;
        [StringLength(255)] public string? Email { get; set; }
        [StringLength(100)] public string Password { get; set; } = string.Empty;
        [StringLength(50)] public string UserName { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;
        [StringLength(10)] public string Status { get; set; } = "WHITE";
        public bool IsLoggedin { get; set; } = false;
    }
}
