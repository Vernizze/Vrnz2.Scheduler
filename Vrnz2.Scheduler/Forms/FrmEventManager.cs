using Vrnz2.Scheduler.Data;
using Vrnz2.Scheduler.Data.Entities;
using Vrnz2.Scheduler.DTOs;
using Vrnz2.Scheduler.Enums.Types;
using Vrnz2.Scheduler.VisualHandlers;
using Vrnz2.Scheduler.Workers;

namespace Vrnz2.Scheduler.Forms
{
    public partial class FrmEventManager
        : Form
    {
        #region Variables

        #endregion

        #region Constructors

        public FrmEventManager()
        {
            InitializeComponent();

            ChargeComboEventManagerOccurrenceType();
        }

        #endregion

        #region Methods

        private void ChargeComboEventManagerOccurrenceType()
        {
            cmbEventManagerOccurrenceType.Items.Clear();

            cmbEventManagerOccurrenceType.Items.Add(new ComboContent((int)TOccurrence.None, "Selecione..."));

            cmbEventManagerOccurrenceType.Items.Add(new ComboContent((int)TOccurrence.Daily, "Diário"));
            cmbEventManagerOccurrenceType.Items.Add(new ComboContent((int)TOccurrence.Weekly, "Semanal"));
            cmbEventManagerOccurrenceType.Items.Add(new ComboContent((int)TOccurrence.Monthly, "Mensal"));
            cmbEventManagerOccurrenceType.Items.Add(new ComboContent((int)TOccurrence.Yearly, "Anual"));

            cmbEventManagerOccurrenceType.ValueMember = nameof(ComboContent.Id);
            cmbEventManagerOccurrenceType.DisplayMember = nameof(ComboContent.Value);

            cmbEventManagerOccurrenceType.SelectedIndex = (int)TOccurrence.None;
        }

        private void ShowHideOccurrencePanels(ComboContent selectedItem)
        {
            TOccurrence? id = (TOccurrence)selectedItem.Id;

            switch (id)
            {
                case TOccurrence.Weekly:
                    ShowHideOccurrencePanelWeekly();
                    break;
                case TOccurrence.Monthly:
                    ShowHideOccurrencePanelMonthly();
                    break;
                case TOccurrence.Yearly:
                    ShowHideOccurrencePanelYearly();
                    break;
                case TOccurrence.None:
                case TOccurrence.Daily:
                default:
                    ShowHideOccurrencePanelDefault();
                    break;
            }
        }

        private void ShowHideOccurrencePanelWeekly()
        {
            pnlEventManagerOccurrenceWeekly.Visible = true;
            pnlEventManagerOccurrenceMontly.Visible = false;
            pnlEventManagerOccurrenceYearly.Visible = false;

            chkEventManagerOccurrenceWeeklySunday.Checked = true;
            chkEventManagerOccurrenceWeeklyMonday.Checked = true;
            chkEventManagerOccurrenceWeeklyTuesday.Checked = true;
            chkEventManagerOccurrenceWeeklyWednesday.Checked = true;
            chkEventManagerOccurrenceWeeklyThursday.Checked = true;
            chkEventManagerOccurrenceWeeklyFriday.Checked = true;
            chkEventManagerOccurrenceWeeklySaturday.Checked = true;
        }

        private void ShowHideOccurrencePanelMonthly()
        {
            pnlEventManagerOccurrenceWeekly.Visible = false;
            pnlEventManagerOccurrenceMontly.Visible = true;
            pnlEventManagerOccurrenceYearly.Visible = false;

            numEventManagerOccurrenceMontly.Value = 1;
        }

        private void ShowHideOccurrencePanelYearly()
        {
            pnlEventManagerOccurrenceWeekly.Visible = false;
            pnlEventManagerOccurrenceMontly.Visible = false;
            pnlEventManagerOccurrenceYearly.Visible = true;

            dtpEventManagerOccurrenceYearly.Value = DateTime.Today;
        }

        private void ShowHideOccurrencePanelDefault()
        {
            pnlEventManagerOccurrenceWeekly.Visible = false;
            pnlEventManagerOccurrenceMontly.Visible = false;
            pnlEventManagerOccurrenceYearly.Visible = false;

            chkEventManagerOccurrenceWeeklySunday.Checked = true;
            chkEventManagerOccurrenceWeeklyMonday.Checked = true;
            chkEventManagerOccurrenceWeeklyTuesday.Checked = true;
            chkEventManagerOccurrenceWeeklyWednesday.Checked = true;
            chkEventManagerOccurrenceWeeklyThursday.Checked = true;
            chkEventManagerOccurrenceWeeklyFriday.Checked = true;
            chkEventManagerOccurrenceWeeklySaturday.Checked = true;

            numEventManagerOccurrenceMontly.Value = 1;

            dtpEventManagerOccurrenceYearly.Value = DateTime.Today;
        }

        private TOccurrence GetOccurrenceType()
        {
            if (cmbEventManagerOccurrenceType.SelectedItem is not ComboContent selectedItem)
                return TOccurrence.None;

            return (TOccurrence)selectedItem.Id;
        }

        private ScheduledEventWeeklyDetails GetScheduledEventWeeklyDetails()
            => new ScheduledEventWeeklyDetails
            {
                OccurrOnSunday = chkEventManagerOccurrenceWeeklySunday.Checked,
                OccurrOnMonday = chkEventManagerOccurrenceWeeklyMonday.Checked,
                OccurrOnTuesday = chkEventManagerOccurrenceWeeklyTuesday.Checked,
                OccurrOnWednesday = chkEventManagerOccurrenceWeeklyWednesday.Checked,
                OccurrOnThursday = chkEventManagerOccurrenceWeeklyThursday.Checked,
                OccurrOnFriday = chkEventManagerOccurrenceWeeklyFriday.Checked,
                OccurrOnSaturday = chkEventManagerOccurrenceWeeklySaturday.Checked
            };

        private ScheduledEventMonthlyDetails GetScheduledEventMountlyDetails()
            => new() { ExecutionDay = Convert.ToInt32(numEventManagerOccurrenceMontly.Value) };

        private ScheduledEventYearlyDetails GetScheduledEventYearlyDetails()
            => new() { ExecutionDate = dtpEventManagerOccurrenceYearly.Value };

        #endregion

        #region Events

        private void FrmEventManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Escape.Equals(e?.KeyCode))
                this.Close();
        }

        private void cmbEventManagerOccurrenceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEventManagerOccurrenceType.SelectedItem is not ComboContent selectedItem)
                return;

            ShowHideOccurrencePanels(selectedItem);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult? question = MessageBoxHelper.Question("Deseja realmente salvar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (DialogResult.Yes.Equals(question))
            {
                TOccurrence occurrenceType = GetOccurrenceType();

                if (TOccurrence.None.Equals(occurrenceType))
                {
                    MessageBoxHelper.Notification("Ocorrência inválida!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cmbEventManagerOccurrenceType.Focus();

                    cmbEventManagerOccurrenceType.DroppedDown = true;

                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEventManagerDescription.Text))
                {
                    MessageBoxHelper.Notification("Descrição inválida!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtEventManagerDescription.Focus();

                    txtEventManagerDescription.SelectAll();

                    return;
                }

                ScheduledEventWeeklyDetails? scheduledEventWeeklyDetails = default;
                ScheduledEventMonthlyDetails? scheduledEventMountlyDetails = default;
                ScheduledEventYearlyDetails? scheduledEventYearlyDetails = default;

                switch (occurrenceType)
                {
                    case TOccurrence.Weekly:
                        scheduledEventWeeklyDetails = GetScheduledEventWeeklyDetails();
                        break;
                    case TOccurrence.Monthly:
                        scheduledEventMountlyDetails = GetScheduledEventMountlyDetails();
                        break;
                    case TOccurrence.Yearly:
                        scheduledEventYearlyDetails = GetScheduledEventYearlyDetails();
                        break;
                    case TOccurrence.Daily:
                    default:
                        break;
                }

                ScheduledEvent? scheduledEvent = new()
                {
                    OccurrenceType = occurrenceType,
                    Description = txtEventManagerDescription.Text,
                    ExecutionDate = DateOnly.FromDateTime(dtpEventManagerEventTime.Value),
                    ExecutionTime = TimeOnly.FromDateTime(dtpEventManagerEventTime.Value)
                };

                UnitOfWork.Instance.ScheduledEvent.Insert(scheduledEvent);

                if (scheduledEventWeeklyDetails is not null)
                {
                    scheduledEventWeeklyDetails.ScheduledEventId = scheduledEvent.Id;

                    UnitOfWork.Instance.ScheduledEventWeeklyDetails.Insert(scheduledEventWeeklyDetails);
                }

                if (scheduledEventMountlyDetails is not null)
                {
                    scheduledEventMountlyDetails.ScheduledEventId = scheduledEvent.Id;

                    UnitOfWork.Instance.ScheduledEventMonthlyDetails.Insert(scheduledEventMountlyDetails);
                }

                if (scheduledEventYearlyDetails is not null)
                {
                    scheduledEventYearlyDetails.ScheduledEventId = scheduledEvent.Id;

                    UnitOfWork.Instance.ScheduledEventYearlyDetails.Insert(scheduledEventYearlyDetails);
                }

                ScheduleWorker.Instance.Restart();

                txtEventManagerDescription.Text = string.Empty;
                cmbEventManagerOccurrenceType.SelectedIndex = (int)TOccurrence.None;
                dtpEventManagerEventTime.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0);

                ShowHideOccurrencePanelDefault();

                txtEventManagerDescription.Focus();
            }
        }

        #endregion
    }
}
