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
using System.Text.RegularExpressions;
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
            String lineCB3 = comboBox3.Text;
            Regex tbCB3 = new Regex(@"Компьютер|Ноутбук|Нетбук");
            MatchCollection matchCB3 = tbCB3.Matches(lineCB3);
            if (matchCB3.Count == 1)
            {
                comboBox3.Text = matchCB3[0].Value;


                String line5 = textBox5.Text;
            Regex tb5 = new Regex(@"[A-Z][a-z]+");
            MatchCollection match5 = tb5.Matches(line5);
            if (match5.Count >= 1)
            {

                textBox5.Text = match5[0].Value;

                


                    String line1 = textBox1.Text;
                    Regex tb1 = new Regex(@"[А-Я][а-я]+\s[А-Я][а-я]+\s[А-Я][а-я]+");
                    MatchCollection match1 = tb1.Matches(line1);
                    if (match1.Count >= 1)
                    {

                        textBox1.Text = match1[0].Value;

                        String line2 = textBox2.Text;
                        Regex tb2 = new Regex(@"[0-9]+");
                        MatchCollection match2 = tb2.Matches(line2);
                        if (match2.Count >= 1)
                        {

                            textBox2.Text = match2[0].Value;

                            String lineCB2 = comboBox2.Text;
                        Regex tbCB2 = new Regex(@"Да|Нет");
                        MatchCollection matchCB2 = tbCB2.Matches(lineCB2);
                        if (matchCB2.Count == 1)
                        {
                            comboBox2.Text = matchCB2[0].Value;





                            if (textBox1.Text != "" && comboBox2.Text != "" && textBox5.Text != "" && comboBox3.Text != "" && textBox2.Text != "" && comboBox2.Text != "")
                            {
                                listBox1.Items.Add("Группа: " + comboBox3.Text + ", Модель: " + textBox5.Text + ", Дата: " + dateTimePicker2.Text + ", ФИО: " + textBox1.Text + ", Цена: " + textBox2.Text + "р., Сборка по заказу: " + comboBox2.Text);

                                    textBox1.Clear();
                                    textBox2.Clear();
                                    textBox5.Clear();
                                    comboBox2.SelectedIndex = -1;
                                    comboBox3.SelectedIndex = -1;
                                }
                            else
                            {
                                listBox1.Items.Add("Вы пропустили поле!");
                            }
                            



                        }

                        else
                        {
                            listBox2.Items.Add("Выберите поле 'Сборка по заказу'");
                        }
                    }

                        else
                        {
                            listBox2.Items.Add("Введите корректную цену");
                        }
                    }

                    else
                    {
                        listBox2.Items.Add("Введите корректное ФИО");
                    }
                }

            else
            {
                listBox2.Items.Add("Введите корректную модель ПК");
            }

        }
            else
            {
                listBox2.Items.Add("Выберите корректную группу товара");
            }

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


        

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            int selectedIndex = listBox1.IndexFromPoint(e.Location);

           
            if (selectedIndex != -1)
            {
               
                listBox1.Items.RemoveAt(selectedIndex);
            }
        }




        private void dateTimePicker2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(dateTimePicker2, "Выберите дату подачи заявления абитуриентом");
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, "help.exe");
            }
        }


        private void button9_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    // Загружаем файл и выводим его содержимое в textBox2
                    using (StreamReader streamReader = new StreamReader(openFileDialog.FileName))
                    {
                        comboBox3.Items.Clear();
                        string line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            comboBox3.Items.Add(line);
                        }
                    }
                }
            }
        }

        private void открытьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.FilterIndex = 1;

                
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    
                    string[] lines = File.ReadAllLines(openFileDialog.FileName);
                    foreach (string line in lines)
                    {
                        listBox1.Items.Add(line);
                    }
                }
            }
        }

        private void справкаToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "help.exe");
        }

        private void выйтиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void сохранитьToolStripMenuItem_Click_1(object sender, EventArgs e)
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

    }
}
