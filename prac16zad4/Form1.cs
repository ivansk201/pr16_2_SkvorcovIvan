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

namespace prac16zad4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();      
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                
                if (long.Parse(textBox1.Text) > 0)
                {
                    Dictionary<string, long> count = new Dictionary<string, long>();
                    using (StreamReader st = new StreamReader("countries.txt"))
                    {
                        string read;
                        while ((read = st.ReadLine()) != null)
                        {                           
                            string[] str = read.Split(' ');
                            string country = str[0];
                            if (str.Length == 4)
                            {
                                long num = long.Parse($"{str[1]}{str[2]}{str[3]}");
                                count[country] = num;
                            }
                            else if (str.Length == 5)
                            {
                                long num = long.Parse($"{str[1]}{str[2]}{str[3]}{str[4]}");
                                count[country] = num;
                            }
                        }
                    }
                    var filter = count.Where(a => a.Value > long.Parse(textBox1.Text)).OrderBy(a => a.Key.Length).ThenBy(a => a.Key);
                    foreach (var con in filter)
                    {
                        listBox1.Items.Add($"{con.Key} {con.Value}");
                    }
                }
                else MessageBox.Show("Невозможно ввести отрицательное число населения", "Сообщение", MessageBoxButtons.OK);
            }
            catch { MessageBox.Show("Было введенно некорректное число!", "Сообщение", MessageBoxButtons.OK); }

        }
    }
}

