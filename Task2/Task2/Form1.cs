using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            richTextBox1.Text = fileText;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                StringBuilder sb = new StringBuilder();

                foreach (KeyValuePair<string, int> kvp in FindRepeated(richTextBox1.Text))
                {
                    sb.AppendLine(kvp.Key + " Количество " + kvp.Value);
                }
                richTextBox2.Text = sb.ToString();
            }
        }
         private Dictionary<string, int> FindRepeated(string text) {

            Dictionary<string, int> RepeatedWordCount = new Dictionary<string, int>();
            var Value = text.Split(' ');
            for (int i = 0; i < Value.Length; i++)
            {
                if (RepeatedWordCount.ContainsKey(Value[i])) 
                {
                    int value = RepeatedWordCount[Value[i]];
                    RepeatedWordCount[Value[i]] = value + 1;
                }
                else
                {
                    RepeatedWordCount.Add(Value[i], 1);
                    
                }
            }

            return RepeatedWordCount;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, richTextBox2.Text);
        }
    }
}
