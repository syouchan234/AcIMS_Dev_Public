using System;
using System.Windows.Forms;

namespace passmanager{
    public partial class CreatePassWord : Form
    {
        public CreatePassWord()
        {
            //画面に置かれたコントロール類に初期値を設定し、画面を描画するメソッド
            InitializeComponent();
            //プログラムをディスプレイの真ん中に表示
            this.StartPosition = FormStartPosition.CenterScreen;
            // 常に手前に表示されるように設定
            this.TopMost = true;
            //ウィンドウのサイズを固定にする
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            // ウィンドウの最大化を禁止にする
            this.MinimizeBox = false; // 最小化を無効にする
            this.MaximizeBox = false; // 最大化を無効にする
            // 各種チェックボックスの初期値
            isBigEnglishCheckBox.Checked = true;
            isSmallEnglishCheckBox.Checked = true;
            isNumCheckBox.Checked = true;
            isSymbolCheckBox.Checked = true;
            MaskedPassword();
        }
        private void CreatePassWord_Load(object sender, EventArgs e) { }
        private void createKeyWord_Click(object sender, EventArgs e)
        {
            var createLoop = Convert.ToInt32(createPassNum.Value);
            const int maxCreate = 256; // 最大生成文字数
            if (createLoop <= maxCreate)
            {
                resultBox.Text = "";
                var smallEnglish = "abcdefghijklmnopqrstuvwxyz";
                var bigEnglish = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                var num = "0123456789";
                var symbol = "!#$%@&";
                var result = "";
                var random = new Random();
                String resultText = "";

                if (isBigEnglishCheckBox.Checked) result += bigEnglish;
                if (isSmallEnglishCheckBox.Checked) result += smallEnglish;
                if (isNumCheckBox.Checked) result += num;
                if (isSymbolCheckBox.Checked) result += symbol;

                //いずれかにチェックが入っていた場合
                if (isBigEnglishCheckBox.Checked || isSmallEnglishCheckBox.Checked ||
                    isNumCheckBox.Checked || isSymbolCheckBox.Checked)
                {
                    for (int i = 0; i < createLoop; i++) resultText += result[random.Next(result.Length)];
                    Clipboard.SetText(resultText);
                }
                //チェックが何も無い場合流す
                else if (string.IsNullOrEmpty(result)) return;
                resultBox.Text = resultText;
            }
            else
            {
                MessageBox.Show("256文字以上の生成は出来ません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void isViewPassword_CheckedChanged(object sender, EventArgs e)
        {
            MaskedPassword();
        }

        void MaskedPassword()
        {
            // パスワードの可視性を切り替える
            if (isViewPassword.Checked) resultBox.PasswordChar = '\0'; // パスワードを表示
            else resultBox.PasswordChar = '●'; // パスワードをマスク
        }
    }
}
