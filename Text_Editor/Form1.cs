using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Text_Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Залиситися?", "Вийти?", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.No)
                Application.Exit();
        }

        private void перенесенняПоСловамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.WordWrap)
            {
                textBox1.WordWrap = false;
                textBox1.ScrollBars = ScrollBars.Both;
                перенесенняПоСловамToolStripMenuItem.Checked = false;

            }
            else
            {
                textBox1.WordWrap = true;
                textBox1.ScrollBars = ScrollBars.Vertical;
                перенесенняПоСловамToolStripMenuItem.Checked = true;
            }
        }

        private void зберегтиЯкToolStripMenuItem_Click(object sender, EventArgs e)
        {

            saveFileDialog1 = new SaveFileDialog();




            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.Create))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(textBox1.Text);
                }
            }
        }

        private void створитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1 = new SaveFileDialog();




            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(textBox1.Text);
                }
            }
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Stream myStream;

            openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    string strfilename = openFileDialog1.FileName;
                    string filetext = File.ReadAllText(strfilename);
                    textBox1.Text = filetext;

                }
            }
        }

        private void вирізатиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectedText != "")
                textBox1.Cut();
        }

        private void копіюватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectionLength > 0)
         
                textBox1.Copy();
        }

        private void вставитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                
                if (textBox1.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                  
                        textBox1.SelectionStart = textBox1.SelectionStart + textBox1.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                textBox1.Paste();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1 = new FontDialog();
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
            }
        }
    }
    }
    
    
    
