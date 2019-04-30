namespace nfc_time_recorder
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_regist = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.lbl_timer2 = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_output_csv = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_csv_user = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_csv_time = new System.Windows.Forms.ToolStripMenuItem();
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.menu_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.バージョン情報ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_user_add = new System.Windows.Forms.ToolStripMenuItem();
            this.ユーザー削除ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.menu_user_del = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_version = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sttl_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lbl_timer1 = new System.Windows.Forms.Label();
            this.timer_add = new System.Windows.Forms.Timer(this.components);
            this.timer_interval = new System.Windows.Forms.Timer(this.components);
            this.timer_user_interval = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_regist
            // 
            this.btn_regist.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_regist.Location = new System.Drawing.Point(334, 320);
            this.btn_regist.Name = "btn_regist";
            this.btn_regist.Size = new System.Drawing.Size(132, 46);
            this.btn_regist.TabIndex = 0;
            this.btn_regist.Text = "登録";
            this.btn_regist.UseVisualStyleBackColor = true;
            this.btn_regist.Click += new System.EventHandler(this.btn_regist_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_delete.Location = new System.Drawing.Point(472, 320);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(132, 46);
            this.btn_delete.TabIndex = 1;
            this.btn_delete.Text = "削除";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // lbl_timer2
            // 
            this.lbl_timer2.AutoSize = true;
            this.lbl_timer2.Font = new System.Drawing.Font("ＭＳ ゴシック", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_timer2.Location = new System.Drawing.Point(93, 162);
            this.lbl_timer2.Name = "lbl_timer2";
            this.lbl_timer2.Size = new System.Drawing.Size(434, 97);
            this.lbl_timer2.TabIndex = 2;
            this.lbl_timer2.Text = "12:34:56";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("ＭＳ ゴシック", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_name.Location = new System.Drawing.Point(12, 45);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(212, 37);
            this.lbl_name.TabIndex = 3;
            this.lbl_name.Text = "テスト太郎";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.バージョン情報ToolStripMenuItem,
            this.ヘルプToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(616, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_output_csv,
            this.終了ToolStripMenuItem,
            this.menu_exit});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ファイルToolStripMenuItem.Text = "ファイル";
            // 
            // menu_output_csv
            // 
            this.menu_output_csv.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_csv_user,
            this.menu_csv_time});
            this.menu_output_csv.Name = "menu_output_csv";
            this.menu_output_csv.Size = new System.Drawing.Size(118, 22);
            this.menu_output_csv.Text = "CSV出力";
            // 
            // menu_csv_user
            // 
            this.menu_csv_user.Name = "menu_csv_user";
            this.menu_csv_user.Size = new System.Drawing.Size(102, 22);
            this.menu_csv_user.Text = "ユーザ";
            this.menu_csv_user.Click += new System.EventHandler(this.menu_csv_user_Click);
            // 
            // menu_csv_time
            // 
            this.menu_csv_time.Name = "menu_csv_time";
            this.menu_csv_time.Size = new System.Drawing.Size(102, 22);
            this.menu_csv_time.Text = "時間";
            this.menu_csv_time.Click += new System.EventHandler(this.menu_csv_time_Click);
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(115, 6);
            // 
            // menu_exit
            // 
            this.menu_exit.Name = "menu_exit";
            this.menu_exit.Size = new System.Drawing.Size(118, 22);
            this.menu_exit.Text = "終了";
            this.menu_exit.Click += new System.EventHandler(this.menu_exit_Click);
            // 
            // バージョン情報ToolStripMenuItem
            // 
            this.バージョン情報ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_user_add,
            this.ユーザー削除ToolStripMenuItem,
            this.menu_user_del});
            this.バージョン情報ToolStripMenuItem.Name = "バージョン情報ToolStripMenuItem";
            this.バージョン情報ToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.バージョン情報ToolStripMenuItem.Text = "データ";
            // 
            // menu_user_add
            // 
            this.menu_user_add.Name = "menu_user_add";
            this.menu_user_add.Size = new System.Drawing.Size(98, 22);
            this.menu_user_add.Text = "登録";
            this.menu_user_add.Click += new System.EventHandler(this.menu_user_add_Click);
            // 
            // ユーザー削除ToolStripMenuItem
            // 
            this.ユーザー削除ToolStripMenuItem.Name = "ユーザー削除ToolStripMenuItem";
            this.ユーザー削除ToolStripMenuItem.Size = new System.Drawing.Size(95, 6);
            // 
            // menu_user_del
            // 
            this.menu_user_del.Name = "menu_user_del";
            this.menu_user_del.Size = new System.Drawing.Size(98, 22);
            this.menu_user_del.Text = "削除";
            this.menu_user_del.Click += new System.EventHandler(this.menu_user_del_Click);
            // 
            // ヘルプToolStripMenuItem
            // 
            this.ヘルプToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_version});
            this.ヘルプToolStripMenuItem.Name = "ヘルプToolStripMenuItem";
            this.ヘルプToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.ヘルプToolStripMenuItem.Text = "ヘルプ";
            // 
            // menu_version
            // 
            this.menu_version.Name = "menu_version";
            this.menu_version.Size = new System.Drawing.Size(142, 22);
            this.menu_version.Text = "バージョン情報";
            this.menu_version.Click += new System.EventHandler(this.menu_version_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sttl_status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 369);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(616, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sttl_status
            // 
            this.sttl_status.Name = "sttl_status";
            this.sttl_status.Size = new System.Drawing.Size(118, 17);
            this.sttl_status.Text = "toolStripStatusLabel1";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lbl_timer1
            // 
            this.lbl_timer1.AutoSize = true;
            this.lbl_timer1.Font = new System.Drawing.Font("ＭＳ ゴシック", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_timer1.Location = new System.Drawing.Point(12, 110);
            this.lbl_timer1.Name = "lbl_timer1";
            this.lbl_timer1.Size = new System.Drawing.Size(260, 48);
            this.lbl_timer1.TabIndex = 7;
            this.lbl_timer1.Text = "2017/01/02";
            // 
            // timer_add
            // 
            this.timer_add.Tick += new System.EventHandler(this.timer_add_Tick);
            // 
            // timer_interval
            // 
            this.timer_interval.Interval = 1000;
            this.timer_interval.Tick += new System.EventHandler(this.timer_interval_Tick);
            // 
            // timer_user_interval
            // 
            this.timer_user_interval.Interval = 1000;
            this.timer_user_interval.Tick += new System.EventHandler(this.timer_user_interval_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 391);
            this.Controls.Add(this.lbl_timer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.lbl_timer2);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_regist);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "NFCを使ったタイムレコーダー";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_regist;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Label lbl_timer2;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_output_csv;
        private System.Windows.Forms.ToolStripSeparator 終了ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_exit;
        private System.Windows.Forms.ToolStripMenuItem バージョン情報ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sttl_status;
        private System.Windows.Forms.ToolStripMenuItem menu_user_add;
        private System.Windows.Forms.ToolStripSeparator ユーザー削除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_user_del;
        private System.Windows.Forms.ToolStripMenuItem ヘルプToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_version;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lbl_timer1;
        private System.Windows.Forms.Timer timer_add;
        private System.Windows.Forms.Timer timer_interval;
        private System.Windows.Forms.Timer timer_user_interval;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem menu_csv_user;
        private System.Windows.Forms.ToolStripMenuItem menu_csv_time;
    }
}

