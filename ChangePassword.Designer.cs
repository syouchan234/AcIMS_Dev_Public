namespace passmanager
{
    partial class ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            changePsswordBtn = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            changeNewPassword = new System.Windows.Forms.TextBox();
            isViewPasswordCheckBox = new System.Windows.Forms.CheckBox();
            confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            isViewConfirmPassword = new System.Windows.Forms.CheckBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            ManualLink = new System.Windows.Forms.LinkLabel();
            SuspendLayout();
            // 
            // changePsswordBtn
            // 
            changePsswordBtn.Location = new System.Drawing.Point(11, 208);
            changePsswordBtn.Name = "changePsswordBtn";
            changePsswordBtn.Size = new System.Drawing.Size(297, 26);
            changePsswordBtn.TabIndex = 2;
            changePsswordBtn.Text = "確認";
            changePsswordBtn.UseVisualStyleBackColor = true;
            changePsswordBtn.Click += changePsswordBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(12, 57);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(243, 20);
            label1.TabIndex = 4;
            label1.Text = "新しいパスワードを入力してください";
            // 
            // changeNewPassword
            // 
            changeNewPassword.Location = new System.Drawing.Point(11, 80);
            changeNewPassword.Name = "changeNewPassword";
            changeNewPassword.Size = new System.Drawing.Size(297, 23);
            changeNewPassword.TabIndex = 5;
            // 
            // isViewPasswordCheckBox
            // 
            isViewPasswordCheckBox.AutoSize = true;
            isViewPasswordCheckBox.Location = new System.Drawing.Point(12, 109);
            isViewPasswordCheckBox.Name = "isViewPasswordCheckBox";
            isViewPasswordCheckBox.Size = new System.Drawing.Size(122, 19);
            isViewPasswordCheckBox.TabIndex = 7;
            isViewPasswordCheckBox.Text = "パスワードを表示する";
            isViewPasswordCheckBox.UseVisualStyleBackColor = true;
            isViewPasswordCheckBox.CheckedChanged += isViewPasswordCheckBox_CheckedChanged;
            // 
            // confirmPasswordTextBox
            // 
            confirmPasswordTextBox.Location = new System.Drawing.Point(11, 154);
            confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            confirmPasswordTextBox.Size = new System.Drawing.Size(297, 23);
            confirmPasswordTextBox.TabIndex = 8;
            // 
            // isViewConfirmPassword
            // 
            isViewConfirmPassword.AutoSize = true;
            isViewConfirmPassword.Location = new System.Drawing.Point(12, 183);
            isViewConfirmPassword.Name = "isViewConfirmPassword";
            isViewConfirmPassword.Size = new System.Drawing.Size(122, 19);
            isViewConfirmPassword.TabIndex = 9;
            isViewConfirmPassword.Text = "パスワードを表示する";
            isViewConfirmPassword.UseVisualStyleBackColor = true;
            isViewConfirmPassword.CheckedChanged += isViewConfirmPassword_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(11, 131);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(229, 20);
            label2.TabIndex = 10;
            label2.Text = "もう一度入力してください（確認）";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = System.Drawing.Color.Red;
            label3.Location = new System.Drawing.Point(11, 4);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(43, 15);
            label3.TabIndex = 11;
            label3.Text = "注意！";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F);
            label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label4.Location = new System.Drawing.Point(12, 19);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(300, 13);
            label4.TabIndex = 12;
            label4.Text = "起動時に必要なマスターパスワードなので絶対に忘れないでください！";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F);
            label5.Location = new System.Drawing.Point(12, 32);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(157, 13);
            label5.TabIndex = 13;
            label5.Text = "※忘れた場合データが失われます。";
            // 
            // ManualLink
            // 
            ManualLink.AutoSize = true;
            ManualLink.Location = new System.Drawing.Point(267, 187);
            ManualLink.Name = "ManualLink";
            ManualLink.Size = new System.Drawing.Size(41, 15);
            ManualLink.TabIndex = 14;
            ManualLink.TabStop = true;
            ManualLink.Text = "使い方";
            ManualLink.VisitedLinkColor = System.Drawing.Color.Blue;
            ManualLink.LinkClicked += ManualLink_LinkClicked;
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(320, 249);
            Controls.Add(ManualLink);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(isViewConfirmPassword);
            Controls.Add(confirmPasswordTextBox);
            Controls.Add(isViewPasswordCheckBox);
            Controls.Add(changeNewPassword);
            Controls.Add(label1);
            Controls.Add(changePsswordBtn);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "ChangePassword";
            Text = "マスターパスワードの変更";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button changePsswordBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox changeNewPassword;
        private System.Windows.Forms.CheckBox isViewPasswordCheckBox;
        private System.Windows.Forms.TextBox confirmPasswordTextBox;
        private System.Windows.Forms.CheckBox isViewConfirmPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel ManualLink;
    }
}