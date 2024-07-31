using Vrnz2.Scheduler.Data.Contexts.Base;

namespace Vrnz2.Scheduler.Data.Contexts
{
    public class DbContextDefault
        : BaseDbContext
    {
        #region Constants

        public const string ContextDatabaseName = "Vrnz2_Scheduler.db";
        public const string ContextDataFolderName = "Data";

        #endregion

        #region Constructors

        public DbContextDefault(string databasePath)
            : base(databasePath, ContextDataFolderName)
        {
        }

        #endregion

        #region Attributes

        public override string DatabaseName { get; protected set; } = ContextDatabaseName;

        #endregion
    }
}
