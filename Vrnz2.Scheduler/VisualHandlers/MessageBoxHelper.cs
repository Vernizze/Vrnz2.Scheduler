namespace Vrnz2.Scheduler.VisualHandlers
{
    internal static class MessageBoxHelper
    {
        #region Constants 

        public const string MessageBoxCaption = "Vrnz2 Scheduler";

        #endregion

        #region Methods 

        public static void Notification(
            string message,
            MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK,
            MessageBoxIcon messageBoxIcon = MessageBoxIcon.Information,
            MessageBoxDefaultButton messageBoxDefaultButton = MessageBoxDefaultButton.Button1)
            => Notification(default, message, messageBoxButtons, messageBoxIcon, messageBoxDefaultButton, default);

        public static void Notification(
            IWin32Window? parent,
            string message,
            MessageBoxButtons messageBoxButtons,
            MessageBoxIcon messageBoxIcon,
            MessageBoxDefaultButton? messageBoxDefaultButton,
            MessageBoxOptions? messageBoxOptions)
            => _ = Question(parent, message, messageBoxButtons, messageBoxIcon, messageBoxDefaultButton, messageBoxOptions);

        public static DialogResult Notification(
            IWin32Window? parent,
            string message,
            MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK,
            MessageBoxIcon messageBoxIcon = MessageBoxIcon.Information,
            MessageBoxDefaultButton messageBoxDefaultButton = MessageBoxDefaultButton.Button1)
            => Question(parent, message, messageBoxButtons, messageBoxIcon, messageBoxDefaultButton, default);

        public static DialogResult Question(
            string message,
            MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK,
            MessageBoxIcon messageBoxIcon = MessageBoxIcon.Information,
            MessageBoxDefaultButton messageBoxDefaultButton = MessageBoxDefaultButton.Button1)
            => Question(default, message, messageBoxButtons, messageBoxIcon, messageBoxDefaultButton, default);

        public static DialogResult Question(
            IWin32Window? parent,
            string message,
            MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK,
            MessageBoxIcon messageBoxIcon = MessageBoxIcon.Information,
            MessageBoxDefaultButton messageBoxDefaultButton = MessageBoxDefaultButton.Button1)
            => Question(parent, message, messageBoxButtons, messageBoxIcon, messageBoxDefaultButton, default);

        public static DialogResult Question(
            IWin32Window? parent,
            string message,
            MessageBoxButtons messageBoxButtons,
            MessageBoxIcon messageBoxIcon,
            MessageBoxDefaultButton? messageBoxDefaultButton,
            MessageBoxOptions? messageBoxOptions)
        {
            if (messageBoxDefaultButton is not null && messageBoxOptions is not null)
                return MessageBox.Show(parent, message, MessageBoxCaption, messageBoxButtons, messageBoxIcon, messageBoxDefaultButton.Value, messageBoxOptions.Value);

            if (messageBoxDefaultButton is not null && messageBoxOptions is null)
                return MessageBox.Show(parent, message, MessageBoxCaption, messageBoxButtons, messageBoxIcon, messageBoxDefaultButton.Value);

            return MessageBox.Show(parent, message, MessageBoxCaption, messageBoxButtons, messageBoxIcon);
        }

        #endregion
    }
}
