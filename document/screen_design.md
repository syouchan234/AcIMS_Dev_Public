# AcIMS — 画面設計書（概要・コントロール仕様・振る舞い）

作成日: 2025-11-22  
対象ブランチ（想定）: document  
基になったソース: MainForm.Designer.cs, Certification.Designer.cs, ChangePassword.Designer.cs, CreatePassWord.Designer.cs, SettingForm.Designer.cs（main ブランチ）

目的:
- 最小限のドキュメント化。既存の .Designer.cs から画面構成・コントロール仕様・主要イベントを抽出してまとめる。
- UI 実装者・保守者が参照できるよう、画面ごとにコントロール一覧と主要な振る舞い（クリックイベント等）を記載。

目次
- MainForm（メイン画面）
- Certification（認証）
- ChangePassword（マスターパスワード変更）
- CreatePassWord（パスワード自動生成）
- SettingForm（設定）
- 画面遷移（簡易）
- 実装注記・差分検出（Designer と宣言の不整合など）
---

## MainForm（メイン画面）
画面目的:
- 登録されたアカウント情報一覧の参照・検索・コピー・操作（ID/パスワード/メール/URL 取得等）。
- パスワード生成、外部ブラウザ起動、項目の編集/削除、設定画面起動など。

レイアウト（ウィンドウサイズ: 800 x 464 想定）
- DataGrid（dataGrid）
  - 型: System.Windows.Forms.DataGridView
  - 位置/サイズ: (12,28) / 776x360
  - 用途: アカウント一覧表示（列定義はコード側で設定）
  - TabIndex: 1
- ラベル: "カテゴリ"（label1）
  - 型: Label
  - 位置: (23,399)
  - TabIndex: 0
- コンボボックス: Category
  - 型: ComboBox
  - 位置/サイズ: (75,394) / 180x23
  - TabIndex: 2
  - イベント: SelectedIndexChanged -> Category_SelectedIndexChanged
- テキストボックス: searchTextBox
  - 型: TextBox
  - 位置/サイズ: (75,425) / 180x23
  - TabIndex: 11
  - イベント: KeyDown -> searchTextBox_KeyDown
- ボタン: searchBtn（検索）
  - 位置/サイズ: (23,424) / 42x24
  - TabIndex: 12
  - Click -> searchBtn_Click

主要操作ボタン（下部）
- IDClip（ID取得）
  - 位置: (261,395) / 100x24
  - Click -> IDClip_Click
- PassClip（パスワード取得）
  - 位置: (261,424) / 100x24
  - Click -> PassClip_Click
- MailClip（メールアドレス取得）
  - 位置: (367,395)
  - Click -> MailClip_Click
- URLButton（URL取得）
  - 位置: (367,424)
  - Click -> URLButton_Click
- createPassWordBtn（パスワード生成画面起動）
  - 位置: (473,424)
  - Click -> createPassWordBtn_Click
- Browser（ブラウザ起動）
  - 位置: (473,395)
  - Click -> Browser_Click
- DeleteButton（削除）
  - 位置: (578,395)
  - Click -> DeleteButton_Click
- EditMode（編集）
  - 位置: (644,395)
  - Click -> EditMode_Click
- SaveButton（保存）
  - 位置: (710,395)
  - Click -> SaveButton_Click
- SettingButton（設定画面起動）
  - 位置: (578,423) / 126x24
  - Click -> SettingButton_Click
- reload（更新）
  - 位置: (710,423)
  - Click -> reload_Click

チェックボックス / リンク
- viewPassword（全てのパスワードを表示）
  - 位置: (59,6)
  - CheckedChanged -> viewPassword_CheckedChanged
- currentViewPasswordCheckBox（パスワードの表示）
  - 位置: (199,6)
  - CheckedChanged -> currentViewPasswordCheckBox_CheckedChanged
- ManualLink（使い方）
  - 位置: (12,7)
  - LinkClicked -> ManualLink_LinkClicked

振る舞い（概略）
- DataGrid 選択行に対して、各「取得」ボタンは該当フィールドの値をクリップボードへコピーする想定（IDClip, PassClip, MailClip, URLButton）。
- createPassWordBtn はパスワード生成ダイアログを表示（CreatePassWord）。
- Browser は選択行の URL をブラウザで開く。
- EditMode 切替で DataGrid の編集可否を切り替える（編集モード→保存ボタンで永続化）。
- 検索は searchTextBox 入力 → searchBtn 或いは Enter でフィルタリング。
- viewPassword / currentViewPasswordCheckBox のチェックは DataGrid のパスワード列の表示方法に影響。

注意点（実装上のヒント）
- dataGrid の列定義は Designer には書かれておらず（InitializeComponent で列追加していないように見える）、実行時にコード側でバインド／設定されているはず。
- private フィールドに `encryption` が宣言されているが InitializeComponent 内で生成していない（差分注記参照）。

---

## Certification（認証）
画面目的:
- アプリ起動時のマスターパスワード入力を行うダイアログ。

主要コントロール
- passwordText（TextBox）
  - 位置/サイズ: (12,42) / 314x23
  - TabIndex: 0
- label1（タイトル）
  - 文言: "マスターパスワードを入力してください"
- confirmBtn（確認ボタン）
  - 位置/サイズ: (12,96) / 314x44
  - Font: MS P ゴシック 18F
  - Click -> confirmBtn_Click
