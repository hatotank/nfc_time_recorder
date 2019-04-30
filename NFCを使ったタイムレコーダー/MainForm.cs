using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace nfc_time_recorder
{
    public partial class MainForm : Form
    {
        public Mdb mdb;
        public NfcMain nfc;
        private bool timer_lock = false;
        private string uid;
        private List<UserInval> user_list = new List<UserInval>();
        private bool app_failed = false;
        private string db_path = "";

        public MainForm()
        {
            InitializeComponent();
            this.lbl_name.Text = "";
            this.timer_add.Enabled = true;
            this.timer_user_interval.Enabled = true;
            this.sttl_status.Text = "";

            string[] arguments = System.Environment.GetCommandLineArgs();
            if (arguments.Length > 1)
            {
                db_path = arguments[1];
            }
            else
            {
                db_path = "time.mdb";
            }

            mdb = new Mdb(db_path, Mdb.MDB_VER_JET);
            nfc = new NfcMain();
            if (!mdb.DbOpen())
            {
                Debug.WriteLine("INFO:DB failed");
                this.sttl_status.Text = "データベースへの接続失敗";
                app_failed = true;
            }
            if (!nfc.Reader())
            {
                Debug.WriteLine("INFO:failed");
                this.sttl_status.Text = "カードリーダーの初期化に失敗";
                app_failed = true;

            }
            else
            {
                Debug.WriteLine("INFO:Success");
                nfc.StartPolling();
            }
        }

        private void btn_regist_Click(object sender, EventArgs e)
        {
            this.timer_add.Enabled = false;
            RegistForm RegiForm;
            RegiForm = new RegistForm(mdb,nfc);
            RegiForm.ShowDialog();
            RegiForm.Dispose();
            this.timer_add.Enabled = true;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            this.timer_add.Enabled = false;
            DeleteForm delForm;
            delForm = new DeleteForm(mdb,nfc);
            delForm.ShowDialog();
            delForm.Dispose();
            this.timer_add.Enabled = true;
        }

        private void menu_user_add_Click(object sender, EventArgs e)
        {
            this.btn_regist_Click(this, null);
        }

        private void menu_user_del_Click(object sender, EventArgs e)
        {
            this.btn_delete_Click(this, null);
        }

        private void menu_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menu_version_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 1.0.0");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.lbl_timer1.Text = DateTime.Now.ToShortDateString();
            this.lbl_timer2.Text = DateTime.Now.ToLongTimeString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.timer.Enabled = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            nfc.stopPolling();
            nfc.DisConnectReader();
            Debug.WriteLine("INFO:DisConnectReader");
        }

        private void timer_add_Tick(object sender, EventArgs e)
        {
            if (nfc.IsCurrentCard && this.timer_lock == false)
            {
                try
                {
                    int result;
                    string user;
                    OleDbDataReader reader;
                    DateTime addDate;
                    timer_lock = true;
                    byte[] recv;
                    byte[] send = null;
                    //UID
                    send = new byte[] { 0xff, 0xca, 0x00, 0x00 };
                    recv = nfc.SendCommand2(send);
                    uid = BitConverter.ToString(recv).Replace("-", "");
                    Debug.WriteLine("CARD_UID:" + uid);

                    string sql = "select count(1) from parsonal where uid = '" + uid + "'";
                    reader = mdb.executeQuery(sql);
                    reader.Read();
                    result = (int)reader.GetValue(0);
                    if (result > 0)
                    {
                        foreach (UserInval v in user_list)
                        {
                            if (v.uid == uid)
                            {
                                Debug.WriteLine("時間内DB追加無し");
                                return;
                            }
                        }

                        sql = "select user from parsonal where uid = '" + uid + "'";
                        reader = mdb.executeQuery(sql);
                        reader.Read();
                        user = (string)reader.GetValue(0);

                        addDate = DateTime.Now;
                        sql = "select count(1) from timedata where uid = '" + uid + "'";
                        reader = mdb.executeQuery(sql);
                        reader.Read();
                        result = (int)reader.GetValue(0);

                        sql = "insert into timedata values ("
                            + "'" + uid + "',"
                            + (result + 1) + ","
                            + "'" + DateTime.Now + "')";
                        result = mdb.executeNonQuery(sql);
                        if (result > 0)
                        {
                            //正常登録
                            this.lbl_name.Text = user;
                            this.lbl_timer2.Text = addDate.ToLongTimeString();
                            this.lbl_timer2.ForeColor = Color.Red;
                            this.timer.Enabled = false;
                            this.timer_interval.Enabled = true;
                            Debug.WriteLine("正常登録:" + uid);
                            Debug.WriteLine("");

                            user_list.Add(new UserInval(uid, DateTime.Now));
                        }
                    }
                }
                catch (ApplicationException)
                {
                    //null
                    Debug.WriteLine("ApplicationException:MainForm");
                }
            }
            if (nfc.IsReaderRemoved == true)
            {
                this.sttl_status.Text = "カードリーダーが接続されていません";
                app_failed = true;
            }
            else if (nfc.IsNfcFaild == true)
            {
                this.Close();
            }
            else
            {
                if (app_failed == false)
                {
                    this.sttl_status.Text = "ポーリング中";
                }
            }

            timer_lock = false;
        }

        private void timer_interval_Tick(object sender, EventArgs e)
        {
            this.lbl_name.Text = "";
            this.lbl_timer2.ForeColor = Color.Black;
            this.timer.Enabled = true;
            this.timer_interval.Enabled = false;
        }

        //登録インターバル削除
        private void timer_user_interval_Tick(object sender, EventArgs e)
        {
            for (int i = user_list.Count - 1; i >= 0; i--)
            {
                int dtresult = DateTime.Compare(user_list[i].date.AddSeconds(5), DateTime.Now);
                if (dtresult < 0)
                {
                    Debug.WriteLine("コンペア結果:時間過ぎている");
                    user_list.Remove(user_list[i]);
                }
            }
        }

        private void menu_csv_user_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "CSV|*.csv";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                FileStream fs = (FileStream)saveFileDialog.OpenFile();

                AddText(fs, "uid,pmm,cid,ctype,cname,user\r\n");
                string sql = "select * from parsonal";
                OleDbDataReader reader;
                reader = mdb.executeQuery(sql);
                while (reader.Read())
                {
                    AddText(fs, reader.GetValue(0).ToString()
                             + "," + reader.GetValue(1).ToString()
                             + "," + reader.GetValue(2).ToString()
                             + "," + reader.GetValue(3).ToString()
                             + "," + reader.GetValue(4).ToString()
                             + "," + reader.GetValue(5).ToString()
                             + "\r\n"
                    );
                }
                fs.Close();
            }
        }

        private void menu_csv_time_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "CSV|*.csv";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                FileStream fs = (FileStream)saveFileDialog.OpenFile();

                AddText(fs, "uid,renban,time\r\n");
                string sql = "select * from timedata";
                OleDbDataReader reader;
                reader = mdb.executeQuery(sql);
                while (reader.Read())
                {
                    AddText(fs, reader.GetValue(0).ToString()
                             + "," + reader.GetValue(1).ToString()
                             + "," + reader.GetValue(2).ToString()
                             + "\r\n"
                    );
                }
                fs.Close();
            }
        }

        private static void AddText(FileStream fs, string v)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(v);
            fs.Write(info, 0, info.Length);
        }
    }

    public class UserInval
    {
        public string uid {get; set;}
        public DateTime date{get; set;}

        public UserInval(string uid, DateTime date)
        {
            this.uid = uid;
            this.date = date;
        }
    }
}
