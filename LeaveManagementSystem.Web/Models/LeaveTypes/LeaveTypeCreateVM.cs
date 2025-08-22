﻿using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
    public class LeaveTypeCreateVM
    {
        [Required]
        [Length(4,150,ErrorMessage ="You have violated the length requirements")]
        public string Name { get; set; } = String.Empty;

        [Required]
        [Range(1,90)]
        [Display(Name="Maximum Allocation of Days")]
        public int Days { get; set; }
    }

}
