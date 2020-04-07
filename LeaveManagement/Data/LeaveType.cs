using System;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Data
{
    public class LeaveType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }

   
}
