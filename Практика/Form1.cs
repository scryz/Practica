using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;


namespace Практика
{
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }



        private void Загрузить_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" &&  textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != ""  && textBox7.Text != "" && textBox8.Text != "")
            {
                listBox1.Items.Add(textBox5.Text + " " + textBox4.Text + " " + textBox3.Text + " " + textBox2.Text + " "  + textBox1.Text + " " + dateTimePicker2.Text + " " + textBox7.Text + " " + textBox8.Text);
            }
            else
            {
                listBox1.Items.Add("Вы пропустили поле!");
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox7.Clear();
            textBox8.Clear();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox2.Items.AddRange(File.ReadAllLines("Данные.txt"));

        }


        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.Text = listBox2.Text;
        }


        private void textBox8_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox8, "Введите количество баллов по ЕГЭ абитуриента");
        }

        private void textBox7_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox7, "Введите наличие оригинала документов абитуриента");
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox1, "Введите Фамилию, Имя, Отчество абитуриента");
        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox2, "Введите форму обучения (Бюджет/Договор)");
        }

        private void textBox3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox3, "Введите название выбранной абитуриентом спецмальности");
        }

        private void textBox4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox4, "Введите номер выбранной абитуриентом специальности");
        }

        private void textBox5_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox5, "Выберите из списка факультет");
        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button9, "Нажмите, для загрузки списка факультетов");
        }

        private void Загрузить_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(Загрузить, "Нажмите, для загрузки данных абитуриента");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text documents (.txt)|*.txt";

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter w = new StreamWriter(save.FileName);

                foreach (var item in listBox1.Items)
                    w.WriteLine(item.ToString());

                w.Close();
            }
        }

        private void button11_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button11, "Нажмите, для сохранения данных о абитуриенте");
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(File.ReadAllLines("Данные.txt"));
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text documents (.txt)|*.txt";

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter w = new StreamWriter(save.FileName);

                foreach (var item in listBox1.Items)
                    w.WriteLine(item.ToString());

                w.Close();
            }
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            else
                MessageBox.Show("выберите элемент");

        }

        private void listBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(listBox1, "Нажмите дважды на строку, для её удаления");
        }



        private void dateTimePicker2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(dateTimePicker2, "Выберите дату подачи заявления абитуриентом");
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "help.exe");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, "help.exe");
            }
        }
    }
}
