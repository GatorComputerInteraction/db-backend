using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("period")]
    public class PeriodModel
    {
        [Key]
        [Column("periodid", Order = 1)]
        public int PeriodId { get; set; }

        [Required]
        [Column("starttime")]
        public TimeSpan StartTime { get; set; }

        [Required]
        [Column("endtime")]
        public TimeSpan EndTime { get; set; }
    }
}
