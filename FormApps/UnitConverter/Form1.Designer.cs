﻿namespace UnitConverter {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.tbNum1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNum2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btChaange = new System.Windows.Forms.Button();
            this.nudNum1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudNum2 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudAnswer = new System.Windows.Forms.NumericUpDown();
            this.btCalc = new System.Windows.Forms.Button();
            this.nudAmari = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnswer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmari)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(28, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "距離換算アプリ";
            // 
            // tbNum1
            // 
            this.tbNum1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbNum1.Location = new System.Drawing.Point(100, 63);
            this.tbNum1.Name = "tbNum1";
            this.tbNum1.Size = new System.Drawing.Size(100, 34);
            this.tbNum1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(30, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "変換前";
            // 
            // tbNum2
            // 
            this.tbNum2.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbNum2.Location = new System.Drawing.Point(100, 175);
            this.tbNum2.Name = "tbNum2";
            this.tbNum2.Size = new System.Drawing.Size(100, 34);
            this.tbNum2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(30, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "変換後";
            // 
            // btChaange
            // 
            this.btChaange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btChaange.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btChaange.Location = new System.Drawing.Point(100, 122);
            this.btChaange.Name = "btChaange";
            this.btChaange.Size = new System.Drawing.Size(84, 30);
            this.btChaange.TabIndex = 3;
            this.btChaange.Text = "変換";
            this.btChaange.UseVisualStyleBackColor = false;
            this.btChaange.Click += new System.EventHandler(this.btChaange_Click);
            // 
            // nudNum1
            // 
            this.nudNum1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nudNum1.Location = new System.Drawing.Point(33, 293);
            this.nudNum1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudNum1.Name = "nudNum1";
            this.nudNum1.Size = new System.Drawing.Size(120, 26);
            this.nudNum1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(175, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "÷";
            // 
            // nudNum2
            // 
            this.nudNum2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nudNum2.Location = new System.Drawing.Point(227, 293);
            this.nudNum2.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudNum2.Name = "nudNum2";
            this.nudNum2.Size = new System.Drawing.Size(120, 26);
            this.nudNum2.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(369, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "=";
            // 
            // nudAnswer
            // 
            this.nudAnswer.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nudAnswer.Location = new System.Drawing.Point(408, 293);
            this.nudAnswer.Name = "nudAnswer";
            this.nudAnswer.Size = new System.Drawing.Size(120, 26);
            this.nudAnswer.TabIndex = 4;
            // 
            // btCalc
            // 
            this.btCalc.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btCalc.Location = new System.Drawing.Point(574, 289);
            this.btCalc.Name = "btCalc";
            this.btCalc.Size = new System.Drawing.Size(82, 32);
            this.btCalc.TabIndex = 5;
            this.btCalc.Text = "計算";
            this.btCalc.UseVisualStyleBackColor = true;
            this.btCalc.Click += new System.EventHandler(this.btCalc_Click);
            // 
            // nudAmari
            // 
            this.nudAmari.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nudAmari.Location = new System.Drawing.Point(408, 362);
            this.nudAmari.Name = "nudAmari";
            this.nudAmari.Size = new System.Drawing.Size(120, 26);
            this.nudAmari.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(360, 366);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "あまり";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(706, 454);
            this.Controls.Add(this.btCalc);
            this.Controls.Add(this.nudAmari);
            this.Controls.Add(this.nudAnswer);
            this.Controls.Add(this.nudNum2);
            this.Controls.Add(this.nudNum1);
            this.Controls.Add(this.btChaange);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNum2);
            this.Controls.Add(this.tbNum1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nudNum1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnswer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmari)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNum1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNum2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btChaange;
        private System.Windows.Forms.NumericUpDown nudNum1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudNum2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudAnswer;
        private System.Windows.Forms.Button btCalc;
        private System.Windows.Forms.NumericUpDown nudAmari;
        private System.Windows.Forms.Label label6;
    }
}

