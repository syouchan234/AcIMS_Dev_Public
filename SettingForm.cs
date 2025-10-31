using passmanager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountInfoManager
{
    public partial class SettingForm : Form
    {
        // データの保存ファイル名
        private string _AccountInfoFile = "AccountInfo.xml";
        // 設定ファイル
        private const string SettingJson = "Setting.json";
        // パスワード変更ダイアログのインスタンス
        public ChangePassword changePasswordWindow = null;
        // メインフォームのインスタンス
        private MainForm mainForm;

        // 設定値を格納する変数
        private bool deletionNotificationFlag;
        private bool saveNotificationFlag;
        private bool autoSaveFlag;
        private bool timeOutFlag;
        private int timeOutMinutes;
        public SettingForm(MainForm mainFormInstance)
        {
            InitializeComponent();
            // MainFormのインスタンスがnullの場合は例外を投げてアプリの異常動作を防止する
            mainForm = mainFormInstance ?? throw new ArgumentNullException(nameof(mainFormInstance));
            //ディスプレイの中心に配置0
            StartPosition = FormStartPosition.CenterScreen;
            // ウィンドウのサイズを固定にする
            FormBorderStyle = FormBorderStyle.FixedSingle;
            // ウィンドウの最大化を禁止にする
            this.MinimizeBox = false; // 最小化を無効にする
            this.MaximizeBox = false; // 最大化を無効にする
            // 子フォームが非アクティブになったときに、このフォームを閉じる
            this.Deactivate += SettingForm_Deactivate;
        }
        private void SettingForm_Deactivate(object sender, EventArgs e)
        {
            // フォームが閉じられていないかチェック
            if (!this.IsDisposed)
            {
                // フォームを閉じる
                this.Close();
            }
        }

        // フォームのロードイベント
        private void SettingForm_Load(object sender, EventArgs e)
        {
            ReadJson();
            SettingUI();
        }

        // json情報の読み込み
        public void ReadJson()
        {
            string json = File.ReadAllText(SettingJson);
            var settingData = JsonSerializer.Deserialize<SettingData>(json);
            deletionNotificationFlag = settingData.settings.DeletionNotificationFlag;
            saveNotificationFlag = settingData.settings.SaveNotificationFlag;
            autoSaveFlag = settingData.settings.AutoSaveFlag;
            timeOutFlag = settingData.settings.TimeOutFlag;
            timeOutMinutes = settingData.settings.TimeOutMinutes;
        }

        // jsonの保存処理
        public void SaveJson()
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
                File.WriteAllText(SettingJson, json);
                ReadJson();
            }
            catch (Exception ex)
            {
                MessageBox.Show("設定の保存中にエラーが発生しました: " + ex.Message);
            }
            // メインフォームの設定を更新
            mainForm.ReadJson();
        }

        // 設定状態のUI反映
        public void SettingUI()
        {
            DeletionNotification.Checked = deletionNotificationFlag;
            SaveNotification.Checked = saveNotificationFlag;
            AutoSave.Checked = autoSaveFlag;
            TimeOut.Checked = timeOutFlag;
            TimeOutNum.Value = timeOutMinutes;
        }

        // 削除通知のチェックボックスの変更イベント
        private void DeletionNotification_CheckedChanged(object sender, EventArgs e)
        {
            deletionNotificationFlag = DeletionNotification.Checked;
            SaveJson();
        }

        // 保存通知のチェックボックスの変更イベント
        private void SaveNotification_CheckedChanged(object sender, EventArgs e)
        {
            saveNotificationFlag = SaveNotification.Checked;
            SaveJson();
        }

        // 自動保存のチェックボックスの変更イベント
        private void AutoSave_CheckedChanged(object sender, EventArgs e)
        {
            autoSaveFlag = AutoSave.Checked;
            SaveJson();
        }

        // タイムアウトのチェックボックスの変更イベント
        private void TimeOut_CheckedChanged(object sender, EventArgs e)
        {
            timeOutFlag = TimeOut.Checked;
            SaveJson();
        }

        // タイムアウトの数値変更イベント
        private void TimeOutNum_ValueChanged(object sender, EventArgs e)
        {
            timeOutMinutes = (int)TimeOutNum.Value;
            SaveJson();
        }

        // パスワード変更ボタンのクリックイベント
        private void ChangePassword_Click(object sender, EventArgs e)
        {
            // 認証フォームの利用
            using Certification certification = new();
            // password変更フォームが開かれていない場合
            if (changePasswordWindow == null || changePasswordWindow.IsDisposed)
            {
                // 認証が通った場合
                if (certification.ShowDialog() == DialogResult.OK)
                {
                    // password変更ダイアログの表示
                    using ChangePassword changePassword = new ChangePassword();
                    if (changePassword.ShowDialog() == DialogResult.OK)
                    {
                        // パスワードが正しく変更された場合の処理を実行
                    }
                }
            }
        }

        // マニュアルリンクのクリックイベント
        private void ManualLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new System.Diagnostics.ProcessStartInfo("https://sites.google.com/view/tanakatechpublicapplication/manual?authuser=0")
            {
                UseShellExecute = true
            };
            _ = System.Diagnostics.Process.Start(startInfo);
        }

        // 設定の初期化ラベル
        private void Initializing_settings_Click(object sender, EventArgs e)
        {
            // Deactivateイベントハンドラを一時的に無効化
            this.Deactivate -= SettingForm_Deactivate;
            const bool DeletionNotificationFlag = false;
           const bool SaveNotificationFlag = true;
           const bool AutoSaveFlag = true;
           const bool TimeOutFlag = true;
           const int TimeOutMinutes = 5;
           // メッセージボックスを表示し、ユーザーの選択を取得
           DialogResult result = MessageBox.Show(
               "設定を初期化しますか？",// 表示するメッセージ
               "確認",                 // メッセージボックスのタイトル
               MessageBoxButtons.OKCancel // OKボタンとキャンセルボタンを表示
            );
            // ユーザーがOKボタンを押したかどうかの条件分岐
            if (result == DialogResult.OK)
            {
                DeletionNotification.Checked = DeletionNotificationFlag;
                SaveNotification.Checked = SaveNotificationFlag;
                AutoSave.Checked = AutoSaveFlag;
                TimeOut.Checked = TimeOutFlag;
                TimeOutNum.Value = TimeOutMinutes;
                SaveJson();
                // Deactivateイベントハンドラを再度有効化
                this.Deactivate += SettingForm_Deactivate;
            }
            else if (result == DialogResult.Cancel) 
            {
                // Deactivateイベントハンドラを再度有効化
                this.Deactivate += SettingForm_Deactivate;
                return;// メソッドを抜ける
            }
            // Deactivateイベントハンドラを再度有効化
            this.Deactivate += SettingForm_Deactivate;
        }

        // データの初期化ラベル
        private void DataInitialization_Click(object sender, EventArgs e)
        {
            // Deactivateイベントハンドラを一時的に無効化
            this.Deactivate -= SettingForm_Deactivate;
            // メッセージボックスを表示し、ユーザーの選択を取得
            DialogResult confirmation = MessageBox.Show(
                "初期化したデータは復元が出来ません。データを初期化しますか？",// 表示するメッセージ
                "データ初期化確認",// メッセージボックスのタイトル
                MessageBoxButtons.OKCancel // OKボタンとキャンセルボタンを表示
             );
            // 最初の確認でキャンセルが選択されたら、ここで処理を終了する
            if (confirmation == DialogResult.Cancel)
            {
                // Deactivateイベントハンドラを再度有効化
                this.Deactivate += SettingForm_Deactivate;
                return; // メソッドを抜ける
            }

            // 二重確認のメッセージボックスを表示
            DialogResult finalconfirmation = MessageBox.Show(
                "本当によろしいですか？",// 表示するメッセージ
                "データ初期化最終確認",// メッセージボックスのタイトル
                MessageBoxButtons.OKCancel // OKボタンとキャンセルボタンを表示
             );
            // 二重確認でキャンセルが選択されたら、ここで処理を終了する
            if (finalconfirmation == DialogResult.Cancel)
            {
                // Deactivateイベントハンドラを再度有効化
                this.Deactivate += SettingForm_Deactivate;
                return; // メソッドを抜ける
            }

            // ユーザーが両方の確認でOKボタンを押した場合にのみデータを初期化
            if (confirmation == DialogResult.OK)
            {
                if (finalconfirmation == DialogResult.OK)
                {
                    File.Delete(_AccountInfoFile);
                    // XMLファイルが存在しない場合は新規作成
                    DataTable data = new DataTable();
                    data.Columns.Add("カテゴリ");
                    data.Columns.Add("アプリ/サイト名");
                    data.Columns.Add("ID");
                    data.Columns.Add("メールアドレス");
                    data.Columns.Add("パスワード");
                    data.Columns.Add("URL");
                    data.Columns.Add("備考");
                    data.TableName = "AccountInfo";
                    data.WriteXml(_AccountInfoFile, XmlWriteMode.WriteSchema);
                    // データの初期化が完了したことをユーザーに通知
                    MessageBox.Show("データの初期化が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // メインフォームのデータを再読み込み
                    mainForm.load();
                }
            }
            // Deactivateイベントハンドラを再度有効化
            this.Deactivate += SettingForm_Deactivate;
        }
    }
}
