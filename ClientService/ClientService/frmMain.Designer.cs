
namespace ClientService
{
    partial class frmMain
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
            this.nameLabel = new DevExpress.XtraEditors.LabelControl();
            this.dateLabel = new DevExpress.XtraEditors.LabelControl();
            this.roleLabel = new DevExpress.XtraEditors.LabelControl();
            this.webActivityButton = new DevExpress.XtraEditors.SimpleButton();
            this.workingTimeButton = new DevExpress.XtraEditors.SimpleButton();
            this.speechRecognitionButton = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.settingsButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.Appearance.Options.UseFont = true;
            this.nameLabel.Appearance.Options.UseTextOptions = true;
            this.nameLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nameLabel.Location = new System.Drawing.Point(12, 12);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(95, 25);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "NameLabel";
            // 
            // dateLabel
            // 
            this.dateLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateLabel.Appearance.Options.UseFont = true;
            this.dateLabel.Appearance.Options.UseTextOptions = true;
            this.dateLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dateLabel.Location = new System.Drawing.Point(12, 74);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(84, 25);
            this.dateLabel.TabIndex = 1;
            this.dateLabel.Text = "DateLabel";
            // 
            // roleLabel
            // 
            this.roleLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.roleLabel.Appearance.Options.UseFont = true;
            this.roleLabel.Appearance.Options.UseTextOptions = true;
            this.roleLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.roleLabel.Location = new System.Drawing.Point(12, 43);
            this.roleLabel.Name = "roleLabel";
            this.roleLabel.Size = new System.Drawing.Size(82, 25);
            this.roleLabel.TabIndex = 2;
            this.roleLabel.Text = "RoleLabel";
            // 
            // webActivityButton
            // 
            this.webActivityButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.webActivityButton.Appearance.Options.UseFont = true;
            this.webActivityButton.Location = new System.Drawing.Point(36, 27);
            this.webActivityButton.Name = "webActivityButton";
            this.webActivityButton.Size = new System.Drawing.Size(136, 34);
            this.webActivityButton.TabIndex = 3;
            this.webActivityButton.Text = "Веб активность";
            this.webActivityButton.Click += new System.EventHandler(this.webActivityButton_Click);
            // 
            // workingTimeButton
            // 
            this.workingTimeButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.workingTimeButton.Appearance.Options.UseFont = true;
            this.workingTimeButton.Location = new System.Drawing.Point(36, 79);
            this.workingTimeButton.Name = "workingTimeButton";
            this.workingTimeButton.Size = new System.Drawing.Size(136, 33);
            this.workingTimeButton.TabIndex = 4;
            this.workingTimeButton.Text = "Рабочее время";
            this.workingTimeButton.Click += new System.EventHandler(this.workingTimeButton_Click);
            // 
            // speechRecognitionButton
            // 
            this.speechRecognitionButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.speechRecognitionButton.Appearance.Options.UseFont = true;
            this.speechRecognitionButton.Location = new System.Drawing.Point(36, 131);
            this.speechRecognitionButton.Name = "speechRecognitionButton";
            this.speechRecognitionButton.Size = new System.Drawing.Size(136, 33);
            this.speechRecognitionButton.TabIndex = 5;
            this.speechRecognitionButton.Text = "Анализ речи";
            this.speechRecognitionButton.Click += new System.EventHandler(this.speechRecognitionButton_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(31, 104);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(136, 33);
            this.simpleButton2.TabIndex = 7;
            this.simpleButton2.Text = "Рабочее время";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.Location = new System.Drawing.Point(31, 53);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(136, 34);
            this.simpleButton3.TabIndex = 6;
            this.simpleButton3.Text = "Веб активность";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.webActivityButton);
            this.groupControl1.Controls.Add(this.workingTimeButton);
            this.groupControl1.Controls.Add(this.speechRecognitionButton);
            this.groupControl1.Location = new System.Drawing.Point(546, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(200, 183);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "Сотрудники";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.simpleButton3);
            this.groupControl2.Controls.Add(this.simpleButton2);
            this.groupControl2.Location = new System.Drawing.Point(340, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(200, 183);
            this.groupControl2.TabIndex = 10;
            this.groupControl2.Text = "Личное";
            // 
            // separatorControl1
            // 
            this.separatorControl1.LineColor = System.Drawing.Color.Black;
            this.separatorControl1.LineOrientation = System.Windows.Forms.Orientation.Vertical;
            this.separatorControl1.Location = new System.Drawing.Point(259, 12);
            this.separatorControl1.LookAndFeel.SkinName = "Office 2019 Colorful";
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(75, 337);
            this.separatorControl1.TabIndex = 11;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.settingsButton);
            this.groupControl3.Location = new System.Drawing.Point(433, 201);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(200, 100);
            this.groupControl3.TabIndex = 12;
            this.groupControl3.Text = "Прочее";
            // 
            // settingsButton
            // 
            this.settingsButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settingsButton.Appearance.Options.UseFont = true;
            this.settingsButton.Location = new System.Drawing.Point(34, 39);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(136, 33);
            this.settingsButton.TabIndex = 13;
            this.settingsButton.Text = "Настройки";
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 361);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.separatorControl1);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.roleLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Панель мониторинга";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl nameLabel;
        private DevExpress.XtraEditors.LabelControl dateLabel;
        private DevExpress.XtraEditors.LabelControl roleLabel;
        private DevExpress.XtraEditors.SimpleButton webActivityButton;
        private DevExpress.XtraEditors.SimpleButton workingTimeButton;
        private DevExpress.XtraEditors.SimpleButton speechRecognitionButton;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton settingsButton;
    }
}