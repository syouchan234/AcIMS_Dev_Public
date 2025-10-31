using System;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Text.Json;
using AccountInfoManager;

namespace passmanager{
    public partial class ChangePassword : Form
    {
        private const string SettingsFile = "setting.txt";
        private const string SettingsJson = "setting.json";

        // 設定値を格納する変数
        private bool firstFlag;
        private bool deletionNotificationFlag;
        private bool saveNotificationFlag;
        private bool autoSaveFlag;
        private bool timeOutFlag;
        private int timeOutMinutes;
        public ChangePassword()
        {
            InitializeComponent();
            readSettingJson();
            this.StartPosition = FormStartPosition.CenterScreen;
            //ウィンドウの最大化を禁止にする
            this.MaximizeBox = false;
            // ウィンドウのサイズを固定にする
            FormBorderStyle = FormBorderStyle.FixedSingle;
            if (isViewPasswordCheckBox.Checked) changeNewPassword.PasswordChar = '\0';
            else changeNewPassword.PasswordChar = '●';
            if (isViewConfirmPassword.Checked) confirmPasswordTextBox.PasswordChar = '\0';
            else confirmPasswordTextBox.PasswordChar = '●';
        }
        // 新しいパスワードを入力するフォームの表示可否（チェックボックス）
        private void isViewPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isViewPasswordCheckBox.Checked) changeNewPassword.PasswordChar = '\0';
            else changeNewPassword.PasswordChar = '●';
        }
        // 確認用パスワードの入力するフォームの表示可否（チェックボックス）
        private void isViewConfirmPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (isViewConfirmPassword.Checked) confirmPasswordTextBox.PasswordChar = '\0';
            else confirmPasswordTextBox.PasswordChar = '●';
        }

        // 設定ファイルのパスワードを変更するためのJSONファイルの書き込み
        public void writeSettingJson()
        {
            var settingData = new SettingData
            {
                firstFlag = false,
                settings = new Setting
                {
                    DeletionNotificationFlag = deletionNotificationFlag,
                    SaveNotificationFlag = saveNotificationFlag,
                    AutoSaveFlag = autoSaveFlag,
                    TimeOutFlag = timeOutFlag,
                    TimeOutMinutes = timeOutMinutes
                }
            };
            var options = new JsonSerializerOptions
            {
                WriteIndented = true // 見やすい整形済みJSONにする
            };
            try
            {
                string json = JsonSerializer.Serialize(settingData, options);
                File.WriteAllText(SettingsJson, json);
                readSettingJson();
            }
            catch (Exception ex)
            {
                MessageBox.Show("設定の保存中にエラーが発生しました: " + ex.Message);
            }
        }

        // 設定ファイルの読み込み
        public void readSettingJson()
        {
            string json = File.ReadAllText(SettingsJson);
            var settingData = JsonSerializer.Deserialize<SettingData>(json);
            firstFlag = settingData.firstFlag;
            deletionNotificationFlag = settingData.settings.DeletionNotificationFlag;
            saveNotificationFlag = settingData.settings.SaveNotificationFlag;
            autoSaveFlag = settingData.settings.AutoSaveFlag;
            timeOutFlag = settingData.settings.TimeOutFlag;
            timeOutMinutes = settingData.settings.TimeOutMinutes;
        }
        // 確認ボタン
        private void changePsswordBtn_Click(object sender, EventArgs e)
        {
            string npword = changeNewPassword.Text;
            string confirmword = confirmPasswordTextBox.Text;

            if (npword == "" || npword == null || confirmword == "" || confirmword == null) MessageBox.Show("入力してください");
            else
            {
                if (npword == confirmword)
                {
                    MessageBox.Show("設定しました");
                    // マスターパスワードの上書き
                    using (StreamWriter writer = new StreamWriter("setting.txt")) writer.WriteLine(npword);
                    string fileContent = File.ReadAllText(SettingsFile).Trim();
                    string masterPassword = hash(fileContent);
                    File.WriteAllText(SettingsFile, masterPassword);
                    DialogResult = DialogResult.OK;
                    writeSettingJson();
                    this.Close();
                }
                else MessageBox.Show("パスワードが一致しません");
            }
        }
        // 暗号化処理関数
        private string hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++) builder.Append(bytes[i].ToString("x2"));
                return builder.ToString();
            }
        }

        //”使い方”ラベルの制御（初回時と変更時によってリンクを変える）
        private void ManualLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //初期時
            if (firstFlag)
            {
                //マニュアルページの「初回起動時」セクションにリンクを設定
                var startInfo = new System.Diagnostics.ProcessStartInfo("https://sites.google.com/view/tanakatechpublicapplication/manual?authuser=0#h.divatkvjvqh0")
                {
                    UseShellExecute = true
                };
                _ = System.Diagnostics.Process.Start(startInfo);
            }
            else
            //変更時
            {
                //マニュアルページの「マスターパスワードの変更」セクションにリンクを設定
                var startInfo = new System.Diagnostics.ProcessStartInfo("https://sites.google.com/view/tanakatechpublicapplication/manual?authuser=0#h.3ia23nw8cldz")
                {
                    UseShellExecute = true
                };
                _ = System.Diagnostics.Process.Start(startInfo);
            }

        }
    }
}
