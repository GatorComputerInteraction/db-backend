using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("timeslot")]
    public class TimeslotModel
    {
        [Key]
        [Column("slotid", Order = 1)]
        public int SlotId { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("day")]
        public string Day { get; set; }

        [Required]
        [Column("periodid1")]
        public int PeriodId1 { get; set; }

        [Column("periodid2")]
        public int? PeriodId2 { get; set; }

        [Column("periodid3")]
        public int? PeriodId3 { get; set; }

        [ForeignKey("PeriodId1")]
        public PeriodModel PeriodMode1l { get; set; }

        [ForeignKey("PeriodId2")]
        public PeriodModel PeriodModel2 { get; set; }

        [ForeignKey("PeriodId3")]
        public PeriodModel PeriodModel3 { get; set; }
    }
}
