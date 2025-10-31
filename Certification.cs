using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using passmanager;
using System.Text.Json;

namespace AccountInfoManager
{
    public partial class Certification : Form
    {
        private string masterPassword; // マスターパスワードの格納する変数
        private const string SettingsFile = "setting.txt";
        private const string InitialPassword = "password"; // 初期パスワードの定義
        // パスワード変更フォームの多重起動禁止
        public ChangePassword changePasswordWindow = null;

        public Certification()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            // ウィンドウの最大化を禁止にする
            this.MaximizeBox = false;
            // ウィンドウのサイズを固定にする
            FormBorderStyle = FormBorderStyle.FixedSingle;
            // パスワードテキストボックスの初期設定
            passwordText.PasswordChar = '●';
            // Enter キーを押したときに confirmBtn ボタンが押されるように設定
            this.AcceptButton = confirmBtn;
            // ウィンドウの最大化を禁止にする
            this.MinimizeBox = false; // 最小化を無効にする
            this.MaximizeBox = false; // 最大化を無効にする
            // 常に手前に表示されるように設定
            this.TopMost = true;

            // setting.txt ファイルから初期パスワードを読み取る
            if (File.Exists(SettingsFile))
            {
                string fileContent = File.ReadAllText(SettingsFile).Trim();
                // ファイルの内容がハッシュ化されていない場合（つまり "password" のような平文）
                if (fileContent == InitialPassword)
                {
                    // 平文のパスワードをハッシュ化して保存し直す
                    masterPassword = hash(fileContent);
                    File.WriteAllText(SettingsFile, masterPassword);
                }
                else
                {
                    // すでにハッシュ化されている場合、そのまま使用
                    masterPassword = fileContent;
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter("setting.txt"))
                    writer.WriteLine(InitialPassword); // 初期パスワードを書き込む
                string fileContent = File.ReadAllText(SettingsFile).Trim();
                // ファイルの内容がハッシュ化されていない場合（つまり "password" のような平文）
                if (fileContent == InitialPassword)
                {
                    // 平文のパスワードをハッシュ化して保存し直す
                    masterPassword = hash(fileContent);
                    File.WriteAllText(SettingsFile, masterPassword);
                }
                else
                {
                    // すでにハッシュ化されている場合、そのまま使用
                    masterPassword = fileContent;
                }
            }
        }

        //認証処理
        private void confirmBtn_Click(object sender, EventArgs e)
        {
            // パスワードを確認するロジック
            string enteredPassword = passwordText.Text;
            // 入力された生のパスワードをハッシュ化して比較
            string hashedEnteredPassword = hash(enteredPassword);
            // 入力されたパスワードが初期パスワードと一致するかを確認
            if (hashedEnteredPassword == masterPassword){
                DialogResult = DialogResult.OK; // ログイン成功を親フォームに伝える
            }else{
                MessageBox.Show("パスワードが間違っています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //マスク化処理
        private void isViewPassword_CheckedChanged(object sender, EventArgs e)
        {
            // パスワードの可視性を切り替える
            if (isViewPassword.Checked) passwordText.PasswordChar = '\0'; // パスワードを表示
            else passwordText.PasswordChar = '●'; // パスワードをマスク
        }

        //ハッシュ関数
        private string hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                    builder.Append(bytes[i].ToString("x2"));
                return builder.ToString();
            }
        }
        //"使い方"ラベルのリンク付け
        private void ManualLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new System.Diagnostics.ProcessStartInfo("https://sites.google.com/view/tanakatechpublicapplication/home/manual?authuser=0#h.gil10toel5ft");
            startInfo.UseShellExecute = true;
            System.Diagnostics.Process.Start(startInfo);
        }
    }
}
