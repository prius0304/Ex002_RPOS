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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnConn = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btn_Flapsup = new System.Windows.Forms.Button();
            this.btn_Flapsdown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConn
            // 
            this.btnConn.Location = new System.Drawing.Point(12, 12);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(75, 23);
            this.btnConn.TabIndex = 0;
            this.btnConn.Text = "Connect";
            this.btnConn.UseVisualStyleBackColor = true;
            this.btnConn.Click += new System.EventHandler(this.btnConn_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(12, 41);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btn_Flapsup
            // 
            this.btn_Flapsup.Location = new System.Drawing.Point(93, 12);
            this.btn_Flapsup.Name = "btn_Flapsup";
            this.btn_Flapsup.Size = new System.Drawing.Size(75, 23);
            this.btn_Flapsup.TabIndex = 2;
            this.btn_Flapsup.Text = "Flaps_Up";
            this.btn_Flapsup.UseVisualStyleBackColor = true;
            this.btn_Flapsup.Click += new System.EventHandler(this.btn_Flapsup_Click);
            // 
            // btn_Flapsdown
            // 
            this.btn_Flapsdown.Location = new System.Drawing.Point(93, 41);
            this.btn_Flapsdown.Name = "btn_Flapsdown";
            this.btn_Flapsdown.Size = new System.Drawing.Size(75, 23);
            this.btn_Flapsdown.TabIndex = 3;
            this.btn_Flapsdown.Text = "Flaps_Down";
            this.btn_Flapsdown.UseVisualStyleBackColor = true;
            this.btn_Flapsdown.Click += new System.EventHandler(this.btn_Flapsdown_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 374);
            this.Controls.Add(this.btn_Flapsdown);
            this.Controls.Add(this.btn_Flapsup);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnConn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "XPUPC Example NOT FOR COMMERCIAL USE";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConn;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btn_Flapsup;
        private System.Windows.Forms.Button btn_Flapsdown;
    }
}

