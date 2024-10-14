namespace Vrnz2.Scheduler
{
    public static class Consts
    {
        #region Constants

        public static readonly string AppPath = AppDomain.CurrentDomain.BaseDirectory;

        public const string LocalMachineSoftwareMicrosoftWindowsCurrentVersionRunKeyPath = $"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        public const string LocalMachineSoftwareApplicationKeyPath = $"SOFTWARE\\{ApplicationName}";
        public const string ApplicationName = "Vrnz2.Scheduler";
        public const string ApplicationExeName = "Vrnz2.Scheduler.exe";

        #endregion
    }
}
