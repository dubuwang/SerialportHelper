namespace SerialportHelper
{
    partial class FrmMain
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtCycle = new System.Windows.Forms.TextBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnPause = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Message = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblEndFrame = new System.Windows.Forms.Label();
            this.txtEF = new System.Windows.Forms.TextBox();
            this.lblLength = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.lblFrameHeader = new System.Windows.Forms.Label();
            this.txtFH = new System.Windows.Forms.TextBox();
            this.lblData = new System.Windows.Forms.Label();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Message.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // cboPort
            // 
            this.cboPort.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(132, 65);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(175, 28);
            this.cboPort.TabIndex = 0;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPort.Location = new System.Drawing.Point(67, 68);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(59, 20);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "Port:";
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = true;
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(355, 62);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(79, 33);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseCompatibleTextRendering = true;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Controls.Add(this.cboPort);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.lblPort);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(51, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 137);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PortSet";
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(588, 62);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 33);
            this.btnClose.TabIndex = 4;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.UseCompatibleTextRendering = true;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.AutoSize = true;
            this.btnOpen.BackColor = System.Drawing.SystemColors.Control;
            this.btnOpen.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpen.Location = new System.Drawing.Point(474, 62);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(79, 33);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.TabStop = false;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseCompatibleTextRendering = true;
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtLog
            // 
            this.txtLog.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLog.Location = new System.Drawing.Point(6, 37);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(760, 190);
            this.txtLog.TabIndex = 4;
            this.txtLog.TabStop = false;
            // 
            // txtCycle
            // 
            this.txtCycle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCycle.Location = new System.Drawing.Point(131, 35);
            this.txtCycle.Name = "txtCycle";
            this.txtCycle.Size = new System.Drawing.Size(100, 30);
            this.txtCycle.TabIndex = 5;
            // 
            // txtMsg
            // 
            this.txtMsg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMsg.Location = new System.Drawing.Point(297, 50);
            this.txtMsg.MaxLength = 23;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(272, 30);
            this.txtMsg.TabIndex = 6;
            // 
            // btnSend
            // 
            this.btnSend.AutoSize = true;
            this.btnSend.BackColor = System.Drawing.SystemColors.Control;
            this.btnSend.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSend.Location = new System.Drawing.Point(342, 32);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(79, 33);
            this.btnSend.TabIndex = 5;
            this.btnSend.TabStop = false;
            this.btnSend.Text = "Send";
            this.btnSend.UseCompatibleTextRendering = true;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(7, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "cycle(ms):";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnPause
            // 
            this.btnPause.AutoSize = true;
            this.btnPause.BackColor = System.Drawing.SystemColors.Control;
            this.btnPause.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPause.Location = new System.Drawing.Point(257, 32);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(79, 33);
            this.btnPause.TabIndex = 8;
            this.btnPause.TabStop = false;
            this.btnPause.Text = "Pause";
            this.btnPause.UseCompatibleTextRendering = true;
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.txtCycle);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(378, 594);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 100);
            this.panel1.TabIndex = 9;
            // 
            // Message
            // 
            this.Message.Controls.Add(this.txtLog);
            this.Message.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Message.Location = new System.Drawing.Point(45, 192);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(775, 240);
            this.Message.TabIndex = 10;
            this.Message.TabStop = false;
            this.Message.Text = "Message";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblEndFrame);
            this.panel2.Controls.Add(this.txtEF);
            this.panel2.Controls.Add(this.lblLength);
            this.panel2.Controls.Add(this.txtLength);
            this.panel2.Controls.Add(this.lblFrameHeader);
            this.panel2.Controls.Add(this.txtFH);
            this.panel2.Controls.Add(this.lblData);
            this.panel2.Controls.Add(this.txtMsg);
            this.panel2.Location = new System.Drawing.Point(51, 471);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(760, 100);
            this.panel2.TabIndex = 11;
            // 
            // lblEndFrame
            // 
            this.lblEndFrame.AutoSize = true;
            this.lblEndFrame.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEndFrame.Location = new System.Drawing.Point(580, 17);
            this.lblEndFrame.Name = "lblEndFrame";
            this.lblEndFrame.Size = new System.Drawing.Size(89, 20);
            this.lblEndFrame.TabIndex = 13;
            this.lblEndFrame.Text = "EndFrame";
            // 
            // txtEF
            // 
            this.txtEF.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEF.Location = new System.Drawing.Point(584, 50);
            this.txtEF.MaxLength = 2;
            this.txtEF.Name = "txtEF";
            this.txtEF.Size = new System.Drawing.Size(115, 30);
            this.txtEF.TabIndex = 12;
            this.txtEF.Text = "0xEE";
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLength.Location = new System.Drawing.Point(168, 17);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(69, 20);
            this.lblLength.TabIndex = 11;
            this.lblLength.Text = "Length";
            // 
            // txtLength
            // 
            this.txtLength.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLength.Location = new System.Drawing.Point(172, 50);
            this.txtLength.MaxLength = 2;
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(115, 30);
            this.txtLength.TabIndex = 10;
            this.txtLength.Text = "0x08";
            // 
            // lblFrameHeader
            // 
            this.lblFrameHeader.AutoSize = true;
            this.lblFrameHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFrameHeader.Location = new System.Drawing.Point(38, 17);
            this.lblFrameHeader.Name = "lblFrameHeader";
            this.lblFrameHeader.Size = new System.Drawing.Size(119, 20);
            this.lblFrameHeader.TabIndex = 9;
            this.lblFrameHeader.Text = "FrameHeader";
            // 
            // txtFH
            // 
            this.txtFH.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFH.Location = new System.Drawing.Point(42, 50);
            this.txtFH.MaxLength = 2;
            this.txtFH.Name = "txtFH";
            this.txtFH.Size = new System.Drawing.Size(115, 30);
            this.txtFH.TabIndex = 8;
            this.txtFH.Text = "0xAA";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblData.Location = new System.Drawing.Point(293, 17);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(49, 20);
            this.lblData.TabIndex = 7;
            this.lblData.Text = "Data";
            // 
            // btnRecord
            // 
            this.btnRecord.AutoSize = true;
            this.btnRecord.BackColor = System.Drawing.SystemColors.Control;
            this.btnRecord.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRecord.Location = new System.Drawing.Point(732, 432);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(79, 33);
            this.btnRecord.TabIndex = 9;
            this.btnRecord.TabStop = false;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseCompatibleTextRendering = true;
            this.btnRecord.UseVisualStyleBackColor = false;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnClear
            // 
            this.btnClear.AutoSize = true;
            this.btnClear.BackColor = System.Drawing.SystemColors.Control;
            this.btnClear.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClear.Location = new System.Drawing.Point(622, 432);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(79, 33);
            this.btnClear.TabIndex = 12;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear";
            this.btnClear.UseCompatibleTextRendering = true;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(890, 730);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMain";
            this.Text = "Port";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Message.ResumeLayout(false);
            this.Message.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtCycle;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox Message;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblFrameHeader;
        private System.Windows.Forms.TextBox txtFH;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblEndFrame;
        private System.Windows.Forms.TextBox txtEF;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnClear;
    }
}

