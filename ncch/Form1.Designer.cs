namespace ncch
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.serch = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.檔案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.課程更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.儲存課表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.匯入課表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.課表重設ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加退選ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.依序號加選ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.依序號退選ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.匯入必修ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看已選課程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.課表設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxKeepFromCoinsedance = new System.Windows.Forms.CheckBox();
            this.comboBoxShow = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDebug = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 71);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 15;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(553, 690);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(237, 52);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "課表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(600, 128);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1171, 634);
            this.dataGridView1.TabIndex = 14;
            // 
            // serch
            // 
            this.serch.Location = new System.Drawing.Point(1169, 71);
            this.serch.Margin = new System.Windows.Forms.Padding(4);
            this.serch.Name = "serch";
            this.serch.Size = new System.Drawing.Size(100, 29);
            this.serch.TabIndex = 15;
            this.serch.Text = "查詢";
            this.serch.UseVisualStyleBackColor = true;
            this.serch.Click += new System.EventHandler(this.serch_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.檔案ToolStripMenuItem,
            this.加退選ToolStripMenuItem,
            this.設定ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1805, 27);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 檔案ToolStripMenuItem
            // 
            this.檔案ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.課程更新ToolStripMenuItem,
            this.儲存課表ToolStripMenuItem,
            this.匯入課表ToolStripMenuItem,
            this.課表重設ToolStripMenuItem});
            this.檔案ToolStripMenuItem.Name = "檔案ToolStripMenuItem";
            this.檔案ToolStripMenuItem.Size = new System.Drawing.Size(51, 23);
            this.檔案ToolStripMenuItem.Text = "檔案";
            // 
            // 課程更新ToolStripMenuItem
            // 
            this.課程更新ToolStripMenuItem.Name = "課程更新ToolStripMenuItem";
            this.課程更新ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.課程更新ToolStripMenuItem.Text = "課程更新";
            this.課程更新ToolStripMenuItem.Click += new System.EventHandler(this.課程更新ToolStripMenuItem_Click);
            // 
            // 儲存課表ToolStripMenuItem
            // 
            this.儲存課表ToolStripMenuItem.Name = "儲存課表ToolStripMenuItem";
            this.儲存課表ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.儲存課表ToolStripMenuItem.Text = "儲存課表";
            this.儲存課表ToolStripMenuItem.Click += new System.EventHandler(this.儲存課表ToolStripMenuItem_Click);
            // 
            // 匯入課表ToolStripMenuItem
            // 
            this.匯入課表ToolStripMenuItem.Name = "匯入課表ToolStripMenuItem";
            this.匯入課表ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.匯入課表ToolStripMenuItem.Text = "匯入課表";
            this.匯入課表ToolStripMenuItem.Click += new System.EventHandler(this.匯入課表ToolStripMenuItem_Click);
            // 
            // 課表重設ToolStripMenuItem
            // 
            this.課表重設ToolStripMenuItem.Name = "課表重設ToolStripMenuItem";
            this.課表重設ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.課表重設ToolStripMenuItem.Text = "課表重設";
            this.課表重設ToolStripMenuItem.Click += new System.EventHandler(this.課表重設ToolStripMenuItem_Click);
            // 
            // 加退選ToolStripMenuItem
            // 
            this.加退選ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.依序號加選ToolStripMenuItem,
            this.依序號退選ToolStripMenuItem,
            this.匯入必修ToolStripMenuItem,
            this.查看已選課程ToolStripMenuItem});
            this.加退選ToolStripMenuItem.Name = "加退選ToolStripMenuItem";
            this.加退選ToolStripMenuItem.Size = new System.Drawing.Size(51, 23);
            this.加退選ToolStripMenuItem.Text = "課程";
            // 
            // 依序號加選ToolStripMenuItem
            // 
            this.依序號加選ToolStripMenuItem.Name = "依序號加選ToolStripMenuItem";
            this.依序號加選ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.依序號加選ToolStripMenuItem.Text = "依序號加選";
            this.依序號加選ToolStripMenuItem.Click += new System.EventHandler(this.依序號加選ToolStripMenuItem_Click);
            // 
            // 依序號退選ToolStripMenuItem
            // 
            this.依序號退選ToolStripMenuItem.Name = "依序號退選ToolStripMenuItem";
            this.依序號退選ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.依序號退選ToolStripMenuItem.Text = "依序號退選";
            this.依序號退選ToolStripMenuItem.Click += new System.EventHandler(this.依序號退選ToolStripMenuItem_Click);
            // 
            // 匯入必修ToolStripMenuItem
            // 
            this.匯入必修ToolStripMenuItem.Name = "匯入必修ToolStripMenuItem";
            this.匯入必修ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.匯入必修ToolStripMenuItem.Text = "匯入必修";
            this.匯入必修ToolStripMenuItem.Click += new System.EventHandler(this.匯入必修ToolStripMenuItem_Click);
            // 
            // 查看已選課程ToolStripMenuItem
            // 
            this.查看已選課程ToolStripMenuItem.Name = "查看已選課程ToolStripMenuItem";
            this.查看已選課程ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.查看已選課程ToolStripMenuItem.Text = "查看已選課程";
            this.查看已選課程ToolStripMenuItem.Click += new System.EventHandler(this.查看已選課程ToolStripMenuItem_Click);
            // 
            // 設定ToolStripMenuItem
            // 
            this.設定ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.課表設定ToolStripMenuItem});
            this.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            this.設定ToolStripMenuItem.Size = new System.Drawing.Size(51, 23);
            this.設定ToolStripMenuItem.Text = "設定";
            // 
            // 課表設定ToolStripMenuItem
            // 
            this.課表設定ToolStripMenuItem.Name = "課表設定ToolStripMenuItem";
            this.課表設定ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.課表設定ToolStripMenuItem.Text = "課表設定";
            this.課表設定ToolStripMenuItem.Click += new System.EventHandler(this.課表設定ToolStripMenuItem_Click);
            // 
            // checkBoxKeepFromCoinsedance
            // 
            this.checkBoxKeepFromCoinsedance.AutoSize = true;
            this.checkBoxKeepFromCoinsedance.Location = new System.Drawing.Point(1003, 76);
            this.checkBoxKeepFromCoinsedance.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxKeepFromCoinsedance.Name = "checkBoxKeepFromCoinsedance";
            this.checkBoxKeepFromCoinsedance.Size = new System.Drawing.Size(119, 19);
            this.checkBoxKeepFromCoinsedance.TabIndex = 16;
            this.checkBoxKeepFromCoinsedance.Text = "避免撞課時間";
            this.checkBoxKeepFromCoinsedance.UseVisualStyleBackColor = true;
            // 
            // comboBoxShow
            // 
            this.comboBoxShow.FormattingEnabled = true;
            this.comboBoxShow.Location = new System.Drawing.Point(760, 71);
            this.comboBoxShow.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxShow.Name = "comboBoxShow";
            this.comboBoxShow.Size = new System.Drawing.Size(217, 23);
            this.comboBoxShow.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(639, 71);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "查看系所";
            // 
            // btnDebug
            // 
            this.btnDebug.Enabled = false;
            this.btnDebug.Location = new System.Drawing.Point(1696, 787);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(75, 23);
            this.btnDebug.TabIndex = 19;
            this.btnDebug.Text = "debug";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Visible = false;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1805, 822);
            this.Controls.Add(this.btnDebug);
            this.Controls.Add(this.checkBoxKeepFromCoinsedance);
            this.Controls.Add(this.serch);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxShow);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "NCKU 選課小幫手";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button serch;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 檔案ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加退選ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 依序號加選ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 依序號退選ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 匯入必修ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 課表設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看已選課程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 課程更新ToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxKeepFromCoinsedance;
        private System.Windows.Forms.ComboBox comboBoxShow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem 儲存課表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 匯入課表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 課表重設ToolStripMenuItem;
        private System.Windows.Forms.Button btnDebug;
    }
}

