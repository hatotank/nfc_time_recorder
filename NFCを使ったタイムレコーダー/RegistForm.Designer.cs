namespace nfc_time_recorder
{
    partial class RegistForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbl_1 = new System.Windows.Forms.Label();
            this.lbl_2 = new System.Windows.Forms.Label();
            this.lbl_3 = new System.Windows.Forms.Label();
            this.lbl_4 = new System.Windows.Forms.Label();
            this.lbl_15 = new System.Windows.Forms.Label();
            this.lbl_mes1 = new System.Windows.Forms.Label();
            this.tbox_user = new System.Windows.Forms.TextBox();
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_5 = new System.Windows.Forms.Label();
            this.lbl_11 = new System.Windows.Forms.Label();
            this.lbl_12 = new System.Windows.Forms.Label();
            this.lbl_13 = new System.Windows.Forms.Label();
            this.lbl_14 = new System.Windows.Forms.Label();
            this.btn_regist_user = new System.Windows.Forms.Button();
            this.btn_cancel_user = new System.Windows.Forms.Button();
            this.lbl_card = new System.Windows.Forms.Label();
            this.btn_polling = new System.Windows.Forms.Button();
            this.timer_regist = new System.Windows.Forms.Timer(this.components);
            this.tlp.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_1
            // 
            this.lbl_1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_1.AutoSize = true;
            this.lbl_1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbl_1.Location = new System.Drawing.Point(4, 6);
            this.lbl_1.Name = "lbl_1";
            this.lbl_1.Size = new System.Drawing.Size(34, 15);
            this.lbl_1.TabIndex = 1;
            this.lbl_1.Text = "UID";
            // 
            // lbl_2
            // 
            this.lbl_2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_2.AutoSize = true;
            this.lbl_2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lbl_2.Location = new System.Drawing.Point(4, 33);
            this.lbl_2.Name = "lbl_2";
            this.lbl_2.Size = new System.Drawing.Size(31, 15);
            this.lbl_2.TabIndex = 2;
            this.lbl_2.Text = "PMm";
            // 
            // lbl_3
            // 
            this.lbl_3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_3.AutoSize = true;
            this.lbl_3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lbl_3.Location = new System.Drawing.Point(4, 60);
            this.lbl_3.Name = "lbl_3";
            this.lbl_3.Size = new System.Drawing.Size(55, 15);
            this.lbl_3.TabIndex = 3;
            this.lbl_3.Text = "識別ID";
            // 
            // lbl_4
            // 
            this.lbl_4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_4.AutoSize = true;
            this.lbl_4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lbl_4.Location = new System.Drawing.Point(4, 87);
            this.lbl_4.Name = "lbl_4";
            this.lbl_4.Size = new System.Drawing.Size(87, 15);
            this.lbl_4.TabIndex = 4;
            this.lbl_4.Text = "カード種別";
            // 
            // lbl_15
            // 
            this.lbl_15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_15.AutoSize = true;
            this.lbl_15.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lbl_15.Location = new System.Drawing.Point(112, 115);
            this.lbl_15.Name = "lbl_15";
            this.lbl_15.Size = new System.Drawing.Size(87, 15);
            this.lbl_15.TabIndex = 5;
            this.lbl_15.Text = "カード名称";
            // 
            // lbl_mes1
            // 
            this.lbl_mes1.AutoSize = true;
            this.lbl_mes1.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F);
            this.lbl_mes1.Location = new System.Drawing.Point(12, 9);
            this.lbl_mes1.Name = "lbl_mes1";
            this.lbl_mes1.Size = new System.Drawing.Size(130, 24);
            this.lbl_mes1.TabIndex = 6;
            this.lbl_mes1.Text = "登録ユーザ";
            // 
            // tbox_user
            // 
            this.tbox_user.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F);
            this.tbox_user.Location = new System.Drawing.Point(11, 37);
            this.tbox_user.MaxLength = 16;
            this.tbox_user.Name = "tbox_user";
            this.tbox_user.Size = new System.Drawing.Size(361, 31);
            this.tbox_user.TabIndex = 7;
            // 
            // tlp
            // 
            this.tlp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tlp.AutoSize = true;
            this.tlp.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlp.ColumnCount = 2;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlp.Controls.Add(this.lbl_5, 0, 4);
            this.tlp.Controls.Add(this.lbl_3, 0, 2);
            this.tlp.Controls.Add(this.lbl_4, 0, 3);
            this.tlp.Controls.Add(this.lbl_15, 0, 4);
            this.tlp.Controls.Add(this.lbl_2, 0, 1);
            this.tlp.Controls.Add(this.lbl_1, 0, 0);
            this.tlp.Controls.Add(this.lbl_11, 1, 0);
            this.tlp.Controls.Add(this.lbl_12, 1, 1);
            this.tlp.Controls.Add(this.lbl_13, 1, 2);
            this.tlp.Controls.Add(this.lbl_14, 1, 3);
            this.tlp.Location = new System.Drawing.Point(12, 74);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 5;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp.Size = new System.Drawing.Size(360, 138);
            this.tlp.TabIndex = 8;
            this.tlp.Visible = false;
            // 
            // lbl_5
            // 
            this.lbl_5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_5.AutoSize = true;
            this.lbl_5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lbl_5.Location = new System.Drawing.Point(4, 115);
            this.lbl_5.Name = "lbl_5";
            this.lbl_5.Size = new System.Drawing.Size(87, 15);
            this.lbl_5.TabIndex = 10;
            this.lbl_5.Text = "カード名称";
            // 
            // lbl_11
            // 
            this.lbl_11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_11.AutoSize = true;
            this.lbl_11.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_11.Location = new System.Drawing.Point(112, 6);
            this.lbl_11.Name = "lbl_11";
            this.lbl_11.Size = new System.Drawing.Size(31, 15);
            this.lbl_11.TabIndex = 6;
            this.lbl_11.Text = "UID";
            // 
            // lbl_12
            // 
            this.lbl_12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_12.AutoSize = true;
            this.lbl_12.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lbl_12.Location = new System.Drawing.Point(112, 33);
            this.lbl_12.Name = "lbl_12";
            this.lbl_12.Size = new System.Drawing.Size(31, 15);
            this.lbl_12.TabIndex = 7;
            this.lbl_12.Text = "PMm";
            // 
            // lbl_13
            // 
            this.lbl_13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_13.AutoSize = true;
            this.lbl_13.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lbl_13.Location = new System.Drawing.Point(112, 60);
            this.lbl_13.Name = "lbl_13";
            this.lbl_13.Size = new System.Drawing.Size(55, 15);
            this.lbl_13.TabIndex = 8;
            this.lbl_13.Text = "識別ID";
            // 
            // lbl_14
            // 
            this.lbl_14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_14.AutoSize = true;
            this.lbl_14.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.lbl_14.Location = new System.Drawing.Point(112, 87);
            this.lbl_14.Name = "lbl_14";
            this.lbl_14.Size = new System.Drawing.Size(87, 15);
            this.lbl_14.TabIndex = 9;
            this.lbl_14.Text = "カード種別";
            // 
            // btn_regist_user
            // 
            this.btn_regist_user.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F);
            this.btn_regist_user.Location = new System.Drawing.Point(145, 218);
            this.btn_regist_user.Name = "btn_regist_user";
            this.btn_regist_user.Size = new System.Drawing.Size(92, 34);
            this.btn_regist_user.TabIndex = 10;
            this.btn_regist_user.Text = "登録";
            this.btn_regist_user.UseVisualStyleBackColor = true;
            this.btn_regist_user.Click += new System.EventHandler(this.btn_regist_user_Click);
            // 
            // btn_cancel_user
            // 
            this.btn_cancel_user.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F);
            this.btn_cancel_user.Location = new System.Drawing.Point(279, 218);
            this.btn_cancel_user.Name = "btn_cancel_user";
            this.btn_cancel_user.Size = new System.Drawing.Size(92, 34);
            this.btn_cancel_user.TabIndex = 11;
            this.btn_cancel_user.Text = "取消";
            this.btn_cancel_user.UseVisualStyleBackColor = true;
            this.btn_cancel_user.Click += new System.EventHandler(this.btn_cancel_user_Click);
            // 
            // lbl_card
            // 
            this.lbl_card.AutoSize = true;
            this.lbl_card.Font = new System.Drawing.Font("ＭＳ ゴシック", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_card.Location = new System.Drawing.Point(8, 37);
            this.lbl_card.Name = "lbl_card";
            this.lbl_card.Size = new System.Drawing.Size(356, 96);
            this.lbl_card.TabIndex = 12;
            this.lbl_card.Text = "カードをセット\r\nしてください";
            this.lbl_card.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_polling
            // 
            this.btn_polling.AutoSize = true;
            this.btn_polling.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_polling.Location = new System.Drawing.Point(11, 218);
            this.btn_polling.Name = "btn_polling";
            this.btn_polling.Size = new System.Drawing.Size(92, 34);
            this.btn_polling.TabIndex = 13;
            this.btn_polling.Text = "再取得";
            this.btn_polling.UseVisualStyleBackColor = true;
            this.btn_polling.Click += new System.EventHandler(this.btn_polling_Click);
            // 
            // timer_regist
            // 
            this.timer_regist.Interval = 300;
            this.timer_regist.Tick += new System.EventHandler(this.timer_regist_Tick);
            // 
            // RegistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.btn_polling);
            this.Controls.Add(this.lbl_card);
            this.Controls.Add(this.btn_cancel_user);
            this.Controls.Add(this.btn_regist_user);
            this.Controls.Add(this.tlp);
            this.Controls.Add(this.tbox_user);
            this.Controls.Add(this.lbl_mes1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "登録";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegistForm_FormClosing);
            this.Load += new System.EventHandler(this.RegistForm_Load);
            this.tlp.ResumeLayout(false);
            this.tlp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_1;
        private System.Windows.Forms.Label lbl_2;
        private System.Windows.Forms.Label lbl_3;
        private System.Windows.Forms.Label lbl_4;
        private System.Windows.Forms.Label lbl_15;
        private System.Windows.Forms.Label lbl_mes1;
        private System.Windows.Forms.TextBox tbox_user;
        private System.Windows.Forms.TableLayoutPanel tlp;
        private System.Windows.Forms.Button btn_regist_user;
        private System.Windows.Forms.Button btn_cancel_user;
        private System.Windows.Forms.Label lbl_card;
        private System.Windows.Forms.Button btn_polling;
        private System.Windows.Forms.Label lbl_5;
        private System.Windows.Forms.Label lbl_11;
        private System.Windows.Forms.Label lbl_12;
        private System.Windows.Forms.Label lbl_13;
        private System.Windows.Forms.Label lbl_14;
        private System.Windows.Forms.Timer timer_regist;
    }
}