using System.ComponentModel.DataAnnotations.Schema;
using Vrnz2.Scheduler.Data.Entities.Base;

namespace Vrnz2.Scheduler.Data.Entities
{
    public class ScheduledEventWeeklyDetails
        : BaseDataEntity
    {
        #region Atributtes

        [Column("scheduled_event_id")]
        public Guid ScheduledEventId { get; set; }

        [Column("occurr_on_sunday")]
        public bool OccurrOnSunday { get; set; }

        [Column("occurr_on_monday")]
        public bool OccurrOnMonday { get; set; }

        [Column("occurr_on_tuesday")]
        public bool OccurrOnTuesday { get; set; }

        [Column("occurr_on_wednesday")]
        public bool OccurrOnWednesday { get; set; }

        [Column("occurr_on_thursday")]
        public bool OccurrOnThursday { get; set; }

        [Column("occurr_on_friday")]
        public bool OccurrOnFriday { get; set; }

        [Column("occurr_on_saturday")]
        public bool OccurrOnSaturday { get; set; }

        #endregion
    }
}
