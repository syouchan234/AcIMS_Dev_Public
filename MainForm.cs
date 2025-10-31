using System;
using System.Data;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using AccountInfoManager;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

namespace passmanager
{
    public partial class MainForm : Form
    {
        // データの保存ファイル名
        private string _AccountInfoFile = "AccountInfo.xml";
        // 暗号化ファイル
        private string EncAcFile = "AccountInfo.xml_ciphered";
        // マスターキーのハッシュ値を格納するファイル
        private const string SettingsFile = "setting.txt";
        // 設定ファイル
        private const string SettingJson = "Setting.json";

        // ウィンドウの多重起動禁止
        public CreatePassWord createPasswordWindow = null;
        public ChangePassword changePasswordWindow = null;
        public SettingForm settingForm = null;

        // 設定値を格納する変数
        private bool deletionNotificationFlag;
        private bool saveNotificationFlag;
        private bool autoSaveFlag;
        private bool timeOutFlag;
        private int timeOutMinutes;

        // タイマーの設定
        private Timer inactivityTimer;
        private DateTime lastActivityTime;

        // 画面に配置するコントロールの登録と初期化
        public MainForm()
        {
            // 画面に置かれたコントロール類に初期値を設定し、画面を描画する関数
            InitializeComponent();
            // プログラムをディスプレイの真ん中に表示
            StartPosition = FormStartPosition.CenterScreen;
            // フォームが閉じられる直前に呼び出されるイベント
            FormClosing += MainForm_FormClosing;
            // 設定情報の読み込み
            ReadJson();
        }

        // 設定情報の読み込み
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

        // アプリケーション終了時に呼び出される関数
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string fileContent = File.ReadAllText(SettingsFile).Trim();
            cryptRun("encrypt", fileContent);
            if (File.Exists(_AccountInfoFile)) File.Delete(_AccountInfoFile);
        }

        // 暗号化と復号化を識別する関数
        public static int cryptRun(string mode, string password)
        {
            string inputFilePath = "AccountInfo.xml";
            string outputFilePath = "AccountInfo.xml_ciphered.bin";
            string keyText = GenerateKeyFromPassword(password);
            byte[] key = Encoding.UTF8.GetBytes(keyText);
            if (mode == "encrypt") MyEncryptFile(inputFilePath, outputFilePath, key);
            else if (mode == "decrypt") MyDecryptFile(outputFilePath, inputFilePath, key);
            else return -1;
            return 0;
        }

