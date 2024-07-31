namespace Vrnz2.Scheduler.Data.Contexts
{
    public class DbContextHelper
    {
        #region Variables

        private static readonly Lazy<DbContextHelper> _instance = new(() => new DbContextHelper());

        private readonly IDbContext _defaultDbContext;

        #endregion

        #region Constructors

        private DbContextHelper()
            => _defaultDbContext = new DbContextDefault(Consts.AppPath);

        #endregion

        #region Attributes

        public static DbContextHelper Instance => _instance.Value;

        public IDbContext DefaultContext => _defaultDbContext;

        #endregion
    }
}
