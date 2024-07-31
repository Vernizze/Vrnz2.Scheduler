using System.ComponentModel.DataAnnotations.Schema;
using Vrnz2.Scheduler.Data.Entities.Base;

namespace Vrnz2.Scheduler.Data.Entities
{
    public class ScheduledEventYearlyDetails
        : BaseDataEntity
    {
        #region Atributtes

        [Column("scheduled_event_id")]
        public Guid ScheduledEventId { get; set; }

        [Column("execution_date")]
        public DateTime ExecutionDate { get; set; }

        #endregion
    }
}
