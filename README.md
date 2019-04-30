# nfc_time_recorder
NFCを使ったタイムレコーダー(簡易)


## 概要
平成の物。2017年に会社に適当に出したやつ。  
カードを登録し、登録後カードをかざすとその時点の時間と時刻が記録されるようになっています。  
NFCを使用しているので、大抵のICカードを登録し使うことが出来ます。

## その他
基本Windows7以上なら何もせず動くはず。  
(.Net Framework 2.0使用、Microsoft.Jet.OLEDB.4.0はWindows 7標準)  
NFCやカードリーダにはWindows標準のPC/SCを使用。  
データはmdb(Access)にて管理。C#からSQL発行。

※スレッド処理が適当、ポーリング重い。

## 環境等
- Windows 10 (Version 1703)
- Visual Studio 2010
- Access 2010
- Sony Pasori RC-S380/S  
https://www.sony.co.jp/Products/felica/consumer/download/felicaportsoftware.html

## 作者
[hatotank](https://github.com/hatotank)

## ライセンス
色々参考にしたので、参考程度に

----
## 操作説明
### 起動後の画面
![nfc001](https://github.com/hatotank/nfc_time_recorder/blob/media/nfc000.png?raw=true)

### ユーザーの登録
「登録」をクリック  
![nfc002](https://github.com/hatotank/nfc_time_recorder/blob/media/nfc002.png?raw=true)

メッセージに従い、カードリーダにカードを置きます  
カードの情報が取得されるので、ユーザー名を入力し「登録」をクリック
![nfc003](https://github.com/hatotank/nfc_time_recorder/blob/media/nfc003.png?raw=true)  
カード情報を再取得する場合は「再取得」ボタンをクリック

### ユーザーの削除
「削除」をクリック  
![nfc004](https://github.com/hatotank/nfc_time_recorder/blob/media/nfc004.png?raw=true)  
メッセージに従い、カードリーダーにカードを置きます  
DBにユーザーデータがある場合、表示されるので「削除」をクリック  
![nfc005](https://github.com/hatotank/nfc_time_recorder/blob/media/nfc005.png?raw=true)  
カード情報を再取得する場合は「再取得」ボタンをクリック

### 時間の記録
ユーザー登録してある場合、カードリーダーにカードをかざすとその時点の時間が記録されます。  
(重複登録防止のため、記録後は5秒間のインターバルがあります)  
記録時は「ユーザー名の表示」と「記録時間が赤字」になります
![nfc006](https://github.com/hatotank/nfc_time_recorder/blob/media/nfc006.png?raw=true)

### CSV出力
メニューの「ファイル＞CSV出力」にてDB内容をCSV形式で出力することが出来ます
![nfc007](https://github.com/hatotank/nfc_time_recorder/blob/media/nfc007.png?raw=true)

### 終了
アプリケーションの右上の「×」をクリックし終了

----
## DB構造

**parsonal**

|列名|型|内容|
|:---|:---|:---|
|uid|テキスト型|PK(UID)|
|pmm|テキスト型|PMm|
|cid|テキスト型|識別ID|
|ctype|テキスト型|カード種類|
|cname|テキスト型|カード名称|
|user|テキスト型|ユーザー名|

**timedata**

|列名|型|内容|
|:---|:---|:---|
|uid|テキスト型|(PK)UID|
|renban|数値型|PK(連番)|
|time|日付/時刻型|時刻|


**timedata_backup**

※上記timedataと同じ、削除時に該当ユーザーのtimedataを退避
