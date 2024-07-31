namespace Vrnz2.Scheduler.Forms
{
    partial class FrmEventNotification
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
            groupBox1 = new GroupBox();
            rtbEventNotification = new RichTextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rtbEventNotification);
            groupBox1.Location = new Point(2, -4);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(268, 92);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // rtbEventNotification
            // 
            rtbEventNotification.BackColor = Color.LemonChiffon;
            rtbEventNotification.Location = new Point(6, 16);
            rtbEventNotification.Name = "rtbEventNotification";
            rtbEventNotification.ReadOnly = true;
            rtbEventNotification.Size = new Size(256, 67);
            rtbEventNotification.TabIndex = 0;
            rtbEventNotification.Text = "";
            rtbEventNotification.WordWrap = false;
            // 
            // FrmEventNotification
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(275, 91);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmEventNotification";
            ShowInTaskbar = false;
            Text = "Evento";
            TopMost = true;
            Shown += FrmEventNotification_Shown;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private RichTextBox rtbEventNotification;
    }
}