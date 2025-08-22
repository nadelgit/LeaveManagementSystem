using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
    public class LeaveTypeEditVM
    {
        public int Id { get; set; }

        [Required]
        [Length(4, 150, ErrorMessage = "You have violated the length requirements")]
        public string Name { get; set; } = String.Empty;

        [Required]
        [Range(1, 90)]
        public int Days { get; set; }
    }
}
