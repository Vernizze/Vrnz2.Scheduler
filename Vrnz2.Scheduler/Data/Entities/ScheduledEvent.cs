﻿using System.ComponentModel.DataAnnotations.Schema;
using Vrnz2.Scheduler.Data.Entities.Base;
using Vrnz2.Scheduler.Enums.Types;

namespace Vrnz2.Scheduler.Data.Entities
{
    public class ScheduledEvent
        : BaseDataEntity
    {
        #region Atributtes

        [Column("occurrence_type")]
        public TOccurrence OccurrenceType { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("execution_date")]
        public DateOnly? ExecutionDate { get; set; }

        [Column("execution_time")]
        public TimeOnly? ExecutionTime { get; set; }

        #endregion
    }
}
