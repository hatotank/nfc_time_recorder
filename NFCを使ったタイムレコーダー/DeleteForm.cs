using System;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows.Forms;

namespace nfc_time_recorder
{
    public partial class DeleteForm : Form
    {
        private Mdb mdb;
        private NfcMain nfc;

        private string uid;
        private string user;
        private bool timer_lock = false;

        public DeleteForm()
        {
            InitializeComponent();
        }

        public DeleteForm(Mdb mdb,NfcMain nfc)
        {
            this.mdb = mdb;
            this.nfc = nfc;

            InitializeComponent();
        }

        //ポーリング中
        private void form_polling_enable()
        {
            //カードをセットしてください
            this.lbl_card.Visible = true;
            
            //ラベル：登録済みユーザ
            this.lbl_mes1.Visible = false;
            //テキストボックス
            this.tbox_user.Visible = false;
            //ラベル：を削除します
            this.lbl_mes2.Visible = false;

            //ボタン
            this.btn_polling.Enabled = false;
            this.btn_del_user.Enabled = false;
            this.btn_cancel_user.Visible = true;

            //
            this.tbox_user.Text = "";
            this.tbox_user.Enabled = false;
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
            //ラベル：を削除します
            this.lbl_mes2.Visible = true;

            //ボタン
            this.btn_polling.Enabled = true;
            this.btn_del_user.Enabled = true;
            this.btn_cancel_user.Enabled = true;
        }

        //削除
        private void btn_del_user_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("btn_del_user_click");
            if (uid != "0" && user != "")
            {
                int result = 0;
                string sql = "";
                
                //デリート
                sql = "delete from parsonal where uid = '" + uid + "'";
                result = mdb.executeNonQuery(sql);

                //バックアップ
                sql = "insert into timedata_backup select * from timedata where uid = '" + uid + "'";
                result = mdb.executeNonQuery(sql);

                //削除
                sql = "delete from timedata where uid = '" + uid + "'";
                result = mdb.executeNonQuery(sql);

                MessageBox.Show("削除しました。");
            }
            this.Close();
        }
        
        //取消
        private void btn_cancel_user_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("btn_cancel_user_click");
            //フォームクローズ
            this.Close();
        }

        //ロード
        private void DeleteForm_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Load");
            //表示
            this.form_polling_enable();
            this.timer_delete.Enabled = true;
        }

        //クローズ
        private void DeleteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("Close");
            this.timer_delete.Enabled = false;
            this.timer_lock = false;
        }

        private void timer_delete_Tick(object sender, EventArgs e)
        {
            if (nfc.IsCurrentCard && this.timer_lock == false)
            {
                try
                {
                    timer_lock = true;
                    OleDbDataReader reader;

                    byte[] recv;
                    byte[] send = null;
                    //UID
                    send = new byte[] { 0xff, 0xca, 0x00, 0x00 };
                    recv = nfc.SendCommand2(send);
                    uid = BitConverter.ToString(recv).Replace("-", "");
                    Debug.WriteLine("CARD_UID:" + uid);

                    if (uid.Length > 0)
                    {
                        user = "";
                        string sql = "select user from parsonal where uid = '" + uid + "'";
                        reader = mdb.executeQuery(sql);
                        while (reader.Read())
                        {
                            user = (string)reader.GetValue(0);
                        }
                        if (user != "")
                        {
                            this.tbox_user.Text = user;
                            this.timer_delete.Enabled = false;
                            this.form_polling_disable();
                        }
                        else
                        {
                            this.tbox_user.Text = "該当なし";
                        }
                    }
                }
                catch (ApplicationException)
                {
                    //null
                    Debug.WriteLine("ApplicationException:DeleteForm");
                }
            }
            //timer_lock = false;
        }

        private void btn_polling_Click(object sender, EventArgs e)
        {
            user = "";
            uid = "";
            this.form_polling_enable();
            timer_lock = false;
            this.timer_delete.Enabled = true;
        }
    }
}
