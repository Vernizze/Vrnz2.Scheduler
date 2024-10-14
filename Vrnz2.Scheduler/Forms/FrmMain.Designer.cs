namespace Vrnz2.Scheduler.Forms
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            grbMain = new GroupBox();
            dtgMain = new DataGridView();
            ntiMain = new NotifyIcon(components);
            grbButtons = new GroupBox();
            btnConfigurations = new Button();
            btnRefresh = new Button();
            btnAdd = new Button();
            grbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgMain).BeginInit();
            grbButtons.SuspendLayout();
            SuspendLayout();
            // 
            // grbMain
            // 
            grbMain.Controls.Add(dtgMain);
            grbMain.Location = new Point(2, -2);
            grbMain.Name = "grbMain";
            grbMain.Size = new Size(466, 205);
            grbMain.TabIndex = 0;
            grbMain.TabStop = false;
            grbMain.Text = "Agendamentos";
            // 
            // dtgMain
            // 
            dtgMain.AllowUserToAddRows = false;
            dtgMain.AllowUserToDeleteRows = false;
            dtgMain.AllowUserToResizeRows = false;
            dtgMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgMain.Location = new Point(6, 19);
            dtgMain.MultiSelect = false;
            dtgMain.Name = "dtgMain";
            dtgMain.ReadOnly = true;
            dtgMain.Size = new Size(454, 178);
            dtgMain.TabIndex = 0;
            dtgMain.RowHeaderMouseDoubleClick += dtgMain_RowHeaderMouseDoubleClick;
            // 
            // ntiMain
            // 
            ntiMain.Text = "Vrnz2 Agenda";
            ntiMain.Visible = true;
            ntiMain.MouseDoubleClick += ntiMain_MouseDoubleClick;
            // 
            // grbButtons
            // 
            grbButtons.Controls.Add(btnConfigurations);
            grbButtons.Controls.Add(btnRefresh);
            grbButtons.Controls.Add(btnAdd);
            grbButtons.Location = new Point(470, -2);
            grbButtons.Name = "grbButtons";
            grbButtons.Size = new Size(82, 205);
            grbButtons.TabIndex = 1;
            grbButtons.TabStop = false;
            // 
            // btnConfigurations
            // 
            btnConfigurations.Location = new Point(4, 174);
            btnConfigurations.Name = "btnConfigurations";
            btnConfigurations.Size = new Size(75, 23);
            btnConfigurations.TabIndex = 2;
            btnConfigurations.Text = "Config's...";
            btnConfigurations.UseVisualStyleBackColor = true;
            btnConfigurations.Click += btnConfigurations_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(4, 48);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Atualizar";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(4, 19);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Adicionar...";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(556, 207);
            Controls.Add(grbButtons);
            Controls.Add(grbMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agenda";
            WindowState = FormWindowState.Minimized;
            FormClosing += FrmMain_FormClosing;
            Shown += FrmMain_Shown;
            Resize += FrmMain_Resize;
            grbMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgMain).EndInit();
            grbButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grbMain;
        private DataGridView dtgMain;
        private NotifyIcon ntiMain;
        private GroupBox grbButtons;
        private Button btnAdd;
        private Button btnRefresh;
        private Button btnConfigurations;
    }
}
