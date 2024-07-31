using System.ComponentModel.DataAnnotations.Schema;

namespace Vrnz2.Scheduler.Data.Entities.Base
{
    public abstract class BaseDataEntity
    {
        [Column("id")]
        public virtual Guid Id { get; set; } = Guid.NewGuid();

        [Column("created_at")]
        public virtual DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        [Column("updated_at")]
        public virtual DateTimeOffset? UpdatedAt { get; set; }

        [Column("active")]
        public virtual bool Active { get; set; } = true;
    }
}
