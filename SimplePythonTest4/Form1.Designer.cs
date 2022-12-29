namespace SimplePythonTest4
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ConnectToPy = new System.Windows.Forms.Button();
            this.ExitPy = new System.Windows.Forms.Button();
            this.ReadLineButton = new System.Windows.Forms.Button();
            this.SendMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(241, 22);
            this.textBox1.TabIndex = 0;
            // 
            // ConnectToPy
            // 
            this.ConnectToPy.Location = new System.Drawing.Point(12, 210);
            this.ConnectToPy.Name = "ConnectToPy";
            this.ConnectToPy.Size = new System.Drawing.Size(83, 39);
            this.ConnectToPy.TabIndex = 2;
            this.ConnectToPy.Text = "開啟Python";
            this.ConnectToPy.UseVisualStyleBackColor = true;
            this.ConnectToPy.Click += new System.EventHandler(this.ControlButton_Click);
            // 
            // ExitPy
            // 
            this.ExitPy.Location = new System.Drawing.Point(170, 210);
            this.ExitPy.Name = "ExitPy";
            this.ExitPy.Size = new System.Drawing.Size(83, 39);
            this.ExitPy.TabIndex = 3;
            this.ExitPy.Text = "關閉Python";
            this.ExitPy.UseVisualStyleBackColor = true;
            this.ExitPy.Click += new System.EventHandler(this.ControlButton_Click);
            // 
            // ReadLineButton
            // 
            this.ReadLineButton.Location = new System.Drawing.Point(12, 63);
            this.ReadLineButton.Name = "ReadLineButton";
            this.ReadLineButton.Size = new System.Drawing.Size(83, 39);
            this.ReadLineButton.TabIndex = 4;
            this.ReadLineButton.Text = "ReadLine";
            this.ReadLineButton.UseVisualStyleBackColor = true;
            this.ReadLineButton.Click += new System.EventHandler(this.ControlButton_Click);
            // 
            // SendMessage
            // 
            this.SendMessage.Location = new System.Drawing.Point(170, 63);
            this.SendMessage.Name = "SendMessage";
            this.SendMessage.Size = new System.Drawing.Size(83, 39);
            this.SendMessage.TabIndex = 5;
            this.SendMessage.Text = "發送訊息";
            this.SendMessage.UseVisualStyleBackColor = true;
            this.SendMessage.Click += new System.EventHandler(this.ControlButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.SendMessage);
            this.Controls.Add(this.ReadLineButton);
            this.Controls.Add(this.ExitPy);
            this.Controls.Add(this.ConnectToPy);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ConnectToPy;
        private System.Windows.Forms.Button ExitPy;
        private System.Windows.Forms.Button ReadLineButton;
        private System.Windows.Forms.Button SendMessage;
    }
}

