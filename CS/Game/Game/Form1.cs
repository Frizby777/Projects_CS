            using MetroFramework;
            using System;
            using System.Collections.Generic;
            using System.ComponentModel;
            using System.Data;
            using System.Drawing;
            using System.Linq;
            using System.Text;
            using System.Threading.Tasks;
            using System.Windows.Forms;

            namespace Game
            {
                public partial class Form1 : Form
                {
                    Random random = new Random();

                    List<string> icons = new List<string>() //список значков
                        {
                        "$", "$", "O", "O", "#", "#", "'", "'",  //значки в игре, выбранные символами из алфавита Webding
                        "b", "b", "Z", "Z", "e", "e", "z", "z"
                        };


                    Label firstClicked = null;


                    Label secondClicked = null;

                    private void AssignIconsToSquares() //назначаем кажный знак из списка случайному квадрату
                    {

                        foreach (Control control in tableLayoutPanel1.Controls) //эта строка создает переменную с именем control
                        {
                            Label iconLabel = control as Label; //преобразование переменной control в метку с именем iconLabel
                            if (iconLabel != null) //проверка успешного выполнения преобразования
                            {
                                int randomNumber = random.Next(icons.Count);
                                iconLabel.Text = icons[randomNumber];
                                iconLabel.ForeColor = iconLabel.BackColor; //скрываем значки от игрока
                                icons.RemoveAt(randomNumber);
                            }
                        }
                    }

                    private DateTime t1; //время запуска таймера
                    private DateTime t2; //время срабатывания таймера


                    public Form1()
                    {
                        InitializeComponent(); //вызов нового метода для настройки перед отображением
                        AssignIconsToSquares(); //быстрое заполнение игрового поля значками


                        numericUpDown1.Maximum = 5;
                        numericUpDown1.Minimum = 0;

                        numericUpDown1.TabStop = false;

                        numericUpDown2.Maximum = 59;
                        numericUpDown2.Minimum = 0;


                        numericUpDown2.TabStop = false;


                        button1.Enabled = false; //кнопка ПУСК/СТОП недоступна(таймер2)
                    }





                    private void Form1_Load(object sender, EventArgs e) //событие КЛИК каждого  лейбла
                    {

                    }

                    private void label_Click(object sender, EventArgs e)
                    {
          
                        if (timer1.Enabled == true)
                            return;

                        Label clickedLabel = sender as Label; //преобразовывание из объекта в элемент управления Label

                        if (secondClicked != null)
                            return;

                        if (clickedLabel != null)
                        {
                
                            if (clickedLabel.ForeColor == Color.Black)
                                return;

                            if (firstClicked == null)
                            {
                                firstClicked = clickedLabel;
                                firstClicked.ForeColor = Color.Black;
                                return;
                            }

          
                            secondClicked = clickedLabel;
                            secondClicked.ForeColor = Color.Black;

                
                            CheckForWinner(); //проверка на победителя


                            if (firstClicked.Text == secondClicked.Text) //совпадает ли первый выбранный элемент со вторым
                            {
                                firstClicked = null;
                                secondClicked = null;
                                return;
                            }

                            timer1.Start();
                        }
                    }


                    private void timer1_Tick(object sender, EventArgs e)
                    {
           
                        timer1.Stop(); //остановка таймера, вызывая метод стоп

           
                        firstClicked.ForeColor = firstClicked.BackColor; //делает невидимыми значки двух меток, кт выбрал игрок
                        secondClicked.ForeColor = secondClicked.BackColor;

            
                        firstClicked = null;
                        secondClicked = null;
                    }
                    private void CheckForWinner()
                    {
    
                        foreach (Control control in tableLayoutPanel1.Controls) //проходим по каждой метке в TableLayoutPanel
                        {
                            Label iconLabel = control as Label;

                            if (iconLabel != null)
                            {
                                if (iconLabel.ForeColor == iconLabel.BackColor)
                                    return;
                            }
                        }
                        timer2.Stop();
                        DialogResult result = MessageBox.Show("                 Вы победили!", "ПОЗДРАВЛЯЕМ!                          ");
                        Application.Restart();
                        // Close();
                    }
                    private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
                    {
                        Application.Restart();
                    }

                    private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
                    {
                        this.Close();
                    }

                   #region
        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if ((numericUpDown1.Value == 0) &&
                (numericUpDown2.Value == 0))
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!timer2.Enabled)
            {

                t1 = new DateTime(DateTime.Now.Year,
                    DateTime.Now.Month, DateTime.Now.Day);
                t2 = t1.AddMinutes((double)numericUpDown1.Value);
                t2 = t2.AddSeconds((double)numericUpDown2.Value);

                groupBox1.Enabled = false;
                button1.Text = "Стоп";

                if (t2.Minute < 9)
                    label17.Text = "0" + t2.Minute.ToString() + ":";
                else
                    label17.Text = t2.Minute.ToString() + ":";
                if (t2.Second < 9)
                    label17.Text += "0" + t2.Second.ToString();
                else
                    label17.Text += t2.Second.ToString();

                timer2.Interval = 1000;

                timer2.Enabled = true;

                groupBox1.Visible = false;
            }
            else
            {
                timer2.Enabled = false;
                button1.Text = "Пуск";
                groupBox1.Enabled = true;
                numericUpDown1.Value = t2.Minute;
                numericUpDown2.Value = t2.Second;
            }
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {

            t2 = t2.AddSeconds(-1);

            if (t2.Minute < 9)
                label17.Text = "0" + t2.Minute.ToString() + ":";
            else
                label17.Text = t2.Minute.ToString() + ":";

            if (t2.Second < 9)
                label17.Text += "0" + t2.Second.ToString();
            else
                label17.Text += t2.Second.ToString();
            if (Equals(t1, t2))
            {
                timer2.Enabled = false;
                DialogResult result = MessageBox.Show("Время истекло.                 ", "Конец             ");
                Application.Restart();
                button1.Text = "Пуск";
                groupBox1.Enabled = true;
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
            }
        }
        #endregion
    }
}
