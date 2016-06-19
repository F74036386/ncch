namespace ncch
{
    partial class tableSettingForm
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
            this.labelNessarry = new System.Windows.Forms.Label();
            this.labelChoose = new System.Windows.Forms.Label();
            this.labelGeneral = new System.Windows.Forms.Label();
            this.buttonNessarry = new System.Windows.Forms.Button();
            this.buttonChoose = new System.Windows.Forms.Button();
            this.buttonGeneral = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // labelNessarry
            // 
            this.labelNessarry.AutoSize = true;
            this.labelNessarry.Location = new System.Drawing.Point(38, 60);
            this.labelNessarry.Name = "labelNessarry";
            this.labelNessarry.Size = new System.Drawing.Size(53, 12);
            this.labelNessarry.TabIndex = 0;
            this.labelNessarry.Text = "必修底色";
            // 
            // labelChoose
            // 
            this.labelChoose.AutoSize = true;
            this.labelChoose.Location = new System.Drawing.Point(38, 135);
            this.labelChoose.Name = "labelChoose";
            this.labelChoose.Size = new System.Drawing.Size(53, 12);
            this.labelChoose.TabIndex = 1;
            this.labelChoose.Text = "選修底色";
            // 
            // labelGeneral
            // 
            this.labelGeneral.AutoSize = true;
            this.labelGeneral.Location = new System.Drawing.Point(38, 212);
            this.labelGeneral.Name = "labelGeneral";
            this.labelGeneral.Size = new System.Drawing.Size(53, 12);
            this.labelGeneral.TabIndex = 2;
            this.labelGeneral.Text = "通識底色";
            // 
            // buttonNessarry
            // 
            this.buttonNessarry.Location = new System.Drawing.Point(180, 55);
            this.buttonNessarry.Name = "buttonNessarry";
            this.buttonNessarry.Size = new System.Drawing.Size(75, 23);
            this.buttonNessarry.TabIndex = 3;
            this.buttonNessarry.Text = "修改顏色";
            this.buttonNessarry.UseVisualStyleBackColor = true;
            this.buttonNessarry.Click += new System.EventHandler(this.buttonNessarry_Click);
            // 
            // buttonChoose
            // 
            this.buttonChoose.Location = new System.Drawing.Point(180, 130);
            this.buttonChoose.Name = "buttonChoose";
            this.buttonChoose.Size = new System.Drawing.Size(75, 23);
            this.buttonChoose.TabIndex = 4;
            this.buttonChoose.Text = "修改顏色";
            this.buttonChoose.UseVisualStyleBackColor = true;
            this.buttonChoose.Click += new System.EventHandler(this.buttonChoose_Click);
            // 
            // buttonGeneral
            // 
            this.buttonGeneral.Location = new System.Drawing.Point(180, 207);
            this.buttonGeneral.Name = "buttonGeneral";
            this.buttonGeneral.Size = new System.Drawing.Size(75, 23);
            this.buttonGeneral.TabIndex = 5;
            this.buttonGeneral.Text = "修改顏色";
            this.buttonGeneral.UseVisualStyleBackColor = true;
            this.buttonGeneral.Click += new System.EventHandler(this.buttonGeneral_Click);
            // 
            // tableSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 275);
            this.Controls.Add(this.buttonGeneral);
            this.Controls.Add(this.buttonChoose);
            this.Controls.Add(this.buttonNessarry);
            this.Controls.Add(this.labelGeneral);
            this.Controls.Add(this.labelChoose);
            this.Controls.Add(this.labelNessarry);
            this.Name = "tableSettingForm";
            this.Text = "課表設定";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNessarry;
        private System.Windows.Forms.Label labelChoose;
        private System.Windows.Forms.Label labelGeneral;
        private System.Windows.Forms.Button buttonNessarry;
        private System.Windows.Forms.Button buttonChoose;
        private System.Windows.Forms.Button buttonGeneral;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}