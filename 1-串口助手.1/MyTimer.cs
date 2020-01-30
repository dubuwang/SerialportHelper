using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SerialportHelper
{
    /// <summary>
    /// 自定义的定时器类
    /// </summary>
    class MyTimer
    {
        private Stopwatch stw = new Stopwatch();
        //声明委托
        public delegate void ElapsedHandler();
        //声明事件
        public event ElapsedHandler Elapsed;

        private static Thread sendThread;
        public bool Enabled = false;

        public int Interval
        {
            get;
            set;
        }

        public void Start()
        {
            this.Enabled = true;
            stw.Start();
            sendThread = new Thread(new ThreadStart(DoSend));
            sendThread.IsBackground = true;
            sendThread.Start();
        }

        private void DoSend()
        {
            while(Enabled)
            {
                if(stw.ElapsedMilliseconds>=Interval)
                {
                    if(Elapsed!=null)
                    {
                        Elapsed();
                        stw.Restart();
                    }
                }
            }
        }

        public void Stop()
        {
            Enabled = false;
            stw.Stop();
            if (sendThread != null && sendThread.IsAlive)
            {
                Thread.Sleep(1);
                sendThread.Abort();
            }
        }
    }
}
