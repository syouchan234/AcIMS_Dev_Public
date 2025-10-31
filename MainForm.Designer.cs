namespace passmanager
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            label1 = new System.Windows.Forms.Label();
            dataGrid = new System.Windows.Forms.DataGridView();
            Category = new System.Windows.Forms.ComboBox();
            IDClip = new System.Windows.Forms.Button();
            PassClip = new System.Windows.Forms.Button();
            EditMode = new System.Windows.Forms.Button();
            SaveButton = new System.Windows.Forms.Button();
            MailClip = new System.Windows.Forms.Button();
            URLButton = new System.Windows.Forms.Button();
            createPassWordBtn = new System.Windows.Forms.Button();
            Browser = new System.Windows.Forms.Button();
            DeleteButton = new System.Windows.Forms.Button();
            SettingButton = new System.Windows.Forms.Button();
            reload = new System.Windows.Forms.Button();
            searchTextBox = new System.Windows.Forms.TextBox();
            searchBtn = new System.Windows.Forms.Button();
            viewPassword = new System.Windows.Forms.CheckBox();
            ManualLink = new System.Windows.Forms.LinkLabel();
            currentViewPasswordCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(23, 399);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "カテゴリ";
            // 
            // dataGrid
            // 
            dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.Location = new System.Drawing.Point(12, 28);
            dataGrid.Name = "dataGrid";
            dataGrid.Size = new System.Drawing.Size(776, 360);
            dataGrid.TabIndex = 1;
            dataGrid.Text = "dataGridView1";
            // 
            // Category
            // 
            Category.FormattingEnabled = true;
            Category.Location = new System.Drawing.Point(75, 394);
            Category.Name = "Category";
            Category.Size = new System.Drawing.Size(180, 23);
            Category.TabIndex = 2;
            Category.SelectedIndexChanged += Category_SelectedIndexChanged;
            // 
            // IDClip
            // 
            IDClip.Location = new System.Drawing.Point(261, 395);
            IDClip.Name = "IDClip";
            IDClip.Size = new System.Drawing.Size(100, 24);
            IDClip.TabIndex = 3;
            IDClip.Text = "ID取得";
            IDClip.UseVisualStyleBackColor = true;
            IDClip.Click += IDClip_Click;
            // 
            // PassClip
            // 
            PassClip.Location = new System.Drawing.Point(261, 424);
            PassClip.Name = "PassClip";
            PassClip.Size = new System.Drawing.Size(100, 24);
            PassClip.TabIndex = 3;
            PassClip.Text = "パスワード取得";
            PassClip.UseVisualStyleBackColor = true;
            PassClip.Click += PassClip_Click;
            // 
            // EditMode
            // 
            EditMode.Location = new System.Drawing.Point(644, 395);
            EditMode.Name = "EditMode";
            EditMode.Size = new System.Drawing.Size(60, 24);
            EditMode.TabIndex = 3;
            EditMode.Text = "編集";
            EditMode.UseVisualStyleBackColor = true;
            EditMode.Click += EditMode_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new System.Drawing.Point(710, 395);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new System.Drawing.Size(60, 23);
            SaveButton.TabIndex = 3;
            SaveButton.Text = "保存";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // MailClip
            // 
            MailClip.Location = new System.Drawing.Point(367, 395);
            MailClip.Name = "MailClip";
            MailClip.Size = new System.Drawing.Size(100, 24);
            MailClip.TabIndex = 4;
            MailClip.Text = "メールアドレス取得";
            MailClip.UseVisualStyleBackColor = true;
            MailClip.Click += MailClip_Click;
            // 
            // URLButton
            // 
            URLButton.Location = new System.Drawing.Point(367, 424);
            URLButton.Name = "URLButton";
            URLButton.Size = new System.Drawing.Size(100, 24);
            URLButton.TabIndex = 5;
            URLButton.Text = "URL取得";
            URLButton.UseVisualStyleBackColor = true;
            URLButton.Click += URLButton_Click;
            // 
            // createPassWordBtn
            // 
            createPassWordBtn.Location = new System.Drawing.Point(473, 424);
            createPassWordBtn.Name = "createPassWordBtn";
            createPassWordBtn.Size = new System.Drawing.Size(99, 23);
            createPassWordBtn.TabIndex = 6;
            createPassWordBtn.Text = "パスワード生成";
            createPassWordBtn.UseVisualStyleBackColor = true;
            createPassWordBtn.Click += createPassWordBtn_Click;
            // 
            // Browser
            // 
            Browser.Location = new System.Drawing.Point(473, 395);
            Browser.Name = "Browser";
            Browser.Size = new System.Drawing.Size(99, 24);
            Browser.TabIndex = 7;
            Browser.Text = "ブラウザ起動";
            Browser.UseVisualStyleBackColor = true;
            Browser.Click += Browser_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.BackColor = System.Drawing.SystemColors.Window;
            DeleteButton.Location = new System.Drawing.Point(578, 395);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new System.Drawing.Size(60, 24);
            DeleteButton.TabIndex = 8;
            DeleteButton.Text = "削除";
            DeleteButton.UseVisualStyleBackColor = false;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // SettingButton
            // 
            SettingButton.Location = new System.Drawing.Point(578, 423);
            SettingButton.Name = "SettingButton";
            SettingButton.Size = new System.Drawing.Size(126, 24);
            SettingButton.TabIndex = 9;
            SettingButton.Text = "設定";
            SettingButton.UseVisualStyleBackColor = true;
            SettingButton.Click += SettingButton_Click;
            // 
            // reload
            // 
            reload.Location = new System.Drawing.Point(710, 423);
            reload.Name = "reload";
            reload.Size = new System.Drawing.Size(60, 23);
            reload.TabIndex = 10;
            reload.Text = "更新";
            reload.UseVisualStyleBackColor = true;
            reload.Click += reload_Click;
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new System.Drawing.Point(75, 425);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new System.Drawing.Size(180, 23);
            searchTextBox.TabIndex = 11;
            searchTextBox.KeyDown += searchTextBox_KeyDown;
            // 
            // searchBtn
            // 
            searchBtn.Location = new System.Drawing.Point(23, 424);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new System.Drawing.Size(42, 24);
            searchBtn.TabIndex = 12;
            searchBtn.Text = "検索";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // viewPassword
            // 
            viewPassword.AutoSize = true;
            viewPassword.Location = new System.Drawing.Point(59, 6);
            viewPassword.Name = "viewPassword";
            viewPassword.Size = new System.Drawing.Size(134, 19);
            viewPassword.TabIndex = 13;
            viewPassword.Text = "全てのパスワードを表示";
            viewPassword.UseVisualStyleBackColor = true;
            viewPassword.CheckedChanged += viewPassword_CheckedChanged;
            // 
            // ManualLink
            // 
            ManualLink.AutoSize = true;
            ManualLink.Location = new System.Drawing.Point(12, 7);
            ManualLink.Name = "ManualLink";
            ManualLink.Size = new System.Drawing.Size(41, 15);
            ManualLink.TabIndex = 14;
            ManualLink.TabStop = true;
            ManualLink.Text = "使い方";
            ManualLink.LinkClicked += ManualLink_LinkClicked;
            // 
            // currentViewPasswordCheckBox
            // 
            currentViewPasswordCheckBox.AutoSize = true;
            currentViewPasswordCheckBox.Location = new System.Drawing.Point(199, 6);
            currentViewPasswordCheckBox.Name = "currentViewPasswordCheckBox";
            currentViewPasswordCheckBox.Size = new System.Drawing.Size(104, 19);
            currentViewPasswordCheckBox.TabIndex = 15;
            currentViewPasswordCheckBox.Text = "パスワードの表示";
            currentViewPasswordCheckBox.UseVisualStyleBackColor = true;
            currentViewPasswordCheckBox.CheckedChanged += currentViewPasswordCheckBox_CheckedChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ActiveCaption;
            ClientSize = new System.Drawing.Size(800, 464);
            Controls.Add(currentViewPasswordCheckBox);
            Controls.Add(ManualLink);
            Controls.Add(viewPassword);
            Controls.Add(searchBtn);
            Controls.Add(searchTextBox);
            Controls.Add(reload);
            Controls.Add(SettingButton);
            Controls.Add(DeleteButton);
            Controls.Add(Browser);
            Controls.Add(createPassWordBtn);
            Controls.Add(URLButton);
            Controls.Add(MailClip);
            Controls.Add(SaveButton);
            Controls.Add(EditMode);
            Controls.Add(PassClip);
            Controls.Add(IDClip);
            Controls.Add(Category);
            Controls.Add(dataGrid);
            Controls.Add(label1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "AcIMS";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.ComboBox Category;
        private System.Windows.Forms.Button IDClip;
        private System.Windows.Forms.Button PassClip;
        private System.Windows.Forms.Button EditMode;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button MailClip;
        private System.Windows.Forms.Button URLButton;
        private System.Windows.Forms.Button createPassWordBtn;
        private System.Windows.Forms.Button Browser;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button encryption;
        private System.Windows.Forms.Button reload;
        private System.Windows.Forms.Button SettingButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.CheckBox viewPassword;
        private System.Windows.Forms.LinkLabel ManualLink;
        private System.Windows.Forms.CheckBox currentViewPasswordCheckBox;
    }
}

