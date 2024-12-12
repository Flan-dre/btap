using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string currentFilePath = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                toolStripComboBox2.Items.Add(s);
            }
        }

        private void heThongToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void taoMoiTapTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Xóa nội dung hiện tại trong RichTextBox
            richTextBox1.Clear();

            // Đặt lại các thuộc tính mặc định (ví dụ: Font, Size, ...)
            richTextBox1.Font = new Font("Arial", 12, FontStyle.Regular);   
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void heThongToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void dinhDangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.ForeColor = fontDlg.Color;
                richTextBox1.Font = fontDlg.Font;
            }
        }

        private void moTapTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|Text files (*.txt)|*.txt|All files (*.*)|*.*";

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Kiểm tra định dạng tệp
                            if (openFileDialog.FileName.EndsWith(".rtf"))
                            {
                                // Nạp nội dung tệp .rtf
                                richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);
                            }
                            else
                            {
                                // Nạp nội dung tệp .txt hoặc các tệp khác dưới dạng văn bản thường
                                richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
                            }

                            // Lưu đường dẫn tệp hiện tại
                            currentFilePath = openFileDialog.FileName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi mở tệp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
            

        private void luuNoiDungVanBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|Text files (*.txt)|*.txt";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        currentFilePath = saveFileDialog.FileName;
                        SaveFile();
                    }
                }
            }
            else
            {
                SaveFile();
            }
        }

        private void SaveFile()
        {
            if (currentFilePath.EndsWith(".rtf"))
            {
                richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
            }
            else
            {
                File.WriteAllText(currentFilePath, richTextBox1.Text);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle style = richTextBox1.SelectionFont.Style;

                if (richTextBox1.SelectionFont.Bold)
                {
                    style &= ~FontStyle.Bold;
                }
                else
                {
                    style |= FontStyle.Bold;
                }

                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle style = richTextBox1.SelectionFont.Style;

                if (richTextBox1.SelectionFont.Italic)
                {
                    style &= ~FontStyle.Italic;
                }
                else
                {
                    style |= FontStyle.Italic;
                }

                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle style = richTextBox1.SelectionFont.Style;

                if (richTextBox1.SelectionFont.Underline)
                {
                    style &= ~FontStyle.Underline;
                }
                else
                {
                    style |= FontStyle.Underline;
                }

                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
            }
        }
    }
}

