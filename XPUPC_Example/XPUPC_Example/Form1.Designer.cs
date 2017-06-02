namespace XPUPC_Example
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btConn = new System.Windows.Forms.Button();
            this.tb_Status = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_DesIP = new System.Windows.Forms.TextBox();
            this.tb_DesPT = new System.Windows.Forms.TextBox();
            this.tb_SouPT = new System.Windows.Forms.TextBox();
            this.btChangeEth = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_RPOS_Frq = new System.Windows.Forms.TextBox();
            this.bt_SetRPOS = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tb_RPOS_Lon = new System.Windows.Forms.TextBox();
            this.tb_RPOS_Ele = new System.Windows.Forms.TextBox();
            this.tb_RPOS_Lat = new System.Windows.Forms.TextBox();
            this.tb_RPOS_GH = new System.Windows.Forms.TextBox();
            this.tb_RPOS_Pitch = new System.Windows.Forms.TextBox();
            this.tb_RPOS_X = new System.Windows.Forms.TextBox();
            this.tb_RPOS_Roll = new System.Windows.Forms.TextBox();
            this.tb_RPOS_Head = new System.Windows.Forms.TextBox();
            this.tb_RPOS_Y = new System.Windows.Forms.TextBox();
            this.tb_RPOS_Z = new System.Windows.Forms.TextBox();
            this.timerRPOS = new System.Windows.Forms.Timer(this.components);
            this.tb_RPOS_R = new System.Windows.Forms.TextBox();
            this.tb_RPOS_Q = new System.Windows.Forms.TextBox();
            this.tb_RPOS_P = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btConn
            // 
            this.btConn.Location = new System.Drawing.Point(177, 12);
            this.btConn.Name = "btConn";
            this.btConn.Size = new System.Drawing.Size(75, 23);
            this.btConn.TabIndex = 0;
            this.btConn.Text = "Connecct";
            this.btConn.UseVisualStyleBackColor = true;
            this.btConn.Click += new System.EventHandler(this.btConn_Click);
            // 
            // tb_Status
            // 
            this.tb_Status.Location = new System.Drawing.Point(71, 14);
            this.tb_Status.Name = "tb_Status";
            this.tb_Status.Size = new System.Drawing.Size(100, 21);
            this.tb_Status.TabIndex = 1;
            this.tb_Status.Text = "unconnect";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Status:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Des_IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dst_Port:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "Sou_Port:";
            // 
            // tb_DesIP
            // 
            this.tb_DesIP.Location = new System.Drawing.Point(71, 41);
            this.tb_DesIP.Name = "tb_DesIP";
            this.tb_DesIP.Size = new System.Drawing.Size(100, 21);
            this.tb_DesIP.TabIndex = 6;
            this.tb_DesIP.Text = "127.0.0.1";
            // 
            // tb_DesPT
            // 
            this.tb_DesPT.Location = new System.Drawing.Point(71, 68);
            this.tb_DesPT.Name = "tb_DesPT";
            this.tb_DesPT.Size = new System.Drawing.Size(100, 21);
            this.tb_DesPT.TabIndex = 7;
            this.tb_DesPT.Text = "49000";
            // 
            // tb_SouPT
            // 
            this.tb_SouPT.Location = new System.Drawing.Point(71, 95);
            this.tb_SouPT.Name = "tb_SouPT";
            this.tb_SouPT.Size = new System.Drawing.Size(100, 21);
            this.tb_SouPT.TabIndex = 8;
            this.tb_SouPT.Text = "56833";
            // 
            // btChangeEth
            // 
            this.btChangeEth.Location = new System.Drawing.Point(177, 41);
            this.btChangeEth.Name = "btChangeEth";
            this.btChangeEth.Size = new System.Drawing.Size(75, 23);
            this.btChangeEth.TabIndex = 9;
            this.btChangeEth.Text = "ChangeEthe";
            this.btChangeEth.UseVisualStyleBackColor = true;
            this.btChangeEth.Click += new System.EventHandler(this.btChangeEth_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_Status);
            this.groupBox1.Controls.Add(this.btChangeEth);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btConn);
            this.groupBox1.Controls.Add(this.tb_SouPT);
            this.groupBox1.Controls.Add(this.tb_DesPT);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_DesIP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 125);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_RPOS_R);
            this.groupBox2.Controls.Add(this.tb_RPOS_Q);
            this.groupBox2.Controls.Add(this.tb_RPOS_P);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.tb_RPOS_Z);
            this.groupBox2.Controls.Add(this.tb_RPOS_Y);
            this.groupBox2.Controls.Add(this.tb_RPOS_Head);
            this.groupBox2.Controls.Add(this.tb_RPOS_Roll);
            this.groupBox2.Controls.Add(this.tb_RPOS_X);
            this.groupBox2.Controls.Add(this.tb_RPOS_Pitch);
            this.groupBox2.Controls.Add(this.tb_RPOS_GH);
            this.groupBox2.Controls.Add(this.tb_RPOS_Lat);
            this.groupBox2.Controls.Add(this.tb_RPOS_Ele);
            this.groupBox2.Controls.Add(this.tb_RPOS_Lon);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tb_RPOS_Frq);
            this.groupBox2.Controls.Add(this.bt_SetRPOS);
            this.groupBox2.Location = new System.Drawing.Point(12, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 390);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Report Postion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "Frequency:";
            // 
            // tb_RPOS_Frq
            // 
            this.tb_RPOS_Frq.Location = new System.Drawing.Point(71, 14);
            this.tb_RPOS_Frq.Name = "tb_RPOS_Frq";
            this.tb_RPOS_Frq.Size = new System.Drawing.Size(94, 21);
            this.tb_RPOS_Frq.TabIndex = 13;
            // 
            // bt_SetRPOS
            // 
            this.bt_SetRPOS.Location = new System.Drawing.Point(177, 12);
            this.bt_SetRPOS.Name = "bt_SetRPOS";
            this.bt_SetRPOS.Size = new System.Drawing.Size(75, 23);
            this.bt_SetRPOS.TabIndex = 14;
            this.bt_SetRPOS.Text = "Set";
            this.bt_SetRPOS.UseVisualStyleBackColor = true;
            this.bt_SetRPOS.Click += new System.EventHandler(this.bt_SetRPOS_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "Longitude:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "Latitude:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "Elevation:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "Ground H:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "Pitch:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 179);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "Heading:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 206);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 21;
            this.label12.Text = "Roll:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 233);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 22;
            this.label13.Text = "X Speed:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 260);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 23;
            this.label14.Text = "Y Speed:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 287);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 24;
            this.label15.Text = "Z Speed:";
            // 
            // tb_RPOS_Lon
            // 
            this.tb_RPOS_Lon.Location = new System.Drawing.Point(71, 41);
            this.tb_RPOS_Lon.Name = "tb_RPOS_Lon";
            this.tb_RPOS_Lon.Size = new System.Drawing.Size(100, 21);
            this.tb_RPOS_Lon.TabIndex = 25;
            // 
            // tb_RPOS_Ele
            // 
            this.tb_RPOS_Ele.Location = new System.Drawing.Point(71, 95);
            this.tb_RPOS_Ele.Name = "tb_RPOS_Ele";
            this.tb_RPOS_Ele.Size = new System.Drawing.Size(100, 21);
            this.tb_RPOS_Ele.TabIndex = 26;
            // 
            // tb_RPOS_Lat
            // 
            this.tb_RPOS_Lat.Location = new System.Drawing.Point(71, 68);
            this.tb_RPOS_Lat.Name = "tb_RPOS_Lat";
            this.tb_RPOS_Lat.Size = new System.Drawing.Size(100, 21);
            this.tb_RPOS_Lat.TabIndex = 27;
            // 
            // tb_RPOS_GH
            // 
            this.tb_RPOS_GH.Location = new System.Drawing.Point(71, 122);
            this.tb_RPOS_GH.Name = "tb_RPOS_GH";
            this.tb_RPOS_GH.Size = new System.Drawing.Size(100, 21);
            this.tb_RPOS_GH.TabIndex = 28;
            // 
            // tb_RPOS_Pitch
            // 
            this.tb_RPOS_Pitch.Location = new System.Drawing.Point(71, 149);
            this.tb_RPOS_Pitch.Name = "tb_RPOS_Pitch";
            this.tb_RPOS_Pitch.Size = new System.Drawing.Size(100, 21);
            this.tb_RPOS_Pitch.TabIndex = 29;
            // 
            // tb_RPOS_X
            // 
            this.tb_RPOS_X.Location = new System.Drawing.Point(71, 230);
            this.tb_RPOS_X.Name = "tb_RPOS_X";
            this.tb_RPOS_X.Size = new System.Drawing.Size(100, 21);
            this.tb_RPOS_X.TabIndex = 30;
            // 
            // tb_RPOS_Roll
            // 
            this.tb_RPOS_Roll.Location = new System.Drawing.Point(71, 203);
            this.tb_RPOS_Roll.Name = "tb_RPOS_Roll";
            this.tb_RPOS_Roll.Size = new System.Drawing.Size(100, 21);
            this.tb_RPOS_Roll.TabIndex = 31;
            // 
            // tb_RPOS_Head
            // 
            this.tb_RPOS_Head.Location = new System.Drawing.Point(71, 176);
            this.tb_RPOS_Head.Name = "tb_RPOS_Head";
            this.tb_RPOS_Head.Size = new System.Drawing.Size(100, 21);
            this.tb_RPOS_Head.TabIndex = 32;
            // 
            // tb_RPOS_Y
            // 
            this.tb_RPOS_Y.Location = new System.Drawing.Point(71, 257);
            this.tb_RPOS_Y.Name = "tb_RPOS_Y";
            this.tb_RPOS_Y.Size = new System.Drawing.Size(100, 21);
            this.tb_RPOS_Y.TabIndex = 33;
            // 
            // tb_RPOS_Z
            // 
            this.tb_RPOS_Z.Location = new System.Drawing.Point(71, 284);
            this.tb_RPOS_Z.Name = "tb_RPOS_Z";
            this.tb_RPOS_Z.Size = new System.Drawing.Size(100, 21);
            this.tb_RPOS_Z.TabIndex = 34;
            // 
            // timerRPOS
            // 
            this.timerRPOS.Tick += new System.EventHandler(this.timerRPOS_Tick);
            // 
            // tb_RPOS_R
            // 
            this.tb_RPOS_R.Location = new System.Drawing.Point(71, 365);
            this.tb_RPOS_R.Name = "tb_RPOS_R";
            this.tb_RPOS_R.Size = new System.Drawing.Size(100, 21);
            this.tb_RPOS_R.TabIndex = 40;
            // 
            // tb_RPOS_Q
            // 
            this.tb_RPOS_Q.Location = new System.Drawing.Point(71, 338);
            this.tb_RPOS_Q.Name = "tb_RPOS_Q";
            this.tb_RPOS_Q.Size = new System.Drawing.Size(100, 21);
            this.tb_RPOS_Q.TabIndex = 39;
            // 
            // tb_RPOS_P
            // 
            this.tb_RPOS_P.Location = new System.Drawing.Point(71, 311);
            this.tb_RPOS_P.Name = "tb_RPOS_P";
            this.tb_RPOS_P.Size = new System.Drawing.Size(100, 21);
            this.tb_RPOS_P.TabIndex = 38;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 368);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 12);
            this.label16.TabIndex = 37;
            this.label16.Text = "Yaw Rate:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 341);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 12);
            this.label17.TabIndex = 36;
            this.label17.Text = "Pitch Rate:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 314);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 35;
            this.label18.Text = "Roll Rate:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 535);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btConn;
        private System.Windows.Forms.TextBox tb_Status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_DesIP;
        private System.Windows.Forms.TextBox tb_DesPT;
        private System.Windows.Forms.TextBox tb_SouPT;
        private System.Windows.Forms.Button btChangeEth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_RPOS_Frq;
        private System.Windows.Forms.Button bt_SetRPOS;
        private System.Windows.Forms.TextBox tb_RPOS_Y;
        private System.Windows.Forms.TextBox tb_RPOS_Head;
        private System.Windows.Forms.TextBox tb_RPOS_Roll;
        private System.Windows.Forms.TextBox tb_RPOS_X;
        private System.Windows.Forms.TextBox tb_RPOS_Pitch;
        private System.Windows.Forms.TextBox tb_RPOS_GH;
        private System.Windows.Forms.TextBox tb_RPOS_Lat;
        private System.Windows.Forms.TextBox tb_RPOS_Ele;
        private System.Windows.Forms.TextBox tb_RPOS_Lon;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_RPOS_Z;
        private System.Windows.Forms.Timer timerRPOS;
        private System.Windows.Forms.TextBox tb_RPOS_R;
        private System.Windows.Forms.TextBox tb_RPOS_Q;
        private System.Windows.Forms.TextBox tb_RPOS_P;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
    }
}

