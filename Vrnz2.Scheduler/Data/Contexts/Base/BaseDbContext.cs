using LiteDB;

namespace Vrnz2.Scheduler.Data.Contexts.Base
{
    public abstract class BaseDbContext
        : IDbContext
    {
        #region Constructors

        protected BaseDbContext(string databasePath, string dataFolderName)
        {
            DatabasePath = databasePath;

            if (Path.GetFileName(databasePath).Equals(dataFolderName))
                DataPath = DatabasePath;
            else
                DataPath = Path.Combine(DatabasePath, dataFolderName);

            if (!Directory.Exists(DataPath))
                Directory.CreateDirectory(DataPath);

            DatabaseFullName = Path.Combine(DataPath, DatabaseName);
        }

        #endregion

        #region Attributes

        public abstract string DatabaseName { get; protected set; }

        public virtual string DatabaseFullName { get; protected set; }
        public virtual string DataPath { get; protected set; }
        public virtual string DatabasePath { get; protected set; }

        #endregion 

        #region Methods

        public virtual TResult Exec<TRequest, TResult>(Func<LiteDatabase, TRequest, TResult> func, string databaseFilePath, TRequest request)
        {
            TResult res;

            using LiteDatabase db = new(databaseFilePath);

            res = func(db, request);

            return res;
        }

        public virtual void Exec(Action<LiteDatabase> func, string databaseFilePath)
        {
            using LiteDatabase db = new(databaseFilePath);

            func(db);
        }

        public virtual void Exec<TRequest>(Action<LiteDatabase, TRequest> func, string databaseFilePath, TRequest request)
        {
            using LiteDatabase db = new(databaseFilePath);

            func(db, request);
        }

        #endregion
    }
}
