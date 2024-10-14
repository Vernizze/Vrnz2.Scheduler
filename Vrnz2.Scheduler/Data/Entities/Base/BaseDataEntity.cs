using System.ComponentModel.DataAnnotations.Schema;

namespace Vrnz2.Scheduler.Data.Entities.Base
{
    public abstract class BaseDataEntity
    {
        #region Constructors

        protected BaseDataEntity() 
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTimeOffset.UtcNow;
        }

        #endregion

        #region Attributes

        [Column("id")]
        public virtual Guid Id { get; set; }

        [Column("created_at")]
        public virtual DateTimeOffset CreatedAt { get; set; }

        [Column("updated_at")]
        public virtual DateTimeOffset? UpdatedAt { get; set; }

        [Column("active")]
        public virtual bool Active { get; set; } = true;

        #endregion
    }
}
