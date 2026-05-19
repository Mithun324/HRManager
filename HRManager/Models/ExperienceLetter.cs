using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class ExperienceLetter
    {
        [Key]
        public int LetterId { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
        public string? LetterNo { get; set; }
        public DateTime? IssueDate { get; set; }
        public string? FileUrl { get; set; }
        public string? Status { get; set; }
        public string? Remarks { get; set; }
    }
}