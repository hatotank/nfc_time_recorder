using System;
using System.Data.OleDb;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace nfc_time_recorder
{
    public partial class RegistForm : Form
    {
        private Mdb mdb;
        private NfcMain nfc;
        private bool timer_lock = false;

        public RegistForm()
        {
            InitializeComponent();
        }

        public RegistForm(Mdb mdb,NfcMain nfc)
        {
            this.mdb = mdb;
            this.nfc = nfc;

            InitializeComponent();
        }

        //ポーリング中
        private void form_poling_enable()
        {
            //カードをセットしてください
            this.lbl_card.Visible = true;

            //ラベル：登録ユーザ
            this.lbl_mes1.Visible = false;
            //テキストボックス
            this.tbox_user.Visible = false;

            //テーブルパネルレイアウト
            this.tlp.Visible = false;
            //ラベル：UID
            this.lbl_11.Text = "";
            //ラベル：PMd
            this.lbl_12.Text = "";
            //ラベル：識別ID
            this.lbl_13.Text = "";
            //ラベル：カード種類
            this.lbl_14.Text = "";
            //ラベル：カード名称
            this.lbl_15.Text = "";

            //ボタン
            this.btn_polling.Enabled = false;
            this.btn_regist_user.Enabled = false;
            this.btn_cancel_user.Enabled = true;
        }

        //ポーリング完了
        private void form_polling_disable()
        {
            //カードをセットしてください
            this.lbl_card.Visible = false;

            //ラベル：登録ユーザ
            this.lbl_mes1.Visible = true;
            //テキストボックス
            this.tbox_user.Visible = true;

            //テーブルパネルレイアウト
            this.tlp.Visible = true;
            //ラベル：UID
            this.lbl_11.Text = "";
            //ラベル：PMd
            this.lbl_12.Text = "";
            //ラベル：識別ID
            this.lbl_13.Text = "";
            //ラベル：カード種類
            this.lbl_14.Text = "";
            //ラベル：カード名称
            this.lbl_15.Text = "";

            //ボタン
            this.btn_polling.Enabled = true;
            this.btn_regist_user.Enabled = true;
            this.btn_cancel_user.Enabled = true;

            //テスト
            //ラベル：名前
            this.tbox_user.Text = "テスト太郎";
            //ラベル：UID
            this.lbl_11.Text = "1234567890";
            //ラベル：PMd
            this.lbl_12.Text = "1234567890";
            //ラベル：識別ID
            this.lbl_13.Text = "0";
            //ラベル：カード種別
            this.lbl_14.Text = "4";
            //ラベル：カード名称
            this.lbl_15.Text = "Felica";
        }

        //登録
        private void btn_regist_user_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("btn_regist_user_Click");
            if (tbox_user.Text != "")
            {
                //DB登録
                int result;
                OleDbDataReader reader;

                reader = mdb.executeQuery("select count(1) from parsonal where uid = '" + this.lbl_11.Text + "'");
                reader.Read();
                result = (int)reader.GetValue(0);
                if (result == 0)
                {
                    string sql = "insert into parsonal values ("
                        + " '" + this.lbl_11.Text + "'"
                        + ",'" + this.lbl_12.Text + "'"
                        + ",'" + this.lbl_13.Text + "'"
                        + ",'" + this.lbl_14.Text + "'"
                        + ",'" + this.lbl_15.Text + "'"
                        + ",'" + this.tbox_user.Text + "')";
                    result = mdb.executeNonQuery(sql);

                    MessageBox.Show("登録しました。");
                    //フォームクローズ
                    this.Close();
                }
                else if(result > 0)
                {
                    MessageBox.Show("既に登録済みです。");
                }
            }
            else
            {
                MessageBox.Show("名前を入力してください。");
            }
        }

        //取消
        private void btn_cancel_user_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("btn_cancel_user_click");
            //フォームクローズ
            this.Close();
        }

        //ロード
        private void RegistForm_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Load");
            //表示
            this.form_poling_enable();
            this.timer_regist.Enabled = true;
        }

        //クローズ
        private void RegistForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("Close");
            this.timer_regist.Enabled = false;
        }

        private void timer_regist_Tick(object sender, EventArgs e)
        {
            if (nfc.IsCurrentCard && this.timer_lock == false)
            {
                try
                {
                    timer_lock = true;
                    this.form_polling_disable();
                    this.tbox_user.Text = "";

                    ASCIIEncoding asciiEncoding = new ASCIIEncoding();
                    byte[] recv;// = new byte[262];
                    string tmp;
                    byte[] send = null;
                    //UID
                    send = new byte[] { 0xff, 0xca, 0x00, 0x00 };
                    recv = nfc.SendCommand2(send);
                    tmp = BitConverter.ToString(recv).Replace("-", "");
                    this.lbl_11.Text = tmp;
                    Debug.WriteLine("CARD_UID:" + tmp);

                    //PMm
                    send = new byte[] { 0xff, 0xca, 0x01, 0x00 };
                    recv = nfc.SendCommand2(send);
                    tmp = BitConverter.ToString(recv).Replace("-", "");
                    this.lbl_12.Text = tmp;
                    Debug.WriteLine("CARD_PMm:" + tmp);

                    //識別ID
                    send = new byte[] { 0xff, 0xca, 0xf0, 0x00 };
                    recv = nfc.SendCommand2(send);
                    tmp = BitConverter.ToString(recv).Replace("-", "");
                    this.lbl_13.Text = tmp;
                    Debug.WriteLine("CARD_CID:" + tmp);

                    //カード種類
                    send = new byte[] { 0xff, 0xca, 0xf3, 0x00 };
                    recv = nfc.SendCommand2(send);
                    tmp = BitConverter.ToString(recv).Replace("-", "");
                    this.lbl_14.Text = tmp;
                    Debug.WriteLine("CARD_TYPE:" + tmp);

                    //名称
                    send = new byte[] { 0xff, 0xca, 0xf1, 0x00 };
                    recv = nfc.SendCommand2(send);
                    tmp = asciiEncoding.GetString(recv);
                    this.lbl_15.Text = tmp;
                    Debug.WriteLine("CARD_NAME:" + tmp);
                    Debug.WriteLine("");
                    this.timer_regist.Enabled = false;
                }
                catch (ApplicationException)
                {
                    //null
                    Debug.WriteLine("ApplicationException:RegistForm");
                }
            }
        }

        private void btn_polling_Click(object sender, EventArgs e)
        {
            this.form_poling_enable();
            this.timer_lock = false;
            this.timer_regist.Enabled = true;
        }
    }
}
