using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using System.IO;

namespace SimplePythonTest4
{
    public partial class Form1 : Form
    {

        /// <summary>
        /// 委派方法
        /// </summary>
        /// <param name="text"></param>
        delegate void SetTextCallback(string text);

        public Process p = new Process();

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Button控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlButton_Click(object sender, EventArgs e)
        {
            Button Btn = (Button)sender;
            string outputText = string.Empty;                    
            switch (Btn.Name) 
            {
                case "ConnectToPy"://開啟Python
                    ConnectToPython("--name \"test5\" --size \"99636\"");                   
                    break;
                case "ExitPy"://關閉Python
                    p.StandardInput.WriteLine("Exit");
                    p.StandardInput.Flush();
                    break;
                case "SendMessage"://送出訊息                    
                    p.StandardInput.WriteLine(textBox1.Text.ToString());
                    outputText = p.StandardOutput.ReadLine();
                    this.SetText(outputText);
                    break;
                case "ReadLine":
                    string output = p.StandardOutput.ReadLine();
                    this.SetText(output);
                    break;
            }
        }        
        public void ConnectToPython(string commend)
        {
            try
            {
                string output = string.Empty;
                p.Exited += (obj, args) =>
                {
                    //ExitCode: 0 表示Process執行無錯誤，順利結束
                    if (p.ExitCode == 0)
                    {
                        //讀出實體檔案內容，並設定給textBox1.Text(這邊請自行處理無檔案時的例外)。
                        //這裡會用委派是因為Process是開另一個執行序去處理的，
                        //所以有thread-unsafe的問題，使用委派是一種解決方式(另一種是使用BackgroundWorker)
                        //請參考：https://docs.microsoft.com/zh-tw/dotnet/framework/winforms/controls/how-to-make-thread-safe-calls-to-windows-forms-controls

                        //this.SetText(System.IO.File.ReadAllText(fileName));
                        //File.Delete(fileName);

                        MessageBox.Show("關閉成功! Exit Code: " + p.ExitCode + output);
                    }
                    else
                    {
                        //利用實體檔案來當作兩種程式的溝通管道                                                
                        this.SetText(string.Format("TimeStamp: {0} 執行錯誤", p.ExitCode));
                    }
                };
                
                string cmd = @"cd Python";                
                string cmd2 = @"python TestByShareMemory.py " + commend;
                p.EnableRaisingEvents = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.RedirectStandardInput = true;
                p.Start();
                StreamWriter myStreamWriter = p.StandardInput;
                myStreamWriter.WriteLine(cmd.ToString());                
                myStreamWriter.WriteLine(cmd2.ToString());
                for (int i = 0; i < 7; i++) {output = p.StandardOutput.ReadLine();}
                    
                this.SetText(output);

            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤: " + ex);
            }
            GC.Collect();
        }

        private void SetText(string text)
        {
            if (this.textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox1.Text = text;
            }
        }                      
    }
}
