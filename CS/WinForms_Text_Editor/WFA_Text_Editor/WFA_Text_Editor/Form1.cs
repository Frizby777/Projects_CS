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

namespace WFA_Text_Editor
{
    public partial class Form1 : Form
    {
        Editor editor;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                editor = new Editor(folderBrowserDialog1.SelectedPath);
                button2.Enabled = true;
                button3.Enabled = true;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            saveFileDialog1.InitialDirectory = editor.Path;
            saveFileDialog1.InitialDirectory = "Text(*txt)|*.txt";
            saveFileDialog1.Filter = "Text(*txt)|*.txt";

            if (editor.Lengh != textBox1.TextLength)
            {
                var mess = MessageBox.Show("Хотите выполнить перезапись файла?", "Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (mess == DialogResult.Yes)
                {
                    DialogResult save = saveFileDialog1.ShowDialog();
                    if (save == DialogResult.OK)
                    {
                        editor.Results = textBox1.Text;
                        editor.Save(saveFileDialog1.FileName);
                        dateTimePicker2.Value = DateTime.Now;
                    }
                }
                else
                {
                    textBox1.Text = editor.Results;
                }
            }
            else
            {
                DialogResult save = saveFileDialog1.ShowDialog();
                if (save == DialogResult.OK)
                {
                    editor.Results = textBox1.Text;
                    editor.Save(saveFileDialog1.FileName);
                    dateTimePicker2.Value = DateTime.Now;
                }
            }




            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = editor.Path;
            
            openFileDialog1.FileName = ".txt";
            openFileDialog1.Filter = "Text(*txt)|*.txt";

            if (editor.Lengh != textBox1.TextLength)
            {
                var mess = MessageBox.Show("Хотите сохранить  файл как новый?", "Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                if (mess == DialogResult.Yes)
                {
                    DialogResult save = saveFileDialog1.ShowDialog();
                    if (save == DialogResult.OK)
                    {
                        editor.Results = textBox1.Text;
                        editor.Save(saveFileDialog1.FileName);
                        dateTimePicker2.Value = DateTime.Now;
                    }
                }
                else
                {
                    DialogResult result = openFileDialog1.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        editor.Open(openFileDialog1.FileName);
                        openFileDialog1.FileName = ".txt";
                        textBox1.Text = editor.Results;
                        editor.Lengh = textBox1.TextLength;
                        dateTimePicker1.Value = editor.DateCreate;
                        dateTimePicker2.Value = editor.DateEdit;
                    }
                }
            }
            else
            {
                DialogResult result = openFileDialog1.ShowDialog();

                if (result == DialogResult.OK)
                {
                    editor.Open(openFileDialog1.FileName);
                    openFileDialog1.FileName = ".txt";
                    textBox1.Text = editor.Results;
                    editor.Lengh = textBox1.TextLength;
                    dateTimePicker1.Value = editor.DateCreate;
                    dateTimePicker2.Value = editor.DateEdit;
                }
            }
           

        }
    }
}
