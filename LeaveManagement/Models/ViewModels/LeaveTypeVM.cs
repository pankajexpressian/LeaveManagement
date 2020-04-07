using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace LeaveManagement.Models.ViewModels
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; } 

    }

    //public class CreateLeaveTypeVM
    //{
    //    [Required]
    //    public string Name { get; set; }
    //}
}
