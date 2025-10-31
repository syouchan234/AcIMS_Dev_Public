namespace passmanager
{
    partial class CreatePassWord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatePassWord));
            createKeyWord = new System.Windows.Forms.Button();
            resultBox = new System.Windows.Forms.TextBox();
            isBigEnglishCheckBox = new System.Windows.Forms.CheckBox();
            isSmallEnglishCheckBox = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            isNumCheckBox = new System.Windows.Forms.CheckBox();
            isSymbolCheckBox = new System.Windows.Forms.CheckBox();
            createPassNum = new System.Windows.Forms.NumericUpDown();
            groupBox = new System.Windows.Forms.GroupBox();
            isViewPassword = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)createPassNum).BeginInit();
            groupBox.SuspendLayout();
            SuspendLayout();
            // 
            // createKeyWord
            // 
            createKeyWord.Location = new System.Drawing.Point(12, 14);
            createKeyWord.Name = "createKeyWord";
            createKeyWord.Size = new System.Drawing.Size(94, 50);
            createKeyWord.TabIndex = 0;
            createKeyWord.Text = "パスワードの生成";
            createKeyWord.UseVisualStyleBackColor = true;
            createKeyWord.Click += createKeyWord_Click;
            // 
            // resultBox
            // 
            resultBox.Location = new System.Drawing.Point(112, 41);
            resultBox.Name = "resultBox";
            resultBox.Size = new System.Drawing.Size(332, 23);
            resultBox.TabIndex = 4;
            // 
            // isBigEnglishCheckBox
            // 
            isBigEnglishCheckBox.AutoSize = true;
            isBigEnglishCheckBox.Location = new System.Drawing.Point(138, 2);
            isBigEnglishCheckBox.Name = "isBigEnglishCheckBox";
            isBigEnglishCheckBox.Size = new System.Drawing.Size(94, 19);
            isBigEnglishCheckBox.TabIndex = 3;
            isBigEnglishCheckBox.Text = "英字(大文字)";
            isBigEnglishCheckBox.UseVisualStyleBackColor = true;
            // 
            // isSmallEnglishCheckBox
            // 
            isSmallEnglishCheckBox.AutoSize = true;
            isSmallEnglishCheckBox.Location = new System.Drawing.Point(238, 1);
            isSmallEnglishCheckBox.Name = "isSmallEnglishCheckBox";
            isSmallEnglishCheckBox.Size = new System.Drawing.Size(94, 19);
            isSmallEnglishCheckBox.TabIndex = 3;
            isSmallEnglishCheckBox.Text = "英字(小文字)";
            isSmallEnglishCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 2);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(67, 15);
            label1.TabIndex = 2;
            label1.Text = "生成文字数";
            // 
            // isNumCheckBox
            // 
            isNumCheckBox.AutoSize = true;
            isNumCheckBox.Location = new System.Drawing.Point(338, 1);
            isNumCheckBox.Name = "isNumCheckBox";
            isNumCheckBox.Size = new System.Drawing.Size(50, 19);
            isNumCheckBox.TabIndex = 3;
            isNumCheckBox.Text = "数字";
            isNumCheckBox.UseVisualStyleBackColor = true;
            // 
            // isSymbolCheckBox
            // 
            isSymbolCheckBox.AutoSize = true;
            isSymbolCheckBox.Location = new System.Drawing.Point(394, 2);
            isSymbolCheckBox.Name = "isSymbolCheckBox";
            isSymbolCheckBox.Size = new System.Drawing.Size(50, 19);
            isSymbolCheckBox.TabIndex = 3;
            isSymbolCheckBox.Text = "記号";
            isSymbolCheckBox.UseVisualStyleBackColor = true;
            // 
            // createPassNum
            // 
            createPassNum.Location = new System.Drawing.Point(79, -3);
            createPassNum.Maximum = new decimal(new int[] { 256, 0, 0, 0 });
            createPassNum.Name = "createPassNum";
            createPassNum.Size = new System.Drawing.Size(53, 23);
            createPassNum.TabIndex = 6;
            createPassNum.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // groupBox
            // 
            groupBox.Controls.Add(createPassNum);
            groupBox.Controls.Add(isSymbolCheckBox);
            groupBox.Controls.Add(isNumCheckBox);
            groupBox.Controls.Add(label1);
            groupBox.Controls.Add(isSmallEnglishCheckBox);
            groupBox.Controls.Add(isBigEnglishCheckBox);
            groupBox.Location = new System.Drawing.Point(112, 12);
            groupBox.Name = "groupBox";
            groupBox.Size = new System.Drawing.Size(450, 24);
            groupBox.TabIndex = 5;
            groupBox.TabStop = false;
            // 
            // isViewPassword
            // 
            isViewPassword.AutoSize = true;
            isViewPassword.Location = new System.Drawing.Point(458, 43);
            isViewPassword.Name = "isViewPassword";
            isViewPassword.Size = new System.Drawing.Size(104, 19);
            isViewPassword.TabIndex = 7;
            isViewPassword.Text = "パスワードの表示";
            isViewPassword.UseVisualStyleBackColor = true;
            isViewPassword.CheckedChanged += isViewPassword_CheckedChanged;
            // 
            // CreatePassWord
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(575, 74);
            Controls.Add(isViewPassword);
            Controls.Add(groupBox);
            Controls.Add(resultBox);
            Controls.Add(createKeyWord);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "CreatePassWord";
            Text = "パスワード自動生成";
            Load += CreatePassWord_Load;
            ((System.ComponentModel.ISupportInitialize)createPassNum).EndInit();
            groupBox.ResumeLayout(false);
            groupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button createKeyWord;
        private System.Windows.Forms.CheckBox isViewPassword;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.TextBox resultBox;
        private System.Windows.Forms.CheckBox isBigEnglishCheckBox;
        private System.Windows.Forms.CheckBox isSmallEnglishCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox isNumCheckBox;
        private System.Windows.Forms.CheckBox isSymbolCheckBox;
        private System.Windows.Forms.NumericUpDown createPassNum;
        private System.Windows.Forms.GroupBox groupBox;
    }
}