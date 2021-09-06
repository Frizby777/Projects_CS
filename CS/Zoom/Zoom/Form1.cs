using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zoom
{
    public partial class Form1 : Form
    {
        info inf = new info();

        Dictionary<int, info> dict = new Dictionary<int, info>();
        public Form1()
        {
            InitializeComponent();

            dict.Add(1, new info() { Name = " А. Н. ", Sname = "Султанова", Login = 4986541574, Password = "L938Gt", Discipline = "Методы психологического воздействия" });
            dict.Add(2, new info() { Name = " Наталия Владимировна", Sname = "Мозолевская", Login = 4683900044, Password = "63ZKhA", Discipline = "Патопсихология" });
            dict.Add(3, new info() { Name = " Ю. В. ", Sname = "Гладышев", Login = 3496394519, Password = "FJDz57", Discipline = "Практикум по оказанию первой мед. помощи" });
            dict.Add(4, new info() { Name = " Лилия Сергеевна", Sname = "Качкина", Login = 7084086956, Password = "7nj3va", Discipline = "Псих. принятие решений в проф. деятельности" });

        }

        private void button1_Click(object sender, EventArgs e)
        {


            foreach (var key in dict.Keys)
            {
                if (textBox1.Text == dict[key].Sname)
                {
                    textBox2.Text = dict[key].Sname + dict[key].Name + Environment.NewLine + "Идентификатор: " + dict[key].Login + Environment.NewLine + "Код: " + dict[key].Password;
                    inf.CopyToLogin = dict[key].Login;
                    inf.CopyToPassword = dict[key].Password;
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var key in dict.Keys)
            {
                if (comboBox1.SelectedItem.Equals(dict[key].Discipline))
                {
                    textBox2.Text = dict[key].Sname + dict[key].Name + Environment.NewLine + "Идентификатор: " + dict[key].Login + Environment.NewLine + "Код: " + dict[key].Password;
                    inf.CopyToLogin = dict[key].Login;
                    inf.CopyToPassword = dict[key].Password;
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
           Clipboard.SetText(inf.CopyToLogin.ToString()); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(inf.CopyToPassword);
        }
    }
}
