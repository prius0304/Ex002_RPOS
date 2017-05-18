namespace XPUPC_Example
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnConn = new System.Windows.Forms.Button();
            this.btnRPOS = new System.Windows.Forms.Button();
            this.btn_Flapsup = new System.Windows.Forms.Button();
            this.btn_Flapsdown = new System.Windows.Forms.Button();
            this.txtState = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtYr = new System.Windows.Forms.TextBox();
            this.txtPr = new System.Windows.Forms.TextBox();
            this.txtRr = new System.Windows.Forms.TextBox();
            this.txtZs = new System.Windows.Forms.TextBox();
            this.txtYs = new System.Windows.Forms.TextBox();
            this.txtXs = new System.Windows.Forms.TextBox();
            this.txtRoll = new System.Windows.Forms.TextBox();
            this.txtYaw = new System.Windows.Forms.TextBox();
            this.txtPitch = new System.Windows.Forms.TextBox();
            this.txtMeter = new System.Windows.Forms.TextBox();
            this.txtElevation = new System.Windows.Forms.TextBox();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.txtLongtitude = new System.Windows.Forms.TextBox();
            this.txtRPOSFreq = new System.Windows.Forms.TextBox();
            this.timerRPOS = new System.Windows.Forms.Timer(this.components);
            this.btnRADR = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConn
            // 
            this.btnConn.Location = new System.Drawing.Point(118, 10);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(75, 23);
            this.btnConn.TabIndex = 0;
            this.btnConn.Text = "Connect";
            this.btnConn.UseVisualStyleBackColor = true;
            this.btnConn.Click += new System.EventHandler(this.btnConn_Click);
            // 
            // btnRPOS
            // 
            this.btnRPOS.Location = new System.Drawing.Point(183, 12);
            this.btnRPOS.Name = "btnRPOS";
            this.btnRPOS.Size = new System.Drawing.Size(75, 23);
            this.btnRPOS.TabIndex = 1;
            this.btnRPOS.Text = "Send";
            this.btnRPOS.UseVisualStyleBackColor = true;
            this.btnRPOS.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btn_Flapsup
            // 
            this.btn_Flapsup.Location = new System.Drawing.Point(577, 12);
            this.btn_Flapsup.Name = "btn_Flapsup";
            this.btn_Flapsup.Size = new System.Drawing.Size(75, 23);
            this.btn_Flapsup.TabIndex = 2;
            this.btn_Flapsup.Text = "Flaps_Up";
            this.btn_Flapsup.UseVisualStyleBackColor = true;
            this.btn_Flapsup.Click += new System.EventHandler(this.btn_Flapsup_Click);
            // 
            // btn_Flapsdown
            // 
            this.btn_Flapsdown.Location = new System.Drawing.Point(577, 41);
            this.btn_Flapsdown.Name = "btn_Flapsdown";
            this.btn_Flapsdown.Size = new System.Drawing.Size(75, 23);
            this.btn_Flapsdown.TabIndex = 3;
            this.btn_Flapsdown.Text = "Flaps_Down";
            this.btn_Flapsdown.UseVisualStyleBackColor = true;
            this.btn_Flapsdown.Click += new System.EventHandler(this.btn_Flapsdown_Click);
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(12, 12);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(100, 21);
            this.txtState.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Frequency:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Longtitude:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRADR);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtYr);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPr);
            this.groupBox1.Controls.Add(this.txtRr);
            this.groupBox1.Controls.Add(this.txtZs);
            this.groupBox1.Controls.Add(this.txtYs);
            this.groupBox1.Controls.Add(this.txtXs);
            this.groupBox1.Controls.Add(this.txtRoll);
            this.groupBox1.Controls.Add(this.txtYaw);
            this.groupBox1.Controls.Add(this.txtPitch);
            this.groupBox1.Controls.Add(this.txtMeter);
            this.groupBox1.Controls.Add(this.txtElevation);
            this.groupBox1.Controls.Add(this.txtLatitude);
            this.groupBox1.Controls.Add(this.txtLongtitude);
            this.groupBox1.Controls.Add(this.txtRPOSFreq);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnRPOS);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 392);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Postion";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 368);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 12);
            this.label14.TabIndex = 31;
            this.label14.Text = "Yaw rate:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 341);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 12);
            this.label13.TabIndex = 30;
            this.label13.Text = "Pitch rate:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 314);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 29;
            this.label12.Text = "Roll rate:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 287);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 28;
            this.label11.Text = "Z speed:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 260);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 27;
            this.label10.Text = "Y speed:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 233);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 26;
            this.label9.Text = "X speed:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 206);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 25;
            this.label8.Text = "Roll:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "Yaw:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "Pitch:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "Meter:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "Elevation:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "Latitude:";
            // 
            // txtYr
            // 
            this.txtYr.Location = new System.Drawing.Point(77, 365);
            this.txtYr.Name = "txtYr";
            this.txtYr.Size = new System.Drawing.Size(100, 21);
            this.txtYr.TabIndex = 19;
            // 
            // txtPr
            // 
            this.txtPr.Location = new System.Drawing.Point(77, 338);
            this.txtPr.Name = "txtPr";
            this.txtPr.Size = new System.Drawing.Size(100, 21);
            this.txtPr.TabIndex = 18;
            // 
            // txtRr
            // 
            this.txtRr.Location = new System.Drawing.Point(77, 311);
            this.txtRr.Name = "txtRr";
            this.txtRr.Size = new System.Drawing.Size(100, 21);
            this.txtRr.TabIndex = 17;
            // 
            // txtZs
            // 
            this.txtZs.Location = new System.Drawing.Point(77, 284);
            this.txtZs.Name = "txtZs";
            this.txtZs.Size = new System.Drawing.Size(100, 21);
            this.txtZs.TabIndex = 16;
            // 
            // txtYs
            // 
            this.txtYs.Location = new System.Drawing.Point(77, 257);
            this.txtYs.Name = "txtYs";
            this.txtYs.Size = new System.Drawing.Size(100, 21);
            this.txtYs.TabIndex = 15;
            // 
            // txtXs
            // 
            this.txtXs.Location = new System.Drawing.Point(77, 230);
            this.txtXs.Name = "txtXs";
            this.txtXs.Size = new System.Drawing.Size(100, 21);
            this.txtXs.TabIndex = 14;
            // 
            // txtRoll
            // 
            this.txtRoll.Location = new System.Drawing.Point(77, 203);
            this.txtRoll.Name = "txtRoll";
            this.txtRoll.Size = new System.Drawing.Size(100, 21);
            this.txtRoll.TabIndex = 13;
            // 
            // txtYaw
            // 
            this.txtYaw.Location = new System.Drawing.Point(77, 176);
            this.txtYaw.Name = "txtYaw";
            this.txtYaw.Size = new System.Drawing.Size(100, 21);
            this.txtYaw.TabIndex = 12;
            // 
            // txtPitch
            // 
            this.txtPitch.Location = new System.Drawing.Point(77, 149);
            this.txtPitch.Name = "txtPitch";
            this.txtPitch.Size = new System.Drawing.Size(100, 21);
            this.txtPitch.TabIndex = 11;
            // 
            // txtMeter
            // 
            this.txtMeter.Location = new System.Drawing.Point(77, 122);
            this.txtMeter.Name = "txtMeter";
            this.txtMeter.Size = new System.Drawing.Size(100, 21);
            this.txtMeter.TabIndex = 10;
            // 
            // txtElevation
            // 
            this.txtElevation.Location = new System.Drawing.Point(77, 95);
            this.txtElevation.Name = "txtElevation";
            this.txtElevation.Size = new System.Drawing.Size(100, 21);
            this.txtElevation.TabIndex = 9;
            // 
            // txtLatitude
            // 
            this.txtLatitude.Location = new System.Drawing.Point(77, 68);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(100, 21);
            this.txtLatitude.TabIndex = 8;
            // 
            // txtLongtitude
            // 
            this.txtLongtitude.Location = new System.Drawing.Point(77, 41);
            this.txtLongtitude.Name = "txtLongtitude";
            this.txtLongtitude.Size = new System.Drawing.Size(100, 21);
            this.txtLongtitude.TabIndex = 7;
            // 
            // txtRPOSFreq
            // 
            this.txtRPOSFreq.Location = new System.Drawing.Point(77, 14);
            this.txtRPOSFreq.Name = "txtRPOSFreq";
            this.txtRPOSFreq.Size = new System.Drawing.Size(100, 21);
            this.txtRPOSFreq.TabIndex = 6;
            // 
            // timerRPOS
            // 
            this.timerRPOS.Tick += new System.EventHandler(this.timerRPOS_Tick);
            // 
            // btnRADR
            // 
            this.btnRADR.Location = new System.Drawing.Point(183, 39);
            this.btnRADR.Name = "btnRADR";
            this.btnRADR.Size = new System.Drawing.Size(75, 23);
            this.btnRADR.TabIndex = 32;
            this.btnRADR.Text = "Send";
            this.btnRADR.UseVisualStyleBackColor = true;
            this.btnRADR.Click += new System.EventHandler(this.btnRADR_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 435);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.btn_Flapsdown);
            this.Controls.Add(this.btn_Flapsup);
            this.Controls.Add(this.btnConn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "XPUPC Example NOT FOR COMMERCIAL USE";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConn;
        private System.Windows.Forms.Button btnRPOS;
        private System.Windows.Forms.Button btn_Flapsup;
        private System.Windows.Forms.Button btn_Flapsdown;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtYr;
        private System.Windows.Forms.TextBox txtPr;
        private System.Windows.Forms.TextBox txtRr;
        private System.Windows.Forms.TextBox txtZs;
        private System.Windows.Forms.TextBox txtYs;
        private System.Windows.Forms.TextBox txtXs;
        private System.Windows.Forms.TextBox txtRoll;
        private System.Windows.Forms.TextBox txtYaw;
        private System.Windows.Forms.TextBox txtPitch;
        private System.Windows.Forms.TextBox txtMeter;
        private System.Windows.Forms.TextBox txtElevation;
        private System.Windows.Forms.TextBox txtLatitude;
        private System.Windows.Forms.TextBox txtLongtitude;
        private System.Windows.Forms.TextBox txtRPOSFreq;
        private System.Windows.Forms.Timer timerRPOS;
        private System.Windows.Forms.Button btnRADR;
    }
}

