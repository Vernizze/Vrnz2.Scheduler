using Vrnz2.Scheduler.Enums.Types;
using Vrnz2.Scheduler.Security;
using Vrnz2.Scheduler.Sounds;
using Vrnz2.Scheduler.VisualHandlers;
using Vrnz2.Scheduler.Workers;
using DataEntity = Vrnz2.Scheduler.Data.Entities;

namespace Vrnz2.Scheduler.Forms
{
    public partial class FrmMain
        : Form
    {
        #region Delegates

        internal delegate void AddGridLineHandler(DataEntity.ScheduledEvent scheduledEvent);
        private delegate void ShowEventMessagesHandler(List<string?>? eventMessages);

        #endregion

        #region Constructors

        public FrmMain()
        {
            InitializeComponent();

            if (!ElevationHandler.IsAdmin())
                ElevationHandler.AddShieldToButton(btnConfigurations);
            else
                Text += " (Admin)";

            ntiMain.Icon = Resource.clock;

            ConfigDataGridColumns();
        }

        #endregion

        #region Methods

        private static bool KillForm()
        {
            DialogResult dialogResult = MessageBoxHelper.Question("Deseja realmente sair?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);//TODO: Internacionalização!

            bool result = DialogResult.Yes.Equals(dialogResult);

            if (result)
                Application.Exit();

            return result;
        }

        private void UpdateEvents()
        {
            List<DataEntity.ScheduledEvent> todayEvents = ScheduleWorker.Instance.TodayEvents;

            dtgMain.Rows.Clear();

            todayEvents.ForEach(AddGridLine);
        }

        private void ShowEventMessages(List<string?>? eventMessages)
        {
            try
            {
                if (eventMessages is null)
                    return;

                string message = eventMessages?.FirstOrDefault() ?? "Atenção!";

                ntiMain.Visible = true;
                ntiMain.BalloonTipText = message;
                ntiMain.ShowBalloonTip(1000);

                ShowEventNotificationForm(eventMessages);
            }
            catch (Exception)
            {

            }
        }

        private void ShowEventNotificationForm(List<string?>? eventMessages)
        {
            if (InvokeRequired)
            {
                var d = new ShowEventMessagesHandler(ShowEventNotificationFormThread);
                object value = this.Invoke(d, [eventMessages]);
            }
            else
            {
                try
                {
                    if (eventMessages is null)
                        return;

                    FrmEventNotification frmEventNotification = new(eventMessages);

                    frmEventNotification.Show();
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void ShowEventNotificationFormThread(List<string?>? eventMessages)
            => ShowEventNotificationForm(eventMessages);

        //DataGrid
        private void ConfigDataGridColumns()
        {
            DataGridViewTextBoxColumn textColumnId = new()
            {
                ValueType = typeof(string),
                Name = "id",
                HeaderText = "Id",
                Visible = false
            };

            dtgMain.Columns.Add(textColumnId);

            DataGridViewTextBoxColumn textColumnDescription = new()
            {
                ValueType = typeof(string),
                Name = "description",
                HeaderText = "Descrição"
            };

            dtgMain.Columns.Add(textColumnDescription);

            DataGridViewTextBoxColumn textColumnOccurrenceType = new()
            {
                ValueType = typeof(string),
                Name = "occurrenceType",
                HeaderText = "Tipo"
            };

            dtgMain.Columns.Add(textColumnOccurrenceType);

            DataGridViewTextBoxColumn textColumnExecutionDate = new()
            {
                ValueType = typeof(string),
                Name = "executionDate",
                HeaderText = "Data"
            };

            dtgMain.Columns.Add(textColumnExecutionDate);

            DataGridViewTextBoxColumn textColumnExecutionTime = new()
            {
                ValueType = typeof(string),
                Name = "executionTime",
                HeaderText = "Hora"
            };

            dtgMain.Columns.Add(textColumnExecutionTime);

            dtgMain.Columns[(int)TDataGridColumnsIndexes.OccurrenceType].Width = 80;
            dtgMain.Columns[(int)TDataGridColumnsIndexes.ExecutionDate].Width = 80;
            dtgMain.Columns[(int)TDataGridColumnsIndexes.ExecutionTime].Width = 80;
            dtgMain.Columns[(int)TDataGridColumnsIndexes.Description].Width =
            dtgMain.Width -
                dtgMain.Columns[(int)TDataGridColumnsIndexes.OccurrenceType].Width -
                dtgMain.Columns[(int)TDataGridColumnsIndexes.ExecutionDate].Width -
                dtgMain.Columns[(int)TDataGridColumnsIndexes.ExecutionTime].Width -
                (dtgMain.Width / 100 * 9);
        }

        private void AddGridLine(DataEntity.ScheduledEvent scheduledEvent)
        {
            if (dtgMain.InvokeRequired)
            {
                var d = new AddGridLineHandler(AddGridLineThread);
                dtgMain.Invoke(d, [scheduledEvent]);
            }
            else
            {
                var row = new DataGridViewRow();

                row.CreateCells(dtgMain);

                SetGridLine(scheduledEvent, row);

                dtgMain.Rows.Add(row);
            }
        }

        private void AddGridLineThread(DataEntity.ScheduledEvent scheduledEvent)
            => AddGridLine(scheduledEvent);

        private static void SetGridLine(DataEntity.ScheduledEvent scheduledEvent, DataGridViewRow row)
        {
            row.Cells[(int)TDataGridColumnsIndexes.Id].Value = scheduledEvent.Id;
            row.Cells[(int)TDataGridColumnsIndexes.Description].Value = scheduledEvent.Description;
            row.Cells[(int)TDataGridColumnsIndexes.OccurrenceType].Value = scheduledEvent.OccurrenceType;
            row.Cells[(int)TDataGridColumnsIndexes.ExecutionDate].Value = scheduledEvent.ExecutionDate;
            row.Cells[(int)TDataGridColumnsIndexes.ExecutionTime].Value = scheduledEvent.ExecutionTime;
        }

        #endregion

        #region Events

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            UpdateEvents();

            ScheduleWorker.Instance.NotifyMessages += ShowEventMessages;

            Hide();
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized.Equals(WindowState))
            {
                Hide();

                ntiMain.Visible = true;
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseReason.UserClosing.Equals(e?.CloseReason))
            {
                if (!KillForm())
                    e.Cancel = true;
            }
        }

        private void ntiMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();

            WindowState = FormWindowState.Normal;

            ntiMain.Visible = false;
        }

        private void dtgMain_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtgMain.CurrentCell is null)
                return;

            int rowIndex = dtgMain.CurrentCell.RowIndex;

            if (rowIndex >= 0)
            {
                DataGridViewRow? row = dtgMain.Rows[rowIndex];

                if (row is null)
                    return;

                string? eventId = row.Cells[(int)TDataGridColumnsIndexes.Id].Value.ToString();

                if (eventId is null)
                    return;

                FrmEventManager frmEventManager = new(eventId);

                frmEventManager.ShowDialog(this);

                UpdateEvents();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmEventManager frmEventManager = new();

            frmEventManager.ShowDialog(this);

            UpdateEvents();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
            => UpdateEvents();

        private void btnConfigurations_Click(object sender, EventArgs e)
        {
            if (ElevationHandler.IsAdmin())
            {
                FrmConfigurations frmConfigurations = new();

                frmConfigurations.ShowDialog(this);
            }
            else
            {
                ElevationHandler.RestartElevated();
            }
        }

        #endregion
    }
}
