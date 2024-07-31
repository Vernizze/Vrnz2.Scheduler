using LiteDB;

namespace Vrnz2.Scheduler.Data.Contexts
{
    public interface IDbContext
    {
        #region Attributes

        string DatabaseName { get; }
        string DatabaseFullName { get; }
        string DataPath { get; }
        string DatabasePath { get; }

        #endregion

        #region Methods

        TResult Exec<TRequest, TResult>(Func<LiteDatabase, TRequest, TResult> func, string databaseFilePath, TRequest request);

        void Exec(Action<LiteDatabase> func, string databaseFilePath);

        void Exec<TRequest>(Action<LiteDatabase, TRequest> func, string databaseFilePath, TRequest request);

        #endregion
    }
}