        // 暗号化関数
        public static int MyEncryptFile(string inputFilePath, string outputFilePath, byte[] key)
        {
            try
            {
                using Aes aes = Aes.Create();
                // IVの生成と保存
                aes.GenerateIV();
                using ICryptoTransform encryptor = aes.CreateEncryptor(key, aes.IV);
                using FileStream inStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read);
                using FileStream outStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write);
                outStream.Write(aes.IV, 0, aes.IV.Length);
                using CryptoStream cs = new CryptoStream(outStream, encryptor, CryptoStreamMode.Write);
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = inStream.Read(buffer, 0, buffer.Length)) > 0) cs.Write(buffer, 0, bytesRead);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"暗号化に失敗しました: {ex.Message}");
                return -1;
            }
            return 0;
        }

        // 復号化関数
        public static int MyDecryptFile(string inputFilePath, string outputFilePath, byte[] key)
        {
            try
            {
                using Aes aes = Aes.Create();
                using FileStream inStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read);
                byte[] iv = new byte[aes.BlockSize / 8];
                inStream.Read(iv, 0, iv.Length);
                using ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);
                using FileStream outStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write);
                using CryptoStream cs = new CryptoStream(inStream, decryptor, CryptoStreamMode.Read);
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = cs.Read(buffer, 0, buffer.Length)) > 0) outStream.Write(buffer, 0, bytesRead);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"復号化に失敗しました: {ex.Message}");
                return -1;
            }
            return 0;
        }

        // パスワードをキーに３２文字のランダム文字列を出力する
        public static string GenerateKeyFromPassword(string password)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            // 32バイトのハッシュをBase64文字列に変換
            return Convert.ToBase64String(hashBytes).Substring(0, 32);
        }

        // 画面表示時の初期化処理
        private void MainForm_Load(object sender, EventArgs e)
        {
            load();
            // 削除ボタンの押下を無効化
            DeleteButton.Enabled = false;
            DeleteButton.BackColor = SystemColors.Control;
        }

        // 更新ボタン
        private void reload_Click(object sender, EventArgs e) { load(); }

        // フォームの読み込み
        public void load()
        {
            // 設定情報の読み込み
            ReadJson();
            // ウィンドウのサイズを固定にする
            FormBorderStyle = FormBorderStyle.FixedSingle;
            // ウィンドウの最大化を禁止にする
            MaximizeBox = false;
            // パスワードを非表示にする
            viewPassword.Checked = false;
            DataTable data = new DataTable();
            data.Columns.Add("カテゴリ");
            data.Columns.Add("アプリ/サイト名");
            data.Columns.Add("ID");
            data.Columns.Add("メールアドレス");
            data.Columns.Add("パスワード");
            data.Columns.Add("URL");
            data.Columns.Add("備考");
            // テーブル名を設定
            data.TableName = "AccountInfo";
            // 既に保存済みのIDパスワードファイルがあれば、読み込む
            if (File.Exists(_AccountInfoFile)) data.ReadXml(_AccountInfoFile);
            // データが空の場合、初期データを設定
            else data.WriteXml(_AccountInfoFile, XmlWriteMode.WriteSchema);
            // パスワードの表示可否に基づいてデータを調整
            if (viewPassword.Checked)
                MaskPasswords(dataGrid, viewPassword.Checked);
            else if (!viewPassword.Checked && currentViewPasswordCheckBox.Checked)
            {
                var row = dataGrid.CurrentRow;
                currentMaskPasswords(row, currentViewPasswordCheckBox.Checked);
            }
            else if (viewPassword.Checked && currentViewPasswordCheckBox.Checked)
                MaskPasswords(dataGrid, viewPassword.Checked);
            // データ表示
            dataGrid.DataSource = data;
            // パスワード列の初期化
            InitializePasswordTags();
            /**
             * IDパスワード一覧の初期設定（UI）
             */
            // 行選択モードの設定
            dataGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            // 列を左右一杯に広げる
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // 1行置きの背景色を設定
            dataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.Linen;
            // 書き込み禁止の設定
            dataGrid.ReadOnly = true;
            // コピーした値にヘッダを含まない
            dataGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            // ユーザーの行追加を禁止にする
            dataGrid.AllowUserToAddRows = false;
            // カテゴリドロップダウンの再作成
            RefreshDropDownList();
            searchTextBox.Text = "";
            // DataGridView の列の幅を変更できないようにする
            foreach (DataGridViewColumn column in dataGrid.Columns)
                column.Resizable = DataGridViewTriState.False;
            // CellFormattingイベントを追加
            dataGrid.CellFormatting += dataGrid_CellFormatting;
            // 無操作監視タイマーの初期化
            inactivityTimer = new Timer();
            inactivityTimer.Interval = 1000; // 1秒ごと
            inactivityTimer.Tick += InactivityTimer_Tick;
            inactivityTimer.Start();

            // 初期アクティビティ時間を設定
            lastActivityTime = DateTime.Now;

            // 全フォームでキー・マウス入力を監視
            this.MouseMove += ResetInactivityTimer;
            this.KeyDown += ResetInactivityTimer;
            this.MouseClick += ResetInactivityTimer;
        }

        // 無操作タイマーのリセット処理
        private void ResetInactivityTimer(object sender, EventArgs e)
        {
            lastActivityTime = DateTime.Now;
        }

        // 無操作タイマーのイベントハンドラ
        private void InactivityTimer_Tick(object sender, EventArgs e)
        {
            if (timeOutFlag && (DateTime.Now - lastActivityTime).TotalMinutes >= timeOutMinutes)
            {
                inactivityTimer.Stop();
                Application.Exit();
            }
        }

        // パスワード列の初期化
        private void InitializePasswordTags()
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (row.IsNewRow) continue;
                var cell = row.Cells["パスワード"];
                if (cell != null && cell.Tag == null)
                {
                    cell.Tag = cell.Value?.ToString() ?? "";
                }
            }
        }

        // パスワード列の表示を制御するためのイベントハンドラ
        private void dataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGrid.Columns[e.ColumnIndex].Name == "パスワード" && e.Value != null)
            {
                var row = dataGrid.Rows[e.RowIndex];
                var cell = row.Cells["パスワード"];
                const char MaskChar = '●';

                if (viewPassword.Checked)
                {
                    e.Value = cell.Tag?.ToString() ?? e.Value.ToString(); // 元の値
                }
                else if (currentViewPasswordCheckBox.Checked && row == dataGrid.CurrentRow)
                {
                    e.Value = cell.Tag?.ToString() ?? e.Value.ToString(); // 個別表示
                }
                else
                {
                    string original = cell.Tag?.ToString() ?? e.Value.ToString();
                    e.Value = new string(MaskChar, original.Length);
                }
            }
        }

        // 全てのパスワードのマスキング制御を行うチェックボックス
        private void viewPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (viewPassword.Checked) currentViewPasswordCheckBox.Enabled = false;
            else currentViewPasswordCheckBox.Enabled = true;
            // チェックボックスの状態が変更されたときに、DataGridViewの表示を更新する
            dataGrid.Refresh();
        }

        // 全てのパスワードをマスキングする関数
        private static void MaskPasswords(DataGridView dataGrid, bool mask)
        {
            const string passwordColumnName = "パスワード";
            const char MaskChar = '●';
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (row.IsNewRow) continue;
                var cell = row.Cells[passwordColumnName];
                if (cell == null) continue;
                if (mask)
                {
                    // 最初だけ元の値をTagに保存
                    if (cell.Tag == null)
                    {
                        cell.Tag = cell.Value?.ToString() ?? "";
                    }
                    var original = cell.Tag.ToString();
                    cell.Value = new string(MaskChar, original.Length);
                }
                else
                {
                    // 表示状態に戻す（Tagから）
                    if (cell.Tag != null)
                    {
                        cell.Value = cell.Tag.ToString();
                    }
                }
            }
        }

        // 選択行のパスワードの表示制御を行うチェックボックス
        private void currentViewPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (viewPassword.Checked) return; // 全体表示中なら無視

            var row = dataGrid.CurrentRow;
            if (row != null && !row.IsNewRow)
            {
                currentMaskPasswords(row, currentViewPasswordCheckBox.Checked);
            }
            dataGrid.Refresh();
        }

        // 選択行のパスワードのマスキング制御を行う関数
        private static void currentMaskPasswords(DataGridViewRow row, bool mask)
        {
            const string passwordColumnName = "パスワード";
            const char MaskChar = '●';
            var cell = row.Cells[passwordColumnName];
            if (cell == null) return;

            if (mask)
            {
                // 最初だけ元の値をTagに保存
                if (cell.Tag == null)
                {
                    cell.Tag = cell.Value?.ToString() ?? "";
                }
                var original = cell.Tag.ToString();
                cell.Value = new string(MaskChar, original.Length);
            }
            else
            {
                // 表示（Tagに元値があればそれを表示）
                if (cell.Tag != null)
                {
                    cell.Value = cell.Tag.ToString();
                }
            }
        }

        // 初期パスワード時に呼び出される関数
        public void FirstChangePassword()
        {
            if (changePasswordWindow == null || changePasswordWindow.IsDisposed)
            {
                changePasswordWindow = new ChangePassword();
                changePasswordWindow.ShowDialog();
            }
        }

        // 設定ボタン
        private void SettingButton_Click(object sender, EventArgs e)
        {
            if (settingForm == null || settingForm.IsDisposed)
            {
                settingForm = new SettingForm(this);
                settingForm.Show();
            }
        }

        // カテゴリドロップダウンリスト表示時の処理
        private void Category_DropDown(object sender, EventArgs e)
        {
            // カテゴリドロップダウンリストの中身が０なら、作り直す
            if (Category.Items.Count == 0) RefreshDropDownList();
        }

        // カテゴリドロップダウンの再作成
        private void RefreshDropDownList()
        {
            Category.Items.Clear();
            Category.Items.Add("すべて");
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                var category = dataGrid["カテゴリ", i].Value.ToString();
                if (!Category.Items.Contains(category)) Category.Items.Add(category);
            }
            // デフォルトで「すべて」が選択されるようにする
            Category.SelectedIndex = 0;
        }

        // カテゴリドロップダウンリスト表示時の処理
        private void Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            var data = (DataTable)dataGrid.DataSource;
            if (Category.Text == "すべて") data.DefaultView.RowFilter = "";
            else data.DefaultView.RowFilter = "カテゴリ = '" + Category.Text + "'";
        }

        // IDをクリップボードに取得する処理（ID取得）
        private void IDClip_Click(object sender, EventArgs e)
        {
            try
            {
                // 選択行を取得
                var row = dataGrid.CurrentRow;
                // 選択行がnullの場合
                if (row == null)
                {
                    MessageBox.Show("行が選択されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // "ID"セルの値を取得
                var cell = row.Cells["ID"];
                // "ID"セルがnullまたはその値がnullの場合
                if (cell == null || cell.Value == null)
                {
                    MessageBox.Show("IDが指定されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // メールアドレスを取得し、クリップボードにコピー
                var id = cell.Value.ToString();
                // メールアドレスが空でない場合にクリップボードにコピー
                if (!string.IsNullOrEmpty(id))
                {
                    Clipboard.SetText(id);
                }
                else
                {
                    MessageBox.Show("セルが未入力です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // エラーが発生した場合は、エラーメッセージを表示
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // メールアドレスをクリップボードに取得する処理（メールアドレス取得）
        private void MailClip_Click(object sender, EventArgs e)
        {
            try
            {
                // 選択行を取得
                var row = dataGrid.CurrentRow;
                // 選択行がnullの場合
                if (row == null)
                {
                    MessageBox.Show("行が選択されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // "メールアドレス"セルの値を取得
                var cell = row.Cells["メールアドレス"];
                // "メールアドレス"セルがnullまたはその値がnullの場合
                if (cell == null || cell.Value == null)
                {
                    MessageBox.Show("メールアドレスが指定されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // メールアドレスを取得し、クリップボードにコピー
                var mail = cell.Value.ToString();
                // メールアドレスが空でない場合にクリップボードにコピー
                if (!string.IsNullOrEmpty(mail))
                {
                    Clipboard.SetText(mail);
                }
                else
                {
                    MessageBox.Show("セルが未入力です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // エラーが発生した場合は、エラーメッセージを表示
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // パスワードをクリップボードに取得する処理（パスワード取得）
        private void PassClip_Click(object sender, EventArgs e)
        {
            try
            {
                // 選択行を取得
                var row = dataGrid.CurrentRow;
                // 選択行がnullの場合
                if (row == null)
                {
                    MessageBox.Show("行が選択されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // "パスワード"セルの値を取得
                var cell = row.Cells["パスワード"];
                // "パスワード"セルがnullまたはその値がnullの場合
                if (cell == null || cell.Value == null)
                {
                    MessageBox.Show("パスワードが指定されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // パスワードを取得し、クリップボードにコピー
                var pwd = cell.Value.ToString();
                // パスワードが空でない場合にクリップボードにコピー
                if (!string.IsNullOrEmpty(pwd))
                {
                    Clipboard.SetText(pwd);
                }
                else
                {
                    MessageBox.Show("セルが未入力です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // エラーが発生した場合は、エラーメッセージを表示
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 編集モード変更の処理（編集）
        private void EditMode_Click(object sender, EventArgs e)
        {
            // ReadOnlyプロパティの状態を反転
            dataGrid.ReadOnly = !dataGrid.ReadOnly;
            // IDパスワード一覧の書き込み禁止モードを有効にする
            if (dataGrid.ReadOnly == true)
            {
                // オートセーブが有効な場合、保存処理を実行
                if (autoSaveFlag) Save();
                // 編集ボタンのテキストと背景色を設定（最初の状態に戻す）
                EditMode.Text = "編集";
                EditMode.BackColor = SystemColors.Control;
                DeleteButton.BackColor = SystemColors.Control;
                DeleteButton.Enabled = false;
                // ユーザーによる行追加を禁止にする
                dataGrid.AllowUserToAddRows = false;
                // カテゴリドロップダウンリストを作り直す
                RefreshDropDownList();
                // 一度更新処理を走らせる
                load();
                // リロードボタンを押下可能にする
                reload.Enabled = true;
                reload.BackColor = SystemColors.ButtonHighlight;
                // カテゴリーの絞り込み処理を再度走らせる
                Category_SelectedIndexChanged(sender, e);
            }
            else
            {
                // 編集ボタンのテキストと背景色（黄色）を編集中に設定
                EditMode.Text = "編集中";
                EditMode.BackColor = Color.Yellow;
                // 同時に削除ボタンの色も変更
                DeleteButton.BackColor = Color.Yellow;
                DeleteButton.Enabled = true;
                // ユーザーによる行追加を有効にする
                dataGrid.AllowUserToAddRows = true;
                // リロードボタンを押下不可にする
                reload.Enabled = false;
                reload.BackColor = SystemColors.Control;
            }
        }

        // XMLに保存するボタンのイベント処理（保存ボタン）
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        // XMLに保存する処理（保存）
        public void Save()
        {
            //IDパスワード一覧をファイルに保存
            DataTable data = (DataTable)dataGrid.DataSource;
            data.WriteXml(_AccountInfoFile, XmlWriteMode.WriteSchema);
            //メッセージの表示
            if (saveNotificationFlag)
            {
                // 保存通知の設定が有効な場合、メッセージボックスを表示
                MessageBox.Show("情報を保存しました", "保存完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // URLをクリップボードに取得する処理（URL取得）
        private void URLButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 選択行を取得
                var row = dataGrid.CurrentRow;
                // 選択行がnullの場合
                if (row == null)
                {
                    MessageBox.Show("行が選択されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // "URL"セルの値を取得
                var cell = row.Cells["URL"];
                // "URL"セルがnullまたはその値がnullの場合
                if (cell == null || cell.Value == null)
                {
                    MessageBox.Show("URLが指定されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // URLを取得し、クリップボードにコピー
                var url = cell.Value.ToString();
                // URLが空でない場合にクリップボードにコピー
                if (!string.IsNullOrEmpty(url))
                {
                    Clipboard.SetText(url);
                }
                else
                {
                    MessageBox.Show("セルが未入力です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // エラーが発生した場合は、エラーメッセージを表示
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // キー入力の処理
        private void dataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            //書き込みの可否
            if (dataGrid.ReadOnly) return;
            //最下段（空白行）の時
            if (dataGrid.CurrentRow.IsNewRow == true) return;
            //DELキーが押された時
            if (e.KeyCode == Keys.Delete)
                dataGrid.Rows.Remove(dataGrid.CurrentRow);
        }

        // 削除ボタンの処理
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                // データグリッドが読み取り専用の場合は何もしない
                if (dataGrid.ReadOnly)
                {
                    MessageBox.Show("現在のモードでは削除できません。編集モードに切り替えてください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // 最下段（空白行）の場合は何もしない
                if (dataGrid.CurrentRow == null || dataGrid.CurrentRow.IsNewRow)
                {
                    MessageBox.Show("削除する行が選択されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (deletionNotificationFlag)
                {
                    // ユーザーに確認メッセージを表示し、削除の確認を取る
                    var result = MessageBox.Show("選択した行を削除しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    // 確認が取れたら選択行を削除
                    if (result == DialogResult.Yes) dataGrid.Rows.Remove(dataGrid.CurrentRow);
                }
                else dataGrid.Rows.Remove(dataGrid.CurrentRow);
            }
            catch (Exception ex)
            {
                // エラーが発生した場合は、エラーメッセージを表示
                MessageBox.Show($" データがありません {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // パスワード生成ウィンドウの表示
        private void createPassWordBtn_Click(object sender, EventArgs e)
        {
            if (createPasswordWindow == null || createPasswordWindow.IsDisposed)
            {
                createPasswordWindow = new CreatePassWord();
                createPasswordWindow.Show();
            }
        }

        // デフォルトのブラウザーでURLのページを開く処理
        private void Browser_Click(object sender, EventArgs e)
        {
            try
            {
                var row = dataGrid.CurrentRow;
                // 行が選択されていない場合
                if (row == null)
                {
                    MessageBox.Show("行が選択されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var cell = row.Cells["URL"];
                // URLセルが存在しない場合
                if (cell == null || cell.Value == null)
                {
                    MessageBox.Show("URLが指定されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var url = cell.Value.ToString();
                // URLのセルが空白だった場合
                if (string.IsNullOrWhiteSpace(url))
                {
                    MessageBox.Show("URLが空白です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // URLの形式が不正な場合
                if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    MessageBox.Show("URL形式が不正です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // ブラウザを起動してURLを開く
                var startInfo = new System.Diagnostics.ProcessStartInfo(url)
                {
                    UseShellExecute = true
                };
                _ = System.Diagnostics.Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                // エラーが発生した場合は、エラーメッセージを表示
                MessageBox.Show($"データの取得中にエラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 入力フォーム制御
        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enterキーが押された場合
            {
                searchBtn.PerformClick(); // 検索ボタンのクリック処理を発火
                e.SuppressKeyPress = true; // デフォルトのEnterキー動作（音など）を抑制
            }
        }

        //検索ボタン
        private void searchBtn_Click(object sender, EventArgs e)
        {
            // 検索ワードを取得
            string searchWord = searchTextBox.Text.Trim();
            // 検索ワードが空であれば処理しない
            if (string.IsNullOrEmpty(searchWord)) load();
            // データテーブルを作成し、XMLからデータを読み込む
            DataTable data = new DataTable();
            data.Columns.Add("カテゴリ");
            data.Columns.Add("アプリ/サイト名");
            data.Columns.Add("ID");
            data.Columns.Add("メールアドレス");
            data.Columns.Add("パスワード");
            data.Columns.Add("URL");
            data.Columns.Add("備考");
            data.TableName = "AccountInfo";
            if (File.Exists(_AccountInfoFile)) data.ReadXml(_AccountInfoFile);
            // 検索結果を格納するためのフィルタリング式を構築
            string filterExpression = string.Format(
                " カテゴリ LIKE '%{0}%' OR " +
                " [アプリ/サイト名] LIKE '%{0}%' OR " +
                " ID LIKE '%{0}%' OR " +
                " メールアドレス LIKE '%{0}%' OR " +
                " パスワード LIKE '%{0}%' OR " +
                " URL LIKE '%{0}%' OR " +
                " 備考 LIKE '%{0}%' ", searchWord);
            // フィルタリングを実行して結果を表示
            data.DefaultView.RowFilter = filterExpression;
            dataGrid.DataSource = data;
        }

        // "使い方"リンクラベルクリック時の処理
        private void ManualLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new System.Diagnostics.ProcessStartInfo("https://sites.google.com/view/tanakatechpublicapplication/manual?authuser=0")
            {
                UseShellExecute = true
            };
            _ = System.Diagnostics.Process.Start(startInfo);
        }
    }
}
