namespace nfc_time_recorder
{
    partial class DeleteForm
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
            this.lbl_mes1 = new System.Windows.Forms.Label();
            this.lbl_mes2 = new System.Windows.Forms.Label();
            this.btn_del_user = new System.Windows.Forms.Button();
            this.btn_cancel_user = new System.Windows.Forms.Button();
            this.tbox_user = new System.Windows.Forms.TextBox();
            this.lbl_card = new System.Windows.Forms.Label();
            this.timer_delete = new System.Windows.Forms.Timer(this.components);
            this.btn_polling = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_mes1
            // 
            this.lbl_mes1.AutoSize = true;
            this.lbl_mes1.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_mes1.Location = new System.Drawing.Point(12, 9);
            this.lbl_mes1.Name = "lbl_mes1";
            this.lbl_mes1.Size = new System.Drawing.Size(178, 24);
            this.lbl_mes1.TabIndex = 0;
            this.lbl_mes1.Text = "登録済みユーザ";
            // 
            // lbl_mes2
            // 
            this.lbl_mes2.AutoSize = true;
            this.lbl_mes2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_mes2.Location = new System.Drawing.Point(13, 71);
            this.lbl_mes2.Name = "lbl_mes2";
            this.lbl_mes2.Size = new System.Drawing.Size(103, 15);
            this.lbl_mes2.TabIndex = 1;
            this.lbl_mes2.Text = "を削除します";
            // 
            // btn_del_user
            // 
            this.btn_del_user.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_del_user.Location = new System.Drawing.Point(145, 218);
            this.btn_del_user.Name = "btn_del_user";
            this.btn_del_user.Size = new System.Drawing.Size(92, 34);
            this.btn_del_user.TabIndex = 2;
            this.btn_del_user.Text = "削除";
            this.btn_del_user.UseVisualStyleBackColor = true;
            this.btn_del_user.Click += new System.EventHandler(this.btn_del_user_Click);
            // 
            // btn_cancel_user
            // 
            this.btn_cancel_user.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_cancel_user.Location = new System.Drawing.Point(279, 218);
            this.btn_cancel_user.Name = "btn_cancel_user";
            this.btn_cancel_user.Size = new System.Drawing.Size(92, 34);
            this.btn_cancel_user.TabIndex = 3;
            this.btn_cancel_user.Text = "取消";
            this.btn_cancel_user.UseVisualStyleBackColor = true;
            this.btn_cancel_user.Click += new System.EventHandler(this.btn_cancel_user_Click);
            // 
            // tbox_user
            // 
            this.tbox_user.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbox_user.Location = new System.Drawing.Point(11, 37);
            this.tbox_user.MaxLength = 16;
            this.tbox_user.Name = "tbox_user";
            this.tbox_user.Size = new System.Drawing.Size(361, 31);
            this.tbox_user.TabIndex = 4;
            // 
            // lbl_card
            // 
            this.lbl_card.AutoSize = true;
            this.lbl_card.Font = new System.Drawing.Font("ＭＳ ゴシック", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_card.Location = new System.Drawing.Point(8, 37);
            this.lbl_card.Name = "lbl_card";
            this.lbl_card.Size = new System.Drawing.Size(356, 96);
            this.lbl_card.TabIndex = 5;
            this.lbl_card.Text = "カードをセット\r\nしてください";
            this.lbl_card.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer_delete
            // 
            this.timer_delete.Tick += new System.EventHandler(this.timer_delete_Tick);
            // 
            // btn_polling
            // 
            this.btn_polling.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_polling.Location = new System.Drawing.Point(11, 218);
            this.btn_polling.Name = "btn_polling";
            this.btn_polling.Size = new System.Drawing.Size(92, 34);
            this.btn_polling.TabIndex = 8;
            this.btn_polling.Text = "再取得";
            this.btn_polling.UseVisualStyleBackColor = true;
            this.btn_polling.Click += new System.EventHandler(this.btn_polling_Click);
            // 
            // DeleteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.btn_polling);
            this.Controls.Add(this.lbl_card);
            this.Controls.Add(this.tbox_user);
            this.Controls.Add(this.btn_cancel_user);
            this.Controls.Add(this.btn_del_user);
            this.Controls.Add(this.lbl_mes2);
            this.Controls.Add(this.lbl_mes1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeleteForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "削除";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeleteForm_FormClosing);
            this.Load += new System.EventHandler(this.DeleteForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_mes1;
        private System.Windows.Forms.Label lbl_mes2;
        private System.Windows.Forms.Button btn_del_user;
        private System.Windows.Forms.Button btn_cancel_user;
        private System.Windows.Forms.TextBox tbox_user;
        private System.Windows.Forms.Label lbl_card;
        private System.Windows.Forms.Timer timer_delete;
        private System.Windows.Forms.Button btn_polling;
    }
}