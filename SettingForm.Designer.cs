namespace AccountInfoManager
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            DeletionNotification = new System.Windows.Forms.CheckBox();
            AutoSave = new System.Windows.Forms.CheckBox();
            TimeOut = new System.Windows.Forms.CheckBox();
            SaveNotification = new System.Windows.Forms.CheckBox();
            TimeOutNum = new System.Windows.Forms.NumericUpDown();
            label1 = new System.Windows.Forms.Label();
            ChangePassword = new System.Windows.Forms.Button();
            DataInitialization = new System.Windows.Forms.Label();
            ManualLink = new System.Windows.Forms.LinkLabel();
            Initializing_settings = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)TimeOutNum).BeginInit();
            SuspendLayout();
            // 
            // DeletionNotification
            // 
            DeletionNotification.AutoSize = true;
            DeletionNotification.Location = new System.Drawing.Point(12, 12);
            DeletionNotification.Name = "DeletionNotification";
            DeletionNotification.Size = new System.Drawing.Size(144, 19);
            DeletionNotification.TabIndex = 0;
            DeletionNotification.Text = "項目削除時の確認通知";
            DeletionNotification.UseVisualStyleBackColor = true;
            DeletionNotification.CheckedChanged += DeletionNotification_CheckedChanged;
            // 
            // AutoSave
            // 
            AutoSave.AutoSize = true;
            AutoSave.Location = new System.Drawing.Point(12, 62);
            AutoSave.Name = "AutoSave";
            AutoSave.Size = new System.Drawing.Size(102, 19);
            AutoSave.TabIndex = 1;
            AutoSave.Text = "オートセーブ機能";
            AutoSave.UseVisualStyleBackColor = true;
            AutoSave.CheckedChanged += AutoSave_CheckedChanged;
            // 
            // TimeOut
            // 
            TimeOut.AutoSize = true;
            TimeOut.Location = new System.Drawing.Point(12, 87);
            TimeOut.Name = "TimeOut";
            TimeOut.Size = new System.Drawing.Size(103, 19);
            TimeOut.TabIndex = 2;
            TimeOut.Text = "タイムアウト機能";
            TimeOut.UseVisualStyleBackColor = true;
            TimeOut.CheckedChanged += TimeOut_CheckedChanged;
            // 
            // SaveNotification
            // 
            SaveNotification.AutoSize = true;
            SaveNotification.Location = new System.Drawing.Point(12, 37);
            SaveNotification.Name = "SaveNotification";
            SaveNotification.Size = new System.Drawing.Size(120, 19);
            SaveNotification.TabIndex = 4;
            SaveNotification.Text = "保存時の確認通知";
            SaveNotification.UseVisualStyleBackColor = true;
            SaveNotification.CheckedChanged += SaveNotification_CheckedChanged;
            // 
            // TimeOutNum
            // 
            TimeOutNum.Location = new System.Drawing.Point(12, 114);
            TimeOutNum.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            TimeOutNum.Name = "TimeOutNum";
            TimeOutNum.Size = new System.Drawing.Size(37, 23);
            TimeOutNum.TabIndex = 5;
            TimeOutNum.Value = new decimal(new int[] { 5, 0, 0, 0 });
            TimeOutNum.ValueChanged += TimeOutNum_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(55, 116);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(120, 15);
            label1.TabIndex = 6;
            label1.Text = "分後にタイムアウトします";
            // 
            // ChangePassword
            // 
            ChangePassword.Location = new System.Drawing.Point(12, 143);
            ChangePassword.Name = "ChangePassword";
            ChangePassword.Size = new System.Drawing.Size(170, 37);
            ChangePassword.TabIndex = 7;
            ChangePassword.Text = "マスターパスワード変更";
            ChangePassword.UseVisualStyleBackColor = true;
            ChangePassword.Click += ChangePassword_Click;
            // 
            // DataInitialization
            // 
            DataInitialization.AutoSize = true;
            DataInitialization.ForeColor = System.Drawing.Color.Red;
            DataInitialization.Location = new System.Drawing.Point(55, 242);
            DataInitialization.Name = "DataInitialization";
            DataInitialization.Size = new System.Drawing.Size(79, 15);
            DataInitialization.TabIndex = 8;
            DataInitialization.Text = "データの初期化";
            DataInitialization.Click += DataInitialization_Click;
            // 
            // ManualLink
            // 
            ManualLink.AutoSize = true;
            ManualLink.Location = new System.Drawing.Point(74, 186);
            ManualLink.Name = "ManualLink";
            ManualLink.Size = new System.Drawing.Size(41, 15);
            ManualLink.TabIndex = 15;
            ManualLink.TabStop = true;
            ManualLink.Text = "使い方";
            ManualLink.VisitedLinkColor = System.Drawing.Color.Blue;
            ManualLink.LinkClicked += ManualLink_LinkClicked;
            // 
            // Initializing_settings
            // 
            Initializing_settings.AutoSize = true;
            Initializing_settings.ForeColor = System.Drawing.Color.Red;
            Initializing_settings.Location = new System.Drawing.Point(55, 218);
            Initializing_settings.Name = "Initializing_settings";
            Initializing_settings.Size = new System.Drawing.Size(77, 15);
            Initializing_settings.TabIndex = 17;
            Initializing_settings.Text = "設定の初期化";
            Initializing_settings.Click += Initializing_settings_Click;
            // 
            // SettingForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(194, 266);
            Controls.Add(Initializing_settings);
            Controls.Add(ManualLink);
            Controls.Add(DataInitialization);
            Controls.Add(ChangePassword);
            Controls.Add(label1);
            Controls.Add(TimeOutNum);
            Controls.Add(SaveNotification);
            Controls.Add(TimeOut);
            Controls.Add(AutoSave);
            Controls.Add(DeletionNotification);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "SettingForm";
            Text = "設定";
            Load += SettingForm_Load;
            ((System.ComponentModel.ISupportInitialize)TimeOutNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox DeletionNotification;
        private System.Windows.Forms.CheckBox AutoSave;
        private System.Windows.Forms.CheckBox TimeOut;
        private System.Windows.Forms.CheckBox SaveNotification;
        private System.Windows.Forms.NumericUpDown TimeOutNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ChangePassword;
        private System.Windows.Forms.Label DataInitialization;
        private System.Windows.Forms.LinkLabel ManualLink;
        private System.Windows.Forms.Label Initializing_settings;
    }
}