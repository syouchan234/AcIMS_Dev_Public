using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;
using AccountInfoManager;

namespace passmanager
{
    static class Program
    {
        private const string SettingsFile = "setting.txt";
        private const string SettingJson = "setting.json";
        private const string EncryptedFile = "AccountInfo.xml_ciphered.bin";

        [STAThread]
        static void Main()
        {
            using Mutex mutex = new(false, "passmanagerMutex");
            if (!mutex.WaitOne(0, false))
            {
                MessageBox.Show("アプリケーションはすでに起動しています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool firstFlag = ReadSettingJson(); // setting.json から firstFlag を取得
            bool isSettingFileEmpty = IsSettingFileEmpty();// 設定ファイルの空チェック
            bool encryptedFileExists = File.Exists(EncryptedFile);// 暗号化されたファイルの存在チェック

            // 厳密な初回起動の定義：
            // すべての重要ファイルが未作成、かつフラグが true
            bool isTrulyFirstLaunch = firstFlag && isSettingFileEmpty && !encryptedFileExists;

            if (isTrulyFirstLaunch)
            {
                using MainForm mainForm = new();
                using ChangePassword changePassword = new();
                if (changePassword.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(mainForm);
                }
            }
            else if (!firstFlag && !isSettingFileEmpty && encryptedFileExists)
            {
                using Certification certification = new();
                if (certification.ShowDialog() == DialogResult.OK)
                {
                    string fileContent = File.ReadAllText(SettingsFile).Trim();
                    MainForm.cryptRun("decrypt", fileContent);
                    using MainForm mainForm = new();
                    Application.Run(mainForm);
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("設定ファイルまたは暗号ファイルに矛盾が検出されました。不正な初期化の可能性があります。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        // setting.json から firstFlag を取得
        public static bool ReadSettingJson()
        {
            try
            {
                string jsonContent = File.ReadAllText(SettingJson);
                JsonDocument jsonDocument = JsonDocument.Parse(jsonContent);
                return jsonDocument.RootElement.GetProperty("firstFlag").GetBoolean();
            }
            catch
            {
                return false; // 読み込み失敗は安全のため false 扱い
            }
        }

        // setting.txt が空かどうか
        public static bool IsSettingFileEmpty()
        {
            try
            {
                if (!File.Exists(SettingsFile)) return true;

                string content = File.ReadAllText(SettingsFile).Trim();
                return string.IsNullOrEmpty(content);
            }
            catch
            {
                return true; // 読み取りエラーも空扱いで安全に倒す
            }
        }
    }
}
