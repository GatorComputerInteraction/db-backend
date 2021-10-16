using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class TimeslotModel
    {
        [Key]
        [Column(Order = 1)]
        public int SlotId { get; set; }

        [Required]
        [MaxLength(10)]
        public string Day { get; set; }

        [Required]
        public int PeriodId1 { get; set; }

        public int PeriodId2 { get; set; }

        public int PeriodId3 { get; set; }

        [ForeignKey("PeriodId1")]
        public PeriodModel PeriodMode1l { get; set; }

        [ForeignKey("PeriodId2")]
        public PeriodModel PeriodModel2 { get; set; }

        [ForeignKey("PeriodId3")]
        public PeriodModel PeriodModel3 { get; set; }
    }
}
