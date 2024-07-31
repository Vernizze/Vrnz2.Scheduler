namespace Vrnz2.Scheduler.Forms
{
    partial class FrmEventManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEventManager));
            grbEventManager = new GroupBox();
            cmbEventManagerOccurrenceType = new ComboBox();
            lblEventManagerOccurrenceType = new Label();
            dtpEventManagerEventTime = new DateTimePicker();
            lblEventManagerEventTime = new Label();
            txtEventManagerDescription = new TextBox();
            lblEventManagerDescription = new Label();
            pnlEventManagerOccurrenceWeekly = new Panel();
            chkEventManagerOccurrenceWeeklyFriday = new CheckBox();
            chkEventManagerOccurrenceWeeklyThursday = new CheckBox();
            chkEventManagerOccurrenceWeeklyWednesday = new CheckBox();
            chkEventManagerOccurrenceWeeklyTuesday = new CheckBox();
            chkEventManagerOccurrenceWeeklyMonday = new CheckBox();
            chkEventManagerOccurrenceWeeklySaturday = new CheckBox();
            chkEventManagerOccurrenceWeeklySunday = new CheckBox();
            pnlEventManagerOccurrenceYearly = new Panel();
            lblEventManagerOccurrenceYearly = new Label();
            dtpEventManagerOccurrenceYearly = new DateTimePicker();
            pnlEventManagerOccurrenceMontly = new Panel();
            numEventManagerOccurrenceMontly = new NumericUpDown();
            lblEventManagerOccurrenceMontly = new Label();
            btnSave = new Button();
            grbEventManager.SuspendLayout();
            pnlEventManagerOccurrenceWeekly.SuspendLayout();
            pnlEventManagerOccurrenceYearly.SuspendLayout();
            pnlEventManagerOccurrenceMontly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numEventManagerOccurrenceMontly).BeginInit();
            SuspendLayout();
            // 
            // grbEventManager
            // 
            grbEventManager.Controls.Add(cmbEventManagerOccurrenceType);
            grbEventManager.Controls.Add(lblEventManagerOccurrenceType);
            grbEventManager.Controls.Add(dtpEventManagerEventTime);
            grbEventManager.Controls.Add(lblEventManagerEventTime);
            grbEventManager.Controls.Add(txtEventManagerDescription);
            grbEventManager.Controls.Add(lblEventManagerDescription);
            grbEventManager.Controls.Add(pnlEventManagerOccurrenceWeekly);
            grbEventManager.Controls.Add(pnlEventManagerOccurrenceYearly);
            grbEventManager.Controls.Add(pnlEventManagerOccurrenceMontly);
            grbEventManager.Location = new Point(0, -2);
            grbEventManager.Name = "grbEventManager";
            grbEventManager.Size = new Size(374, 171);
            grbEventManager.TabIndex = 0;
            grbEventManager.TabStop = false;
            grbEventManager.Text = "Dados do Evento";
            // 
            // cmbEventManagerOccurrenceType
            // 
            cmbEventManagerOccurrenceType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEventManagerOccurrenceType.FormattingEnabled = true;
            cmbEventManagerOccurrenceType.Location = new Point(98, 82);
            cmbEventManagerOccurrenceType.Name = "cmbEventManagerOccurrenceType";
            cmbEventManagerOccurrenceType.Size = new Size(121, 23);
            cmbEventManagerOccurrenceType.TabIndex = 2;
            cmbEventManagerOccurrenceType.SelectedIndexChanged += cmbEventManagerOccurrenceType_SelectedIndexChanged;
            // 
            // lblEventManagerOccurrenceType
            // 
            lblEventManagerOccurrenceType.AutoSize = true;
            lblEventManagerOccurrenceType.Location = new Point(98, 64);
            lblEventManagerOccurrenceType.Name = "lblEventManagerOccurrenceType";
            lblEventManagerOccurrenceType.Size = new Size(68, 15);
            lblEventManagerOccurrenceType.TabIndex = 4;
            lblEventManagerOccurrenceType.Text = "Ocorrência:";
            // 
            // dtpEventManagerEventTime
            // 
            dtpEventManagerEventTime.Format = DateTimePickerFormat.Time;
            dtpEventManagerEventTime.Location = new Point(7, 82);
            dtpEventManagerEventTime.Name = "dtpEventManagerEventTime";
            dtpEventManagerEventTime.Size = new Size(78, 23);
            dtpEventManagerEventTime.TabIndex = 1;
            dtpEventManagerEventTime.Value = new DateTime(2024, 7, 22, 0, 0, 0, 0);
            // 
            // lblEventManagerEventTime
            // 
            lblEventManagerEventTime.AutoSize = true;
            lblEventManagerEventTime.Location = new Point(7, 64);
            lblEventManagerEventTime.Name = "lblEventManagerEventTime";
            lblEventManagerEventTime.Size = new Size(50, 15);
            lblEventManagerEventTime.TabIndex = 2;
            lblEventManagerEventTime.Text = "Horário:";
            // 
            // txtEventManagerDescription
            // 
            txtEventManagerDescription.Location = new Point(7, 34);
            txtEventManagerDescription.Name = "txtEventManagerDescription";
            txtEventManagerDescription.Size = new Size(362, 23);
            txtEventManagerDescription.TabIndex = 0;
            // 
            // lblEventManagerDescription
            // 
            lblEventManagerDescription.AutoSize = true;
            lblEventManagerDescription.Location = new Point(7, 16);
            lblEventManagerDescription.Name = "lblEventManagerDescription";
            lblEventManagerDescription.Size = new Size(61, 15);
            lblEventManagerDescription.TabIndex = 0;
            lblEventManagerDescription.Text = "Descrição:";
            // 
            // pnlEventManagerOccurrenceWeekly
            // 
            pnlEventManagerOccurrenceWeekly.Controls.Add(chkEventManagerOccurrenceWeeklyFriday);
            pnlEventManagerOccurrenceWeekly.Controls.Add(chkEventManagerOccurrenceWeeklyThursday);
            pnlEventManagerOccurrenceWeekly.Controls.Add(chkEventManagerOccurrenceWeeklyWednesday);
            pnlEventManagerOccurrenceWeekly.Controls.Add(chkEventManagerOccurrenceWeeklyTuesday);
            pnlEventManagerOccurrenceWeekly.Controls.Add(chkEventManagerOccurrenceWeeklyMonday);
            pnlEventManagerOccurrenceWeekly.Controls.Add(chkEventManagerOccurrenceWeeklySaturday);
            pnlEventManagerOccurrenceWeekly.Controls.Add(chkEventManagerOccurrenceWeeklySunday);
            pnlEventManagerOccurrenceWeekly.Location = new Point(4, 110);
            pnlEventManagerOccurrenceWeekly.Name = "pnlEventManagerOccurrenceWeekly";
            pnlEventManagerOccurrenceWeekly.Size = new Size(367, 55);
            pnlEventManagerOccurrenceWeekly.TabIndex = 6;
            pnlEventManagerOccurrenceWeekly.Visible = false;
            // 
            // chkEventManagerOccurrenceWeeklyFriday
            // 
            chkEventManagerOccurrenceWeeklyFriday.AutoSize = true;
            chkEventManagerOccurrenceWeeklyFriday.Location = new Point(269, 6);
            chkEventManagerOccurrenceWeeklyFriday.Name = "chkEventManagerOccurrenceWeeklyFriday";
            chkEventManagerOccurrenceWeeklyFriday.Size = new Size(44, 19);
            chkEventManagerOccurrenceWeeklyFriday.TabIndex = 6;
            chkEventManagerOccurrenceWeeklyFriday.Text = "Sex";
            chkEventManagerOccurrenceWeeklyFriday.UseVisualStyleBackColor = true;
            // 
            // chkEventManagerOccurrenceWeeklyThursday
            // 
            chkEventManagerOccurrenceWeeklyThursday.AutoSize = true;
            chkEventManagerOccurrenceWeeklyThursday.Location = new Point(218, 6);
            chkEventManagerOccurrenceWeeklyThursday.Name = "chkEventManagerOccurrenceWeeklyThursday";
            chkEventManagerOccurrenceWeeklyThursday.Size = new Size(45, 19);
            chkEventManagerOccurrenceWeeklyThursday.TabIndex = 5;
            chkEventManagerOccurrenceWeeklyThursday.Text = "Qui";
            chkEventManagerOccurrenceWeeklyThursday.UseVisualStyleBackColor = true;
            // 
            // chkEventManagerOccurrenceWeeklyWednesday
            // 
            chkEventManagerOccurrenceWeeklyWednesday.AutoSize = true;
            chkEventManagerOccurrenceWeeklyWednesday.Location = new Point(164, 6);
            chkEventManagerOccurrenceWeeklyWednesday.Name = "chkEventManagerOccurrenceWeeklyWednesday";
            chkEventManagerOccurrenceWeeklyWednesday.Size = new Size(48, 19);
            chkEventManagerOccurrenceWeeklyWednesday.TabIndex = 4;
            chkEventManagerOccurrenceWeeklyWednesday.Text = "Qua";
            chkEventManagerOccurrenceWeeklyWednesday.UseVisualStyleBackColor = true;
            // 
            // chkEventManagerOccurrenceWeeklyTuesday
            // 
            chkEventManagerOccurrenceWeeklyTuesday.AutoSize = true;
            chkEventManagerOccurrenceWeeklyTuesday.Location = new Point(117, 6);
            chkEventManagerOccurrenceWeeklyTuesday.Name = "chkEventManagerOccurrenceWeeklyTuesday";
            chkEventManagerOccurrenceWeeklyTuesday.Size = new Size(41, 19);
            chkEventManagerOccurrenceWeeklyTuesday.TabIndex = 3;
            chkEventManagerOccurrenceWeeklyTuesday.Text = "Ter";
            chkEventManagerOccurrenceWeeklyTuesday.UseVisualStyleBackColor = true;
            // 
            // chkEventManagerOccurrenceWeeklyMonday
            // 
            chkEventManagerOccurrenceWeeklyMonday.AutoSize = true;
            chkEventManagerOccurrenceWeeklyMonday.Location = new Point(66, 6);
            chkEventManagerOccurrenceWeeklyMonday.Name = "chkEventManagerOccurrenceWeeklyMonday";
            chkEventManagerOccurrenceWeeklyMonday.Size = new Size(45, 19);
            chkEventManagerOccurrenceWeeklyMonday.TabIndex = 2;
            chkEventManagerOccurrenceWeeklyMonday.Text = "Seg";
            chkEventManagerOccurrenceWeeklyMonday.UseVisualStyleBackColor = true;
            // 
            // chkEventManagerOccurrenceWeeklySaturday
            // 
            chkEventManagerOccurrenceWeeklySaturday.AutoSize = true;
            chkEventManagerOccurrenceWeeklySaturday.Location = new Point(320, 6);
            chkEventManagerOccurrenceWeeklySaturday.Name = "chkEventManagerOccurrenceWeeklySaturday";
            chkEventManagerOccurrenceWeeklySaturday.Size = new Size(45, 19);
            chkEventManagerOccurrenceWeeklySaturday.TabIndex = 1;
            chkEventManagerOccurrenceWeeklySaturday.Text = "Sáb";
            chkEventManagerOccurrenceWeeklySaturday.UseVisualStyleBackColor = true;
            // 
            // chkEventManagerOccurrenceWeeklySunday
            // 
            chkEventManagerOccurrenceWeeklySunday.AutoSize = true;
            chkEventManagerOccurrenceWeeklySunday.Location = new Point(8, 6);
            chkEventManagerOccurrenceWeeklySunday.Name = "chkEventManagerOccurrenceWeeklySunday";
            chkEventManagerOccurrenceWeeklySunday.Size = new Size(52, 19);
            chkEventManagerOccurrenceWeeklySunday.TabIndex = 0;
            chkEventManagerOccurrenceWeeklySunday.Text = "Dom";
            chkEventManagerOccurrenceWeeklySunday.UseVisualStyleBackColor = true;
            // 
            // pnlEventManagerOccurrenceYearly
            // 
            pnlEventManagerOccurrenceYearly.Controls.Add(lblEventManagerOccurrenceYearly);
            pnlEventManagerOccurrenceYearly.Controls.Add(dtpEventManagerOccurrenceYearly);
            pnlEventManagerOccurrenceYearly.Location = new Point(4, 110);
            pnlEventManagerOccurrenceYearly.Name = "pnlEventManagerOccurrenceYearly";
            pnlEventManagerOccurrenceYearly.Size = new Size(367, 55);
            pnlEventManagerOccurrenceYearly.TabIndex = 9;
            pnlEventManagerOccurrenceYearly.Visible = false;
            // 
            // lblEventManagerOccurrenceYearly
            // 
            lblEventManagerOccurrenceYearly.AutoSize = true;
            lblEventManagerOccurrenceYearly.Location = new Point(3, 5);
            lblEventManagerOccurrenceYearly.Name = "lblEventManagerOccurrenceYearly";
            lblEventManagerOccurrenceYearly.Size = new Size(87, 15);
            lblEventManagerOccurrenceYearly.TabIndex = 1;
            lblEventManagerOccurrenceYearly.Text = "Data Execução:";
            // 
            // dtpEventManagerOccurrenceYearly
            // 
            dtpEventManagerOccurrenceYearly.Format = DateTimePickerFormat.Short;
            dtpEventManagerOccurrenceYearly.Location = new Point(3, 23);
            dtpEventManagerOccurrenceYearly.Name = "dtpEventManagerOccurrenceYearly";
            dtpEventManagerOccurrenceYearly.Size = new Size(81, 23);
            dtpEventManagerOccurrenceYearly.TabIndex = 0;
            // 
            // pnlEventManagerOccurrenceMontly
            // 
            pnlEventManagerOccurrenceMontly.Controls.Add(numEventManagerOccurrenceMontly);
            pnlEventManagerOccurrenceMontly.Controls.Add(lblEventManagerOccurrenceMontly);
            pnlEventManagerOccurrenceMontly.Location = new Point(4, 110);
            pnlEventManagerOccurrenceMontly.Name = "pnlEventManagerOccurrenceMontly";
            pnlEventManagerOccurrenceMontly.Size = new Size(367, 55);
            pnlEventManagerOccurrenceMontly.TabIndex = 8;
            pnlEventManagerOccurrenceMontly.Visible = false;
            // 
            // numEventManagerOccurrenceMontly
            // 
            numEventManagerOccurrenceMontly.Location = new Point(8, 24);
            numEventManagerOccurrenceMontly.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            numEventManagerOccurrenceMontly.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numEventManagerOccurrenceMontly.Name = "numEventManagerOccurrenceMontly";
            numEventManagerOccurrenceMontly.Size = new Size(91, 23);
            numEventManagerOccurrenceMontly.TabIndex = 3;
            numEventManagerOccurrenceMontly.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblEventManagerOccurrenceMontly
            // 
            lblEventManagerOccurrenceMontly.AutoSize = true;
            lblEventManagerOccurrenceMontly.Location = new Point(3, 6);
            lblEventManagerOccurrenceMontly.Name = "lblEventManagerOccurrenceMontly";
            lblEventManagerOccurrenceMontly.Size = new Size(96, 15);
            lblEventManagerOccurrenceMontly.TabIndex = 2;
            lblEventManagerOccurrenceMontly.Text = "Dia de Execução:";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(380, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 3;
            btnSave.Text = "Salvar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // FrmEventManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 172);
            Controls.Add(btnSave);
            Controls.Add(grbEventManager);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "FrmEventManager";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Evento";
            KeyDown += FrmEventManager_KeyDown;
            grbEventManager.ResumeLayout(false);
            grbEventManager.PerformLayout();
            pnlEventManagerOccurrenceWeekly.ResumeLayout(false);
            pnlEventManagerOccurrenceWeekly.PerformLayout();
            pnlEventManagerOccurrenceYearly.ResumeLayout(false);
            pnlEventManagerOccurrenceYearly.PerformLayout();
            pnlEventManagerOccurrenceMontly.ResumeLayout(false);
            pnlEventManagerOccurrenceMontly.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numEventManagerOccurrenceMontly).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grbEventManager;
        private DateTimePicker dtpEventManagerEventTime;
        private Label lblEventManagerEventTime;
        private TextBox txtEventManagerDescription;
        private Label lblEventManagerDescription;
        private ComboBox cmbEventManagerOccurrenceType;
        private Label lblEventManagerOccurrenceType;
        private Panel pnlEventManagerOccurrenceWeekly;
        private CheckBox chkEventManagerOccurrenceWeeklySaturday;
        private CheckBox chkEventManagerOccurrenceWeeklySunday;
        private CheckBox chkEventManagerOccurrenceWeeklyTuesday;
        private CheckBox chkEventManagerOccurrenceWeeklyMonday;
        private CheckBox chkEventManagerOccurrenceWeeklyFriday;
        private CheckBox chkEventManagerOccurrenceWeeklyThursday;
        private CheckBox chkEventManagerOccurrenceWeeklyWednesday;
        private Panel pnlEventManagerOccurrenceMontly;
        private Panel pnlEventManagerOccurrenceYearly;
        private NumericUpDown numEventManagerOccurrenceMontly;
        private Label lblEventManagerOccurrenceMontly;
        private Label lblEventManagerOccurrenceYearly;
        private DateTimePicker dtpEventManagerOccurrenceYearly;
        private Button btnSave;
    }
}