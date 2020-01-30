using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace SerialportHelper
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 存放PC可用端口名的数组
        /// </summary>
        string[] portName = null;

        /// <summary>
        /// 声明一个定时器，定时执行串口发送操作
        /// </summary>
        System.Timers.Timer timerSend = new System.Timers.Timer();

        /// <summary>
        /// 串口接收数据缓存区，可防止丢包
        /// </summary>
        List<byte> buffer = new List<byte>();

        /// <summary>
        /// 经校验的数据包
        /// </summary>
        byte[] receiveByte = new byte[11];

        /// <summary>
        /// 声明一个串口数据datatable，用于存储表格化的数据
        /// </summary>
        DataRecordTable dataRecordTable = new DataRecordTable();

        /// <summary>
        /// 窗口接收数据事件发生时调用函数，是异步执行的，在辅助线程上执行
        /// DataReceived 事件处理过程执行完毕才会触发窗口下一个 DataReceived 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //try
            //{
                //获取当前时间
                string time = DateTime.Now.ToString("hh:mm:ss fff--");
                //(当进入数据接收事件时，端口被关闭，会抛出异常)

                //创建接收数据数组receiveBuffer，接收此次串口发送过来的数据
                byte[] receiveBuffer = new byte[serialPort1.BytesToRead];
                serialPort1.Read(receiveBuffer, 0, receiveBuffer.Length);
                
                //将接收到的数据放入buffer缓冲区中
                buffer.AddRange(receiveBuffer);

                while (buffer.Count >= 3) //当数据至少包含帧头1字节、长度1字节、帧尾1字节
                {
                    if (buffer[0] == 0xAA)     //检查帧头数据
                    {
                        //获取数据长度
                        Int16 len = buffer[1];
                        //判断是否接收完整，不完整则跳出循环
                        if (buffer.Count < len + 3) break;
                        //校验帧尾,如果校验不符合，丢弃这一包数据
                        if (buffer[len+2] != 0xEE)
                        {
                            //移除数据包
                            buffer.RemoveRange(0, len + 3);
                            //继续下一次循环
                            continue;
                        }

                        //复制这条完整的数据到数据包中
                        buffer.CopyTo(0, receiveByte, 0, len + 3);
                        
                        //判断记录标志，将数据存入datatable中
                        if (recordFlag == true)
                        {
                            this.dataRecordTable.AddRows(receiveByte, time);
                        }

                        //在缓存区中移除这条数据包
                        buffer.RemoveRange(0, len + 3);
                        //开始显示数据包中的数据
                        txtLogAppendTextInvoke(receiveByte, time);
                    }
                    else
                    {
                        //不是帧头，移除首位字节
                        buffer.RemoveAt(0);
                    }
                }

            //}
            //catch
            //{

            //}
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                portName = SerialPort.GetPortNames();
                cboPort.Items.Clear();

                cboPort.Items.AddRange(portName);

            }
            cboPort.SelectedIndex = cboPort.Items.Count > 0 ? 0 : -1;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("hh:mm:ss fff"); 
            
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.PortName = cboPort.Text;
                }
                catch
                {
                    MessageBox.Show("please select port");
                    return;
                }
                serialPort1.Open();
                txtLog.AppendText(time + "--" + serialPort1.PortName + " be opened" + System.Environment.NewLine);
            }
            else
            {
                txtLog.AppendText(time + "--" + serialPort1.PortName + " is already opened" + System.Environment.NewLine);

            }
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                timerSend.Enabled = false;
                serialPort1.Close();
                string time = DateTime.Now.ToString("hh:mm:ss fff");
                txtLog.AppendText(time + "--" + serialPort1.PortName + " be closed" + System.Environment.NewLine);
            }
        }

        /// <summary>
        /// 串口发送的字节数组
        /// </summary>
        byte[] sendDATA;

        /// <summary>
        /// 按下发送按钮时，初始化定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            #region 使用winform.timer
            //if (!timer1.Enabled)
            //{
            //    //设置定时器的时间
            //    int cycleTime = int.Parse(txtCycle.Text.Trim());
            //    timer1.Interval = cycleTime;
            //    //获取要发送的字节
            //    buffer[0] = Convert.ToByte(txtMsg.Text);
            //    //启动定时器
            //    timer1.Start();
            //}
            #endregion

            #region 使用system.timers.timer
            //获取定时器的周期
            int cycleTime = 0;
            try
            {
                cycleTime = int.Parse(txtCycle.Text.Trim());
            }
            catch
            {
                MessageBox.Show("cycle error");
                return;
            }
            //判断周期是否＞0
            if (cycleTime > 0)
            {
                //设置定时器周期
                timerSend.Interval = cycleTime;
                try
                {
                    //获取要发送的字节数组
                    sendDATA = GetMessageByte();
                    //注册周期事件方法
                    timerSend.Elapsed -= new System.Timers.ElapsedEventHandler(timerSend_Elapsed);
                    timerSend.Elapsed += new System.Timers.ElapsedEventHandler(timerSend_Elapsed);
                    //启动定时器
                    timerSend.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("error: one byte");
                    return;
                }
            }
            else
            {
                //用户输入周期错误
                MessageBox.Show("error:cycle");
                return;
            }
            #endregion

            btnSend.Enabled = false;
            btnPause.Enabled = true;
        }

        void timerSend_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            try
            {
                serialPort1.Write(sendDATA, 0, sendDATA.Length);
            }
            catch
            {
                timerSend.Enabled = false;
                MessageBox.Show("error : send");
            }

        }


        /// <summary>
        /// 以定时周期性地向串口发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(sendDATA, 0, 1);
            }
        }

        /// <summary>
        /// 将接收到的字节数组转换成字符串，显示到消息框中
        /// </summary>
        /// <param name="data"></param>
        /// <param name="length"></param>
        private void txtLogAppendTextInvoke(byte[] data, string time)
        {
            string message = null;
            for (int i = 2; i < data.Length - 1; i++)
            {
                message += data[i].ToString("x2");
                if (i < data.Length - 2)
                {
                    message += " ";
                }
            }

            Action a = delegate()
            {
                txtLog.AppendText(time + DateTime.Now.ToString("hh:mm:ss fff--") + message + System.Environment.NewLine);
            };
            this.BeginInvoke(a);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timerSend.Enabled = false;
            btnSend.Enabled = true;
            btnPause.Enabled = false;
        }
        /// <summary>
        /// 将用户输入的message转换成字节数组返回
        /// </summary>
        /// <returns>待发送消息的字节数组</returns>
        private byte[] GetMessageByte()
        {
           
            string str = txtMsg.Text;
            string[] strbyte = str.Split(' ');
            byte[] message = new Byte[strbyte.Length + 3];
            //插入帧头
            message[0] = Convert.ToByte(txtFH.Text.Substring(2, 2),16);
            //插入帧长度
            message[1] = Convert.ToByte(txtLength.Text.Substring(2, 2),16);
            //插入帧尾
            message[message.Length - 1] = Convert.ToByte(txtEF.Text.Substring(2, 2),16);
            //将字符串以16进制的数字形式转换成byte，存入数组中
            for (int i = 0; i < strbyte.Length; i++)
            {
                message[i + 2] = Convert.ToByte(strbyte[i], 16);
            }
            return message;
        }

        
        /// <summary>
        /// 记录数据标志位
        /// </summary>
        bool recordFlag =  false;
        
        /// <summary>
        /// 点击record按钮，开始记录或结束记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecord_Click(object sender, EventArgs e)
        {
            //先进行判断可以开始记录的条件:1.按钮处于待记录状态，2.串口处于打开
            if (btnRecord.Text == "Record" && serialPort1.IsOpen)
            {
                //1.将记录数据标志位置为true
                recordFlag = true;
                //2.修改按钮文本状态
                btnRecord.Text = "Recording";
            }
            else if(btnRecord.Text == "Recording")
            {
                //如果按钮状态为recoring，表示此时在记录数据
                //1.记录数据标志为false，停止存储数据至datarecordtable中
                recordFlag = false;

                //2.判断dataRecordTable是否满足转excel条件
                if (dataRecordTable.dt.Rows.Count > 0)
                {
                    //打开一个保存文件框，获取选择要保存的地址和文件名称
                    SaveFileDialog sfd = new SaveFileDialog();
                    if (sfd.ShowDialog() == DialogResult.OK) 
                    {
                        //点击保存按钮后获取输入文件名的绝对地址
                        string path = sfd.FileName;
                        //调用dataRecordTable的转excel方法
                        //dataRecordTable.DataToExcel(dataRecordTable.dt, path);

                        //调用生成csv文件方法
                        dataRecordTable.DataToCsv(dataRecordTable.dt, path);
                        //转完后，清空dataRecordTable
                        dataRecordTable.dt.Clear();
                    }
                }
                //5.修改record按钮文本状态
                btnRecord.Text = "Record";
            }
        }

        /// <summary>
        /// 点击clear按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            if (dataRecordTable.dt.Rows.Count > 0)
            {
                dataRecordTable.dt.Clear();
            }
        }
    }
}

