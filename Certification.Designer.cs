namespace AccountInfoManager
{
    partial class Certification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Certification));
            passwordText = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            confirmBtn = new System.Windows.Forms.Button();
            isViewPassword = new System.Windows.Forms.CheckBox();
            ManualLink = new System.Windows.Forms.LinkLabel();
            SuspendLayout();
            // 
            // passwordText
            // 
            passwordText.Location = new System.Drawing.Point(12, 42);
            passwordText.Name = "passwordText";
            passwordText.Size = new System.Drawing.Size(314, 23);
            passwordText.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(305, 30);
            label1.TabIndex = 1;
            label1.Text = "マスターパスワードを入力してください";
            // 
            // confirmBtn
            // 
            confirmBtn.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 18F);
            confirmBtn.Location = new System.Drawing.Point(12, 96);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.Size = new System.Drawing.Size(314, 44);
            confirmBtn.TabIndex = 2;
            confirmBtn.Text = "確認";
            confirmBtn.UseVisualStyleBackColor = true;
            confirmBtn.Click += confirmBtn_Click;
            // 
            // isViewPassword
            // 
            isViewPassword.AutoSize = true;
            isViewPassword.Location = new System.Drawing.Point(12, 71);
            isViewPassword.Name = "isViewPassword";
            isViewPassword.Size = new System.Drawing.Size(103, 19);
            isViewPassword.TabIndex = 3;
            isViewPassword.Text = "パスワードを表示";
            isViewPassword.UseVisualStyleBackColor = true;
            isViewPassword.CheckedChanged += isViewPassword_CheckedChanged;
            // 
            // ManualLink
            // 
            ManualLink.AutoSize = true;
            ManualLink.Location = new System.Drawing.Point(276, 72);
            ManualLink.Name = "ManualLink";
            ManualLink.Size = new System.Drawing.Size(41, 15);
            ManualLink.TabIndex = 4;
            ManualLink.TabStop = true;
            ManualLink.Text = "使い方";
            ManualLink.VisitedLinkColor = System.Drawing.Color.Blue;
            ManualLink.LinkClicked += ManualLink_LinkClicked;
            // 
            // Certification
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(338, 152);
            Controls.Add(ManualLink);
            Controls.Add(isViewPassword);
            Controls.Add(confirmBtn);
            Controls.Add(label1);
            Controls.Add(passwordText);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "Certification";
            Text = "認証";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.CheckBox isViewPassword;
        private System.Windows.Forms.LinkLabel ManualLink;
    }
}