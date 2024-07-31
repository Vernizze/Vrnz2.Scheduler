namespace Vrnz2.Scheduler.Forms
{
    partial class FrmConfigurations
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
            grbMain = new GroupBox();
            chkStartOnWindows = new CheckBox();
            grbButtons = new GroupBox();
            btnSave = new Button();
            grbMain.SuspendLayout();
            grbButtons.SuspendLayout();
            SuspendLayout();
            // 
            // grbMain
            // 
            grbMain.Controls.Add(chkStartOnWindows);
            grbMain.Location = new Point(2, -4);
            grbMain.Name = "grbMain";
            grbMain.Size = new Size(183, 94);
            grbMain.TabIndex = 0;
            grbMain.TabStop = false;
            // 
            // chkStartOnWindows
            // 
            chkStartOnWindows.AutoSize = true;
            chkStartOnWindows.Checked = true;
            chkStartOnWindows.CheckState = CheckState.Checked;
            chkStartOnWindows.Location = new Point(6, 20);
            chkStartOnWindows.Name = "chkStartOnWindows";
            chkStartOnWindows.Size = new Size(147, 19);
            chkStartOnWindows.TabIndex = 0;
            chkStartOnWindows.Text = "Iniciar com o Windows";
            chkStartOnWindows.UseVisualStyleBackColor = true;
            // 
            // grbButtons
            // 
            grbButtons.Controls.Add(btnSave);
            grbButtons.Location = new Point(186, -4);
            grbButtons.Name = "grbButtons";
            grbButtons.Size = new Size(85, 94);
            grbButtons.TabIndex = 1;
            grbButtons.TabStop = false;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(5, 16);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 1;
            btnSave.Text = "Salvar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // FrmConfigurations
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(275, 91);
            Controls.Add(grbButtons);
            Controls.Add(grbMain);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmConfigurations";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Configurações";
            grbMain.ResumeLayout(false);
            grbMain.PerformLayout();
            grbButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grbMain;
        private GroupBox grbButtons;
        private CheckBox chkStartOnWindows;
        private Button btnSave;
    }
}