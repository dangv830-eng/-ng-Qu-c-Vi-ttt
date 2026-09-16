namespace Bài_4._3_FORM_CALCULATOR
{
    partial class Form1
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
            this.btnC = new System.Windows.Forms.Button();
            this.btnBang = new System.Windows.Forms.Button();
            this.btnChia = new System.Windows.Forms.Button();
            this.btnNhan = new System.Windows.Forms.Button();
            this.btnTru = new System.Windows.Forms.Button();
            this.btnCong = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnC
            // 
            this.btnC.Location = new System.Drawing.Point(484, 239);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(75, 23);
            this.btnC.TabIndex = 50;
            this.btnC.Text = "C";
            this.btnC.UseVisualStyleBackColor = true;
            this.btnC.Click += new System.EventHandler(this.btnC_Click);
            // 
            // btnBang
            // 
            this.btnBang.Location = new System.Drawing.Point(403, 239);
            this.btnBang.Name = "btnBang";
            this.btnBang.Size = new System.Drawing.Size(75, 23);
            this.btnBang.TabIndex = 49;
            this.btnBang.Text = "=";
            this.btnBang.UseVisualStyleBackColor = true;
            // 
            // btnChia
            // 
            this.btnChia.Location = new System.Drawing.Point(322, 239);
            this.btnChia.Name = "btnChia";
            this.btnChia.Size = new System.Drawing.Size(75, 23);
            this.btnChia.TabIndex = 48;
            this.btnChia.Text = "/";
            this.btnChia.UseVisualStyleBackColor = true;
            this.btnChia.Click += new System.EventHandler(this.Operator_Click);
            // 
            // btnNhan
            // 
            this.btnNhan.Location = new System.Drawing.Point(241, 239);
            this.btnNhan.Name = "btnNhan";
            this.btnNhan.Size = new System.Drawing.Size(75, 23);
            this.btnNhan.TabIndex = 47;
            this.btnNhan.Text = "*";
            this.btnNhan.UseVisualStyleBackColor = true;
            this.btnNhan.Click += new System.EventHandler(this.Operator_Click);
            // 
            // btnTru
            // 
            this.btnTru.Location = new System.Drawing.Point(160, 239);
            this.btnTru.Name = "btnTru";
            this.btnTru.Size = new System.Drawing.Size(75, 23);
            this.btnTru.TabIndex = 46;
            this.btnTru.Text = "-";
            this.btnTru.UseVisualStyleBackColor = true;
            this.btnTru.Click += new System.EventHandler(this.Operator_Click);
            // 
            // btnCong
            // 
            this.btnCong.Location = new System.Drawing.Point(79, 239);
            this.btnCong.Name = "btnCong";
            this.btnCong.Size = new System.Drawing.Size(73, 23);
            this.btnCong.TabIndex = 45;
            this.btnCong.Text = "+";
            this.btnCong.UseVisualStyleBackColor = true;
            this.btnCong.Click += new System.EventHandler(this.Operator_Click);
            // 
            // btn9
            // 
            this.btn9.Location = new System.Drawing.Point(79, 187);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(73, 23);
            this.btn9.TabIndex = 44;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn8
            // 
            this.btn8.Location = new System.Drawing.Point(727, 158);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(73, 23);
            this.btn8.TabIndex = 43;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn7
            // 
            this.btn7.Location = new System.Drawing.Point(646, 158);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(73, 23);
            this.btn7.TabIndex = 42;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn6
            // 
            this.btn6.Location = new System.Drawing.Point(565, 158);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(73, 23);
            this.btn6.TabIndex = 41;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn5
            // 
            this.btn5.Location = new System.Drawing.Point(484, 158);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(73, 23);
            this.btn5.TabIndex = 40;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn4
            // 
            this.btn4.Location = new System.Drawing.Point(403, 158);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(73, 23);
            this.btn4.TabIndex = 39;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(322, 158);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(73, 23);
            this.btn3.TabIndex = 38;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(241, 158);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(73, 23);
            this.btn2.TabIndex = 37;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(160, 158);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(73, 23);
            this.btn1.TabIndex = 36;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn0
            // 
            this.btn0.Location = new System.Drawing.Point(79, 158);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(73, 23);
            this.btn0.TabIndex = 35;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // txtDisplay
            // 
            this.txtDisplay.Location = new System.Drawing.Point(79, 300);
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.Size = new System.Drawing.Size(186, 22);
            this.txtDisplay.TabIndex = 34;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 481);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnBang);
            this.Controls.Add(this.btnChia);
            this.Controls.Add(this.btnNhan);
            this.Controls.Add(this.btnTru);
            this.Controls.Add(this.btnCong);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.txtDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Click += new System.EventHandler(this.Operator_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Button btnBang;
        private System.Windows.Forms.Button btnChia;
        private System.Windows.Forms.Button btnNhan;
        private System.Windows.Forms.Button btnTru;
        private System.Windows.Forms.Button btnCong;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.TextBox txtDisplay;
    }
}