- isViewPassword（パスワードを表示）
  - チェック時: passwordText のマスク解除
  - CheckedChanged -> isViewPassword_CheckedChanged
- ManualLink（使い方）
  - LinkClicked -> ManualLink_LinkClicked

振る舞い
- confirmBtn は入力されたマスターパスワードを検証し、成功でメイン画面へ遷移（またはメイン処理を許可）。
- isViewPassword による表示切替。

---

## ChangePassword（マスターパスワード変更）
画面目的:
- マスターパスワードの更新処理（2 回入力による確認）。

主要コントロール
- changeNewPassword（TextBox） — 新パスワード入力
- isViewPasswordCheckBox（CheckBox） — 新パスワードの表示切替（CheckedChanged -> isViewPasswordCheckBox_CheckedChanged）
- confirmPasswordTextBox（TextBox） — 確認入力
- isViewConfirmPassword（CheckBox） — 確認用パスワード表示切替
- changePsswordBtn（確認ボタン）
  - 位置/サイズ: (11,208) / 297x26
  - Click -> changePsswordBtn_Click
- 表示用ラベル群（注意文など）
- ManualLink（使い方）

振る舞い
- 両方の入力が一致するか検証し、条件を満たせば保存処理（UI 側でハッシュ化などの処理がかかる想定）。
- 重要注意: マスターパスワードを忘れるとデータが失われる旨の文言がある（運用上の注意に記載）。

---

## CreatePassWord（パスワード自動生成）
画面目的:
- 指定条件（文字数、大文字/小文字/数字/記号）でパスワードを生成し結果を表示。

主要コントロール
- createKeyWord（生成ボタン）
  - Click -> createKeyWord_Click
- resultBox（TextBox）
  - 生成結果表示
- groupBox（条件）
  - createPassNum（NumericUpDown） — 生成文字数（初期値: 8、最大 256）
  - isBigEnglishCheckBox（大文字） / isSmallEnglishCheckBox（小文字） / isNumCheckBox（数字） / isSymbolCheckBox（記号）
- isViewPassword（生成結果の表示切替）
  - CheckedChanged -> isViewPassword_CheckedChanged

振る舞い
- 生成ボタン押下で resultBox に生成文字列をセット。既存コードでの仕様に従う（ランダム生成のアルゴリズム等）。
- isViewPassword は生成結果のテキスト表示のマスク/非マスク制御に利用。

---

## SettingForm（設定）
画面目的:
- アプリの動作設定（削除時確認、保存確認、オートセーブ、タイムアウトなど）およびデータ初期化、マスターパスワード変更等の起点。

主要コントロール
- DeletionNotification（CheckBox） — 項目削除時の確認通知（CheckedChanged -> DeletionNotification_CheckedChanged）
- SaveNotification（CheckBox） — 保存時の確認通知
- AutoSave（CheckBox） — オートセーブ機能
- TimeOut（CheckBox） — タイムアウト機能
- TimeOutNum（NumericUpDown） — タイムアウト分（初期値 5、最大 60）
  - ValueChanged -> TimeOutNum_ValueChanged
- ChangePassword（Button） — マスターパスワード変更画面起動
  - Click -> ChangePassword_Click
- DataInitialization（Label） — データの初期化（Warning, Click -> DataInitialization_Click）
- Initializing_settings（Label） — 設定の初期化（Click -> Initializing_settings_Click）
- ManualLink（使い方）

振る舞い
- 各オプションのチェックはアプリ設定（永続化）に保存される想定。
- DataInitialization / Initializing_settings は危険操作（赤文字）で、確認ダイアログを出してから実行すること。

---

## 画面遷移（簡易）
- 起動 -> Certification（認証） -> 成功で MainForm 表示
- MainForm から:
  - CreatePassWord をモーダル／モデルレスで表示（パスワード生成）
  - SettingForm を表示（設定）
- SettingForm から:
  - ChangePassword を表示（マスターパスワード変更）
- 各「使い方」リンクはマニュアル表示（外部 URL か内蔵ヘルプ）を想定

---

## 実装注記 / 差分検出
- MainForm の private フィールドに `private System.Windows.Forms.Button encryption;` がある一方、InitializeComponent() 内で `encryption` を生成していない。未使用変数の可能性があるので確認を推奨。
- DataGrid のカラム定義が Designer に含まれていない。実行時バインドやコード側での列生成が存在するはず。列名／型をコードから抽出してドキュメントに追加することを推奨（次バージョン）。
- リソースアイコン（$this.Icon）は各フォームで参照されている（プロジェクトの Resources を確認）。

---

## 提案：ファイル追加/更新の内容（コミットする内容）
- Path: document/screen_design.md
- 内容: 本ファイル（上記）
- コミットメッセージ例: "Add screen design draft (MainForm, Certification, ChangePassword, CreatePassWord, SettingForm)"
- PR タイトル例: "ドキュメント: 画面設計書を追加 (document/screen_design.md)"
- PR 本文テンプレート: 
  - 概要: 本 PR は main ブランチの画面実装（.Designer.cs）を基に最小限の画面設計書を document ブランチへ追加します。  
  - 変更点: document/screen_design.md を追加。内容は MainForm, Certification, ChangePassword, CreatePassWord, SettingForm のコントロール一覧と振る舞い。
  - 注意点: MainForm の `encryption` 未使用変数など差分あり（実装確認推奨）。