﻿using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
    public class LeaveTypeReadOnlyVM : BaseLeaveTypeVM
    {
       
        public string Name { get; set; } = String.Empty;

        [Display(Name = "Maximum Allocation of Days")]
        public int Days { get; set; }
    }
}
