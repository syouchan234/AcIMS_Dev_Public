<h1>外部仕様</h1>
<a href="https://sites.google.com/view/tanakatechpublicapplication/home/manual?authuser=0" target="_blank">公開マニュアル</a>
<h1>内部仕様</h1>
<pre>
  <h3>ファイル説明</h3>
setting.txt
  ハッシュ化したマスターパスワードを格納
setting.json
　設定情報を格納するファイル
AccountInfo.xml
  登録されたアカウント情報を格納
AccountInfo_ciphered.bin
　登録されたアカウント情報を暗号化して格納
<h3>詳細仕様</h3>
初回起動時はマスターパスワードを設定するように促すウィンドウを表示
初回起動の判別はsetting.jsonのfirst_flgカラムのboolean型と重要ファイルの有無（setting.txtの有無とAccountInfo_ciphered.binの有無）で識別している

設定したマスターパスワードはハッシュ化した値を基にAccountInfo.xmlを
暗号化しAccountInfo_ciphered.binを生成し、平文のAccountInfo.xmlを削除する仕様になっている

再起動時、マスターパスワードを要求する

再起動時、入力されたマスターパスワードをハッシュ化し元にハッシュデータと一致した場合、
そのハッシュデータを基に復号化処理に走る

アプリ起動時は常時、AccountInfo.xmlが表示され、アプリ終了時には暗号化された
データファイルを生成した後に平文ファイルを削除する仕様にしている

※メモリ保存方式を取った方がセキュリティ的には良いが、データ容量が大きくなるにつれ
処理しきれない可能性がある為この方式を取っている
</pre>
<br>
<h1>インストーラー発行手順</h1>
<a href="https://zenn.dev/overdrive1708/articles/howto-vs2022-create-application-installer" target="_blank">こちら</a>
<pre>
  上記の方法に加え、
  初期状態である以下のファイルを一緒に含めておく
　setting.txt
  setting.json
</pre>
