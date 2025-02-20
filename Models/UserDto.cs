using System.ComponentModel.DataAnnotations;

namespace ValidationExample.Models
{
    public class UserDto
    {
        public string? Phone { get; set; }
        public string? Position { get; set; }
        public string? FileName { get; set; }
    }
}
