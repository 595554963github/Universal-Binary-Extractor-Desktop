using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FileExtractorWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DisableInputBoxes();
        }

        private void DisableInputBoxes()
        {
            radioButtonMode1.Enabled = false;
            radioButtonMode2.Enabled = false;
            radioButtonMode3.Enabled = false;
            radioButtonMode4.Enabled = false;
            textBoxStartSequence.Enabled = false;
            textBoxEndSequence.Enabled = false;
            textBoxMinRepeatCount.Enabled = false;
            textBoxStartAddress.Enabled = false;
            textBoxEndAddress.Enabled = false;
            textBoxOutputFormat.Enabled = false;
            buttonExtract.Enabled = false;
            textBoxHexAddress.Enabled = false;
        }

        private void EnableModeSelection()
        {
            radioButtonMode1.Enabled = true;
            radioButtonMode2.Enabled = true;
            radioButtonMode3.Enabled = true;
            radioButtonMode4.Enabled = true;
        }

        private void EnableInputBoxesBasedOnMode()
        {
            switch (GetSelectedMode())
            {
                case 1:
                    textBoxHexAddress.Enabled = false;
                    textBoxStartAddress.Enabled = false;
                    textBoxEndAddress.Enabled = false;
                    textBoxStartSequence.Enabled = true;
                    textBoxEndSequence.Enabled = true;
                    break;
                case 2:
                    textBoxHexAddress.Enabled = true;
                    textBoxStartAddress.Enabled = false;
                    textBoxEndAddress.Enabled = false;
                    textBoxStartSequence.Enabled = true;
                    textBoxEndSequence.Enabled = true;
                    break;
                case 3:
                    textBoxHexAddress.Enabled = true;
                    textBoxStartAddress.Enabled = false;
                    textBoxEndAddress.Enabled = false;
                    textBoxStartSequence.Enabled = true;
                    textBoxEndSequence.Enabled = true;
                    break;
                case 4:
                    textBoxHexAddress.Enabled = false;
                    textBoxStartAddress.Enabled = true;
                    textBoxEndAddress.Enabled = true;
                    textBoxStartSequence.Enabled = true;
                    textBoxEndSequence.Enabled = true;
                    break;
                default:
                    break;
            }
            textBoxOutputFormat.Enabled = true;
            buttonExtract.Enabled = true;
        }

        private int GetSelectedMode()
        {
            if (radioButtonMode1.Checked) return 1;
            if (radioButtonMode2.Checked) return 2;
            if (radioButtonMode3.Checked) return 3;
            if (radioButtonMode4.Checked) return 4;
            return 0;
        }

        private void textBoxDirectoryPath_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxDirectoryPath.Text) && Directory.Exists(textBoxDirectoryPath.Text))
            {
                EnableModeSelection();
            }
            else
            {
                DisableInputBoxes();
            }
        }

        private void radioButtonMode1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMode1.Checked)
            {
                EnableInputBoxesBasedOnMode();
            }
        }

        private void radioButtonMode2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMode2.Checked)
            {
                EnableInputBoxesBasedOnMode();
            }
        }

        private void radioButtonMode3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMode3.Checked)
            {
                EnableInputBoxesBasedOnMode();
            }
        }

        private void radioButtonMode4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMode4.Checked)
            {
                EnableInputBoxesBasedOnMode();
            }
        }

        private void textBoxEndSequence_TextChanged(object sender, EventArgs e)
        {
            string endSequenceInput = textBoxEndSequence.Text;
            if (!string.IsNullOrEmpty(endSequenceInput))
            {
                byte[] endSequenceBytes = ParseEndSequence(endSequenceInput);
                if (GetSelectedMode() != 1 && endSequenceBytes.Length == 1 && !endSequenceInput.Contains('*'))
                {
                    textBoxMinRepeatCount.Enabled = true;
                }
                else
                {
                    textBoxMinRepeatCount.Enabled = false;
                }
            }
            else
            {
                textBoxMinRepeatCount.Enabled = false;
            }
        }

        static byte[] ParseStartSequence(string startSequenceInput)
        {
            if (string.IsNullOrEmpty(startSequenceInput))
            {
                return Array.Empty<byte>();
            }

            if (startSequenceInput.Contains('*'))
            {
                string[] parts = startSequenceInput.Split('*');
                byte byteValue = Convert.ToByte(parts[0].Replace(" ", ""), 16);
                int repeatCount = int.Parse(parts[1]);
                byte[] result = new byte[repeatCount];
                for (int i = 0; i < repeatCount; i++)
                {
                    result[i] = byteValue;
                }
                return result;
            }
            else
            {
                return StringToByteArray(startSequenceInput.Replace(" ", ""));
            }
        }

        static byte[] ParseEndSequence(string endSequenceInput)
        {
            // 检查输入是否为null或空字符串
            if (string.IsNullOrEmpty(endSequenceInput))
            {
                return Array.Empty<byte>();
            }

            string[] parts = endSequenceInput.Split(' ');
            List<byte> result = new List<byte>();
            foreach (string part in parts)
            {
                if (part.Contains('*'))
                {
                    string[] subParts = part.Split('*');
                    byte byteValue = Convert.ToByte(subParts[0].Replace(" ", ""), 16);
                    int repeatCount = int.Parse(subParts[1]);
                    for (int i = 0; i < repeatCount; i++)
                    {
                        result.Add(byteValue);
                    }
                }
                else
                {
                    result.Add(Convert.ToByte(part.Replace(" ", ""), 16));
                }
            }
            return result.ToArray();
        }

        static int FindEndIndex(byte[] content, int startIndex, byte[]? endSequence, int minRepeatCount, byte[] startSequenceBytes)
        {
            if (endSequence == null || endSequence.Length == 0)
            {
                int nextStartIndex = IndexOfSequence(content, startSequenceBytes, startIndex + 1);
                return nextStartIndex == -1 ? content.Length : nextStartIndex;
            }
            else
            {
                if (minRepeatCount == 0)
                {
                    int endIndex = IndexOfSequence(content, endSequence, startIndex + 1);
                    return endIndex == -1 ? content.Length : endIndex + endSequence.Length;
                }
                else
                {
                    byte byteValue = endSequence[0];
                    int repeatCount = 0;
                    int currentIndex = startIndex + 1;
                    while (currentIndex < content.Length)
                    {
                        if (content[currentIndex] == byteValue)
                        {
                            repeatCount++;
                            if (repeatCount >= minRepeatCount && (minRepeatCount == 0 || (currentIndex + 1 < content.Length && content[currentIndex + 1] != byteValue)))
                            {
                                return currentIndex + 1;
                            }
                        }
                        else
                        {
                            repeatCount = 0;
                        }
                        currentIndex++;
                    }
                    return content.Length;
                }
            }
        }

        static void ExtractContent(string filePath, byte[] startSequenceBytes, byte[]? endSequence = null, string outputFormat = "bin",
                                   string extractMode = "all", string? startAddress = null, string? endAddress = null, int minRepeatCount = 0)
        {
            // 检查输出格式是否为null
            outputFormat = outputFormat ?? "bin";

            try
            {
                byte[] content = File.ReadAllBytes(filePath);
                int startRange = 0;
                int endRange = content.Length;

                if (startAddress != null && endAddress != null)
                {
                    int startIndex = Convert.ToInt32(startAddress.Replace("0x", ""), 16);
                    int endIndex = Convert.ToInt32(endAddress.Replace("0x", ""), 16);
                    if (startIndex > content.Length || endIndex > content.Length || startIndex > endIndex)
                    {
                        Console.WriteLine($"指定地址范围 {startAddress}-{endAddress} 无效，无法提取。");
                        return;
                    }
                    startRange = startIndex;
                    endRange = endIndex;
                }
                else if (startAddress != null)
                {
                    int targetIndex = Convert.ToInt32(startAddress.Replace("0x", ""), 16);
                    if (targetIndex > content.Length)
                    {
                        Console.WriteLine($"指定地址 {startAddress} 超出文件范围，无法提取。");
                        return;
                    }
                    if (extractMode == "before")
                    {
                        startRange = 0;
                        endRange = targetIndex;
                    }
                    else if (extractMode == "after")
                    {
                        startRange = targetIndex;
                        endRange = content.Length;
                    }
                    else
                    {
                        Console.WriteLine("无效的提取模式参数");
                        return;
                    }
                }

                int count = 0;
                int startIndexInContent = startRange;
                while (startIndexInContent < endRange)
                {
                    startIndexInContent = IndexOfSequence(content, startSequenceBytes, startIndexInContent);
                    if (startIndexInContent == -1)
                    {
                        Console.WriteLine($"没有找到更多的起始序列{filePath}");
                        break;
                    }

                    int endIndexInContent = FindEndIndex(content, startIndexInContent, endSequence, minRepeatCount, startSequenceBytes);
                    endIndexInContent = Math.Min(endIndexInContent, endRange);

                    byte[] extractedData = new byte[endIndexInContent - startIndexInContent];
                    Array.Copy(content, startIndexInContent, extractedData, 0, extractedData.Length);

                    string newFilename = $"{Path.GetFileNameWithoutExtension(filePath)}_{count}.{outputFormat}";
                    string? directoryName = Path.GetDirectoryName(filePath);
                    if (directoryName == null)
                    {
                        Console.WriteLine($"无法获取文件 {filePath} 的目录信息，跳过该文件。");
                        continue;
                    }
                    string newFilePath = Path.Combine(directoryName, newFilename);
                    try
                    {
                        File.WriteAllBytes(newFilePath, extractedData);
                        var form = Application.OpenForms.Cast<Form>().OfType<Form1>().FirstOrDefault();
                        if (form != null)
                        {
                            form.richTextBoxOutput.Text += $"提取的内容保存为: {newFilePath}\n";
                        }
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine($"无法写入文件 {newFilePath}，错误信息：{e}");
                        continue;
                    }

                    count++;
                    startIndexInContent = endIndexInContent;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"无法读取文件 {filePath}，错误信息：{e}");
            }
        }

        static int IndexOfSequence(byte[] source, byte[] sequence, int startIndex)
        {
            for (int i = startIndex; i <= source.Length - sequence.Length; i++)
            {
                bool match = true;
                for (int j = 0; j < sequence.Length; j++)
                {
                    if (source[i + j] != sequence[j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    return i;
                }
            }
            return -1;
        }

        static byte[] StringToByteArray(string hex)
        {
            int length = hex.Length;
            byte[] bytes = new byte[length / 2];
            for (int i = 0; i < length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        private void buttonExtract_Click(object sender, EventArgs e)
        {
            string directoryPath = textBoxDirectoryPath.Text;
            if (string.IsNullOrEmpty(directoryPath) || !Directory.Exists(directoryPath))
            {
                MessageBox.Show($"错误: {directoryPath} 不是一个有效的目录。");
                return;
            }

            string extractMode = "";
            string? startAddress = null;
            string? endAddress = null;
            switch (GetSelectedMode())
            {
                case 1:
                    extractMode = "all";
                    break;
                case 2:
                    extractMode = "before";
                    string hexAddress2 = "";
                    if (textBoxHexAddress != null)
                    {
                        hexAddress2 = textBoxHexAddress.Text;
                    }
                    if (!string.IsNullOrEmpty(hexAddress2))
                    {
                        startAddress = hexAddress2;
                    }
                    break;
                case 3:
                    extractMode = "after";
                    if (textBoxHexAddress != null)
                    {
                        string hexAddress3 = textBoxHexAddress.Text;
                        if (!string.IsNullOrEmpty(hexAddress3))
                        {
                            startAddress = hexAddress3;
                        }
                    }
                    break;
                case 4:
                    extractMode = "between";
                    startAddress = textBoxStartAddress.Text;
                    endAddress = textBoxEndAddress.Text;
                    break;
                default:
                    break;
            }

            string startSequenceInput = textBoxStartSequence.Text;
            if (string.IsNullOrEmpty(startSequenceInput))
            {
                MessageBox.Show("起始字节序列为必填项，请输入。");
                return;
            }
            byte[] startSequenceBytes = ParseStartSequence(startSequenceInput);

            string endSequenceInput = textBoxEndSequence.Text;
            int minRepeatCount = 0;
            byte[]? endSequenceBytes = null;
            if (!string.IsNullOrEmpty(endSequenceInput))
            {
                endSequenceBytes = ParseEndSequence(endSequenceInput);
                if (!endSequenceInput.Contains('*') && endSequenceBytes.Length == 1 && int.TryParse(textBoxMinRepeatCount.Text, out minRepeatCount))
                {

                }
            }

            string outputFormat = textBoxOutputFormat.Text;
            if (string.IsNullOrEmpty(outputFormat))
            {
                MessageBox.Show("输出文件格式为必填项，请输入。");
                return;
            }

            string[] files = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                ExtractContent(file, startSequenceBytes, endSequenceBytes, outputFormat, extractMode, startAddress, endAddress, minRepeatCount);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBoxOutput.Text = "";
        }

        private System.Windows.Forms.TextBox textBoxHexAddress;
        private System.Windows.Forms.Label labelHexAddress;
    }
}