namespace FileExtractorWinForms
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
            textBoxDirectoryPath = new TextBox();
            labelDirectoryPath = new Label();
            radioButtonMode1 = new RadioButton();
            radioButtonMode2 = new RadioButton();
            radioButtonMode3 = new RadioButton();
            radioButtonMode4 = new RadioButton();
            textBoxStartAddress = new TextBox();
            labelStartAddress = new Label();
            textBoxEndAddress = new TextBox();
            labelEndAddress = new Label();
            textBoxStartSequence = new TextBox();
            labelStartSequence = new Label();
            textBoxEndSequence = new TextBox();
            labelEndSequence = new Label();
            textBoxMinRepeatCount = new TextBox();
            labelMinRepeatCount = new Label();
            textBoxOutputFormat = new TextBox();
            labelOutputFormat = new Label();
            buttonExtract = new Button();
            richTextBoxOutput = new RichTextBox();
            textBoxHexAddress = new TextBox();
            labelHexAddress = new Label();
            SuspendLayout();
            // 
            // textBoxDirectoryPath
            // 
            textBoxDirectoryPath.Location = new Point(77, 16);
            textBoxDirectoryPath.Margin = new Padding(4);
            textBoxDirectoryPath.Name = "textBoxDirectoryPath";
            textBoxDirectoryPath.Size = new Size(657, 23);
            textBoxDirectoryPath.TabIndex = 0;
            textBoxDirectoryPath.TextChanged += textBoxDirectoryPath_TextChanged;
            // 
            // labelDirectoryPath
            // 
            labelDirectoryPath.AutoSize = true;
            labelDirectoryPath.Location = new Point(14, 20);
            labelDirectoryPath.Margin = new Padding(4, 0, 4, 0);
            labelDirectoryPath.Name = "labelDirectoryPath";
            labelDirectoryPath.Size = new Size(68, 17);
            labelDirectoryPath.TabIndex = 1;
            labelDirectoryPath.Text = "输入路径：";
            // 
            // radioButtonMode1
            // 
            radioButtonMode1.AutoSize = true;
            radioButtonMode1.Location = new Point(14, 55);
            radioButtonMode1.Margin = new Padding(4);
            radioButtonMode1.Name = "radioButtonMode1";
            radioButtonMode1.Size = new Size(117, 21);
            radioButtonMode1.TabIndex = 2;
            radioButtonMode1.TabStop = true;
            radioButtonMode1.Text = "模式1：正常提取";
            radioButtonMode1.UseVisualStyleBackColor = true;
            radioButtonMode1.CheckedChanged += radioButtonMode1_CheckedChanged;
            // 
            // radioButtonMode2
            // 
            radioButtonMode2.AutoSize = true;
            radioButtonMode2.Location = new Point(139, 55);
            radioButtonMode2.Margin = new Padding(4);
            radioButtonMode2.Name = "radioButtonMode2";
            radioButtonMode2.Size = new Size(189, 21);
            radioButtonMode2.TabIndex = 3;
            radioButtonMode2.TabStop = true;
            radioButtonMode2.Text = "模式2：提取指定地址前的内容";
            radioButtonMode2.UseVisualStyleBackColor = true;
            radioButtonMode2.CheckedChanged += radioButtonMode2_CheckedChanged;
            // 
            // radioButtonMode3
            // 
            radioButtonMode3.AutoSize = true;
            radioButtonMode3.Location = new Point(336, 55);
            radioButtonMode3.Margin = new Padding(4);
            radioButtonMode3.Name = "radioButtonMode3";
            radioButtonMode3.Size = new Size(189, 21);
            radioButtonMode3.TabIndex = 4;
            radioButtonMode3.TabStop = true;
            radioButtonMode3.Text = "模式3：提取指定地址后的内容";
            radioButtonMode3.UseVisualStyleBackColor = true;
            radioButtonMode3.CheckedChanged += radioButtonMode3_CheckedChanged;
            // 
            // radioButtonMode4
            // 
            radioButtonMode4.AutoSize = true;
            radioButtonMode4.Location = new Point(533, 55);
            radioButtonMode4.Margin = new Padding(4);
            radioButtonMode4.Name = "radioButtonMode4";
            radioButtonMode4.Size = new Size(201, 21);
            radioButtonMode4.TabIndex = 5;
            radioButtonMode4.TabStop = true;
            radioButtonMode4.Text = "模式4：从两个地址之间提取数据";
            radioButtonMode4.UseVisualStyleBackColor = true;
            radioButtonMode4.CheckedChanged += radioButtonMode4_CheckedChanged;
            // 
            // textBoxStartAddress
            // 
            textBoxStartAddress.Location = new Point(320, 116);
            textBoxStartAddress.Margin = new Padding(4);
            textBoxStartAddress.Name = "textBoxStartAddress";
            textBoxStartAddress.Size = new Size(414, 23);
            textBoxStartAddress.TabIndex = 6;
            // 
            // labelStartAddress
            // 
            labelStartAddress.AutoSize = true;
            labelStartAddress.Location = new Point(10, 119);
            labelStartAddress.Margin = new Padding(4, 0, 4, 0);
            labelStartAddress.Name = "labelStartAddress";
            labelStartAddress.Size = new Size(92, 17);
            labelStartAddress.TabIndex = 7;
            labelStartAddress.Text = "请输入起始地址";
            // 
            // textBoxEndAddress
            // 
            textBoxEndAddress.Location = new Point(320, 145);
            textBoxEndAddress.Margin = new Padding(4);
            textBoxEndAddress.Name = "textBoxEndAddress";
            textBoxEndAddress.Size = new Size(414, 23);
            textBoxEndAddress.TabIndex = 8;
            // 
            // labelEndAddress
            // 
            labelEndAddress.AutoSize = true;
            labelEndAddress.Location = new Point(10, 148);
            labelEndAddress.Margin = new Padding(4, 0, 4, 0);
            labelEndAddress.Name = "labelEndAddress";
            labelEndAddress.Size = new Size(92, 17);
            labelEndAddress.TabIndex = 9;
            labelEndAddress.Text = "请输入结束地址";
            // 
            // textBoxStartSequence
            // 
            textBoxStartSequence.Location = new Point(320, 178);
            textBoxStartSequence.Margin = new Padding(4);
            textBoxStartSequence.Name = "textBoxStartSequence";
            textBoxStartSequence.Size = new Size(414, 23);
            textBoxStartSequence.TabIndex = 10;
            // 
            // labelStartSequence
            // 
            labelStartSequence.AutoSize = true;
            labelStartSequence.Location = new Point(10, 181);
            labelStartSequence.Margin = new Padding(4, 0, 4, 0);
            labelStartSequence.Name = "labelStartSequence";
            labelStartSequence.Size = new Size(310, 17);
            labelStartSequence.TabIndex = 11;
            labelStartSequence.Text = "请输入起始序列，以空格分隔，使用*表示重复，如00*16";
            // 
            // textBoxEndSequence
            // 
            textBoxEndSequence.Location = new Point(320, 210);
            textBoxEndSequence.Margin = new Padding(4);
            textBoxEndSequence.Name = "textBoxEndSequence";
            textBoxEndSequence.Size = new Size(414, 23);
            textBoxEndSequence.TabIndex = 12;
            textBoxEndSequence.TextChanged += textBoxEndSequence_TextChanged;
            // 
            // labelEndSequence
            // 
            labelEndSequence.AutoSize = true;
            labelEndSequence.Location = new Point(10, 213);
            labelEndSequence.Margin = new Padding(4, 0, 4, 0);
            labelEndSequence.Name = "labelEndSequence";
            labelEndSequence.Size = new Size(303, 17);
            labelEndSequence.TabIndex = 13;
            labelEndSequence.Text = "请输入结束序列，以空格分割，使用*表示重复，如00*4";
            // 
            // textBoxMinRepeatCount
            // 
            textBoxMinRepeatCount.Enabled = false;
            textBoxMinRepeatCount.Location = new Point(320, 241);
            textBoxMinRepeatCount.Margin = new Padding(4);
            textBoxMinRepeatCount.Name = "textBoxMinRepeatCount";
            textBoxMinRepeatCount.Size = new Size(414, 23);
            textBoxMinRepeatCount.TabIndex = 14;
            // 
            // labelMinRepeatCount
            // 
            labelMinRepeatCount.AutoSize = true;
            labelMinRepeatCount.Location = new Point(10, 244);
            labelMinRepeatCount.Margin = new Padding(4, 0, 4, 0);
            labelMinRepeatCount.Name = "labelMinRepeatCount";
            labelMinRepeatCount.Size = new Size(212, 17);
            labelMinRepeatCount.TabIndex = 15;
            labelMinRepeatCount.Text = "请输入最小重复字节数量作为结束条件";
            // 
            // textBoxOutputFormat
            // 
            textBoxOutputFormat.Location = new Point(320, 274);
            textBoxOutputFormat.Margin = new Padding(4);
            textBoxOutputFormat.Name = "textBoxOutputFormat";
            textBoxOutputFormat.Size = new Size(414, 23);
            textBoxOutputFormat.TabIndex = 16;
            // 
            // labelOutputFormat
            // 
            labelOutputFormat.AutoSize = true;
            labelOutputFormat.Location = new Point(10, 277);
            labelOutputFormat.Margin = new Padding(4, 0, 4, 0);
            labelOutputFormat.Name = "labelOutputFormat";
            labelOutputFormat.Size = new Size(140, 17);
            labelOutputFormat.TabIndex = 17;
            labelOutputFormat.Text = "请输入要保存的文件格式";
            // 
            // buttonExtract
            // 
            buttonExtract.Location = new Point(14, 312);
            buttonExtract.Margin = new Padding(4);
            buttonExtract.Name = "buttonExtract";
            buttonExtract.Size = new Size(88, 72);
            buttonExtract.TabIndex = 18;
            buttonExtract.Text = "提取";
            buttonExtract.UseVisualStyleBackColor = true;
            buttonExtract.Click += buttonExtract_Click;
            // 
            // richTextBoxOutput
            // 
            richTextBoxOutput.Location = new Point(126, 312);
            richTextBoxOutput.Margin = new Padding(4);
            richTextBoxOutput.Name = "richTextBoxOutput";
            richTextBoxOutput.Size = new Size(608, 215);
            richTextBoxOutput.TabIndex = 19;
            richTextBoxOutput.Text = "";
            // 
            // textBoxHexAddress
            // 
            textBoxHexAddress.Location = new Point(320, 85);
            textBoxHexAddress.Margin = new Padding(4);
            textBoxHexAddress.Name = "textBoxHexAddress";
            textBoxHexAddress.Size = new Size(414, 23);
            textBoxHexAddress.TabIndex = 20;
            // 
            // labelHexAddress
            // 
            labelHexAddress.AutoSize = true;
            labelHexAddress.Location = new Point(10, 89);
            labelHexAddress.Margin = new Padding(4, 0, 4, 0);
            labelHexAddress.Name = "labelHexAddress";
            labelHexAddress.Size = new Size(106, 17);
            labelHexAddress.TabIndex = 21;
            labelHexAddress.Text = "请输入16进制地址";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(762, 540);
            Controls.Add(labelHexAddress);
            Controls.Add(textBoxHexAddress);
            Controls.Add(richTextBoxOutput);
            Controls.Add(buttonExtract);
            Controls.Add(labelOutputFormat);
            Controls.Add(textBoxOutputFormat);
            Controls.Add(labelMinRepeatCount);
            Controls.Add(textBoxMinRepeatCount);
            Controls.Add(labelEndSequence);
            Controls.Add(textBoxEndSequence);
            Controls.Add(labelStartSequence);
            Controls.Add(textBoxStartSequence);
            Controls.Add(labelEndAddress);
            Controls.Add(textBoxEndAddress);
            Controls.Add(labelStartAddress);
            Controls.Add(textBoxStartAddress);
            Controls.Add(radioButtonMode4);
            Controls.Add(radioButtonMode3);
            Controls.Add(radioButtonMode2);
            Controls.Add(radioButtonMode1);
            Controls.Add(labelDirectoryPath);
            Controls.Add(textBoxDirectoryPath);
            ForeColor = Color.BlueViolet;
            Margin = new Padding(4);
            Name = "Form1";
            Text = "万能二进制提取器";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDirectoryPath;
        private System.Windows.Forms.Label labelDirectoryPath;
        private System.Windows.Forms.RadioButton radioButtonMode1;
        private System.Windows.Forms.RadioButton radioButtonMode2;
        private System.Windows.Forms.RadioButton radioButtonMode3;
        private System.Windows.Forms.RadioButton radioButtonMode4;
        private System.Windows.Forms.TextBox textBoxStartAddress;
        private System.Windows.Forms.Label labelStartAddress;
        private System.Windows.Forms.TextBox textBoxEndAddress;
        private System.Windows.Forms.Label labelEndAddress;
        private System.Windows.Forms.TextBox textBoxStartSequence;
        private System.Windows.Forms.Label labelStartSequence;
        private System.Windows.Forms.TextBox textBoxEndSequence;
        private System.Windows.Forms.Label labelEndSequence;
        private System.Windows.Forms.TextBox textBoxMinRepeatCount;
        private System.Windows.Forms.Label labelMinRepeatCount;
        private System.Windows.Forms.TextBox textBoxOutputFormat;
        private System.Windows.Forms.Label labelOutputFormat;
        private System.Windows.Forms.Button buttonExtract;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
    }
}