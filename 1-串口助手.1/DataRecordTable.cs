using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialportHelper
{

    /// <summary>
    /// 这是一个数据记录表，可以按格式存储串口的数据
    /// </summary>
    class DataRecordTable
    {
        /// <summary>
        /// 声明一个自动实现属性：DataTable类的实例对象
        /// </summary>
        public DataTable dt
        {
            set;
            get;
        }

        /// <summary>
        /// 构造方法，实例化DataTable
        /// </summary>
        public DataRecordTable()
        {
            this.dt = new DataTable();
            this.AddColumns();
        }
        /// <summary>
        /// 给DataTable添加行
        /// </summary>
        internal void AddColumns()
        {
            this.dt.Columns.Add("time", typeof(string));
            this.dt.Columns.Add("FrameHeader", typeof(string));
            this.dt.Columns.Add("Length", typeof(string));
            this.dt.Columns.Add("Data", typeof(string));
            this.dt.Columns.Add("EndFrame", typeof(string));
        }
        /// <summary>
        /// 将字节数组解析，添加行
        /// </summary>
        /// <param name="receiveByte"></param>
        internal void AddRows(byte[] addByte, string addtime)
        {

            DataRow row = this.dt.NewRow();
            row["time"] = addtime;
            row["FrameHeader"] = addByte[0].ToString("x2");
            row["Length"] = addByte[1].ToString("x2");
            //添加Data行
            string data = null;
            for (int i = 2; i < addByte.Length - 1; i++)
            {
                data += addByte[i].ToString("x2");
                if (i < addByte.Length - 2) data += " ";
            }
            row["Data"] = data;
            row["EndFrame"] = addByte[addByte.Length - 1].ToString("x2");

            this.dt.Rows.Add(row);
        }

        /// <summary>
        /// Datatable生成Excel表格并返回路径
        /// </summary>
        /// <param name="m_DataTable">Datatable</param>
        /// <param name="s_FileName">文件名</param>
        /// <returns></returns>

        public string DataToExcel(System.Data.DataTable m_DataTable, string s_FileName)
        {
            //文件存放路径：绝对路径+文件名+后缀扩展名
            string FileName = s_FileName + ".xls";  

             //存在则删除
            if (System.IO.File.Exists(FileName))                               
            {

                System.IO.File.Delete(FileName);

            }

            System.IO.FileStream objFileStream;

            System.IO.StreamWriter objStreamWriter; 

            string strLine = "";
            //以指定的路径、文件操作模式、文件权限来实例化一个文件流
            objFileStream = new System.IO.FileStream(FileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
            
            //以指定的一个文件流和指定的编码来实例化一个StreaWriter流。
            //编码就是：以什么样的编码格式写入字节流-具体到streamwriter就是写入字符串时，先用
            //指定的编码将字符串编码成二进制字节，然后写入路径文件
            objStreamWriter = new System.IO.StreamWriter(objFileStream, Encoding.Unicode);

            for (int i = 0; i < m_DataTable.Columns.Count; i++)
            {
                // \t的ASCII码是 9
                strLine = strLine + m_DataTable.Columns[i].Caption.ToString() + Convert.ToChar(9);      //写列标题

            }

            objStreamWriter.WriteLine(strLine);

            strLine = "";

            for (int i = 0; i < m_DataTable.Rows.Count; i++)
            {

                for (int j = 0; j < m_DataTable.Columns.Count; j++)
                {

                    if (m_DataTable.Rows[i].ItemArray[j] == null)

                        strLine = strLine + " " + Convert.ToChar(9);                                    //写内容

                    else
                    {

                        string rowstr = "";

                        rowstr = m_DataTable.Rows[i].ItemArray[j].ToString();

                        if (rowstr.IndexOf("\r\n") > 0)

                            rowstr = rowstr.Replace("\r\n", " ");

                        if (rowstr.IndexOf("\t") > 0)

                            rowstr = rowstr.Replace("\t", " ");

                        strLine = strLine + rowstr + Convert.ToChar(9);

                    }

                }

                objStreamWriter.WriteLine(strLine);

                strLine = "";

            }

            objStreamWriter.Close();

            objFileStream.Close();

            return FileName;        //返回生成文件的绝对路径

        }

        /// <summary>
        /// DataTable生成csv文件
        /// </summary>
        /// <param name="m_DataTable"></param>
        /// <param name="s_FileName"></param>
        public void DataToCsv(System.Data.DataTable m_DataTable,string s_FileName)
        {
            //文件存放路径
            string fileName = s_FileName + ".csv";
            
            string str = "";
           
            //创建一个文件流来写入数据
            StreamWriter strWriter = new StreamWriter(fileName, false, Encoding.Default);

            //将列标题写入字符串，以","分隔开，csv根据“,”分隔每列数据
            foreach (DataColumn column in this.dt.Columns)
            {
                str += column.ColumnName + ",";
            }
            //去掉最后一个","
            str = str.Substring(0, str.Length - 1);
            //写入列标题
            strWriter.WriteLine(str);

            //写入行数据
            for (int i = 0; i < this.dt.Rows.Count; i++)
            {
                str = "";
                for (int j  = 0; j  < this.dt.Columns.Count; j ++)
                {
                    if (j > 0) str += ",";

                    str += this.dt.Rows[i][j].ToString().Replace(","," ");

                }

                strWriter.WriteLine(str);
            }

            strWriter.Close();

        }
    }

}

