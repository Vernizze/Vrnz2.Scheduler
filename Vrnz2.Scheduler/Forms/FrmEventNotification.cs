using Vrnz2.Scheduler.Sounds;
using Tmr = System.Windows.Forms.Timer;

namespace Vrnz2.Scheduler.Forms
{
    public partial class FrmEventNotification
        : Form
    {
        #region Constants

        public const string MessagesSpacer = "---------------Lembrete #{0}--------------";

        #endregion

        #region Variables

        private readonly List<string?>? _eventMessages;

        private readonly Tmr? _closeFormTimer;

        #endregion

        #region Constructors

        public FrmEventNotification(List<string?>? eventMessages)
        {
            _eventMessages = eventMessages;

            InitializeComponent();

            _closeFormTimer = new();

            Player.Instance.Play(Player.TSound.EventNoritification);

            TimerSetup();
        }

        #endregion

        #region Methods

        private void WriteMessage(int messageCounter, string? message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return;

            rtbEventNotification.AppendText(string.Concat(string.Format(MessagesSpacer, messageCounter), Environment.NewLine));

            rtbEventNotification.AppendText(string.Concat(message, Environment.NewLine));
        }

        private void TimerSetup()
        {
            if (_closeFormTimer is null)
                return;

            _closeFormTimer.Tick += delegate { this.Close(); };

            _closeFormTimer.Interval = (int)TimeSpan.FromMinutes(1).TotalMilliseconds;
        }

        private void SetFormLocation()
        {
            var screen = Screen.FromPoint(this.Location);

            this.Location = new Point(screen.WorkingArea.Right - this.Width, screen.WorkingArea.Bottom - this.Height);
        }

        #endregion

        #region Events

        private void FrmEventNotification_Shown(object sender, EventArgs e)
        {
            SetFormLocation();

            int i = 1;

            _eventMessages?.ForEach(message => WriteMessage(i++, message));

            _closeFormTimer?.Start();
        }

        #endregion
    }
}
