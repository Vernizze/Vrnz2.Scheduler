using Microsoft.Win32;
using Vrnz2.Scheduler.VisualHandlers;

namespace Vrnz2.Scheduler.Forms
{
    public partial class FrmConfigurations 
        : Form
    {
        #region Constructors

        public FrmConfigurations()
        {
            InitializeComponent();

            chkStartOnWindows.Checked = StartOnWindows();
        }

        #endregion

        #region Methods

        public static object? GetRegKey()
        {
            RegistryKey? vrClockInRegKey = Registry.LocalMachine.OpenSubKey(Consts.LocalMachineSoftwareMicrosoftWindowsCurrentVersionRunKeyPath, true);

            return vrClockInRegKey?.GetValue(Consts.ApplicationName);
        }

        public static void SetRegKey()
        {
            RegistryKey? vrClockInRegKey = Registry.LocalMachine.OpenSubKey(Consts.LocalMachineSoftwareMicrosoftWindowsCurrentVersionRunKeyPath, true);

            vrClockInRegKey?.SetValue(Consts.ApplicationName, Path.Combine(Consts.AppPath, Consts.ApplicationExeName));
        }

        public static void SetRegKey2()
        {
            RegistryKey? vrClockInRegKey = Registry.LocalMachine.OpenSubKey(Consts.LocalMachineSoftwareApplicationKeyPath, true);

            vrClockInRegKey?.SetValue(Consts.ApplicationName, Path.Combine(Consts.AppPath, Consts.ApplicationExeName));
        }

        public static void DeleteRegKey()
        {
            RegistryKey? vrClockInRegKey = Registry.LocalMachine.OpenSubKey(Consts.LocalMachineSoftwareMicrosoftWindowsCurrentVersionRunKeyPath, true);

            vrClockInRegKey?.DeleteValue(Consts.ApplicationName);
        }

        public static bool StartOnWindows()
            => GetRegKey() is not null;

        public static void SetStartOnWindows(bool startOnWindows)
        {
            bool alreadyStartOnWindows = StartOnWindows();

            if (startOnWindows && alreadyStartOnWindows)
                return;

            if (!startOnWindows && !alreadyStartOnWindows)
                return;

            if (startOnWindows)
                SetRegKey();
            else
                DeleteRegKey();
        }

        #endregion

        #region Evetns

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBoxHelper.Question("Deseja realmente salvar as Configurações?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (DialogResult.Yes.Equals(dialogResult))
            {
                SetStartOnWindows(chkStartOnWindows.Checked);

                Close();
            }
        }

        #endregion
    }
}
