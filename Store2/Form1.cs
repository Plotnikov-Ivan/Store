using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;



namespace Store2
{
    public partial class Form1 : Form
    {
        StreamReader sr = new StreamReader("Loads.txt");
        Font Font = new Font("Microsoft Sans Serif", 12);
        Store store = new Store();
        List<TextBox> TextBoxes = new List<TextBox>();
        string line;
        List<CheckBox> CheckBoxes = new List<CheckBox>();
        string date = Convert.ToString(DateTime.Now);

        string new_id, new_name, new_date, new_square, new_cost;
        public Form1()
        {
            InitializeComponent();          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            line = sr.ReadLine();
            while (line != null)
            {
                string[] substrings = line.Split(';');
                newLoad(substrings[0], substrings[1], substrings[2], substrings[3], substrings[4]);
                line = sr.ReadLine();
            }
            textBox1.Text = "104";
            textBox2.Text = "Самокаты";
            textBox3.Text = "6870";
            textBox4.Text = "1";
            textBox5.Text = "07.04.2023";
            textBox7.Text = "0";
            sr.Close();
            print_info();

        }

        public void print_info()
        {
            refresh_lists();
            label2.Text = date;
            int y = 300;
            int nubmer = 0;

            if (textBox6.Text != "")
            {
                foreach (Load t in store.get_list2())
                {
                    nubmer++;
                    draw_text_boxes(y, t, nubmer);
                    y += 35;
                }
            }
            else
            {
                foreach (Load t in store.get_list())
                {
                    nubmer++;
                    draw_text_boxes(y, t, nubmer);
                    y += 35;
                }
            }
        }
        private void newLoad(string new_id, string new_name, string new_cost, string new_square, string new_date)
        {
        
            Load newload = new Load(new_name, new_date, Convert.ToInt32(new_id), Convert.ToInt32(new_square), Convert.ToInt32(new_cost));
            store.add_load(newload, newload.GetId);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sum = 0;
            int txt;
            foreach (CheckBox cb in CheckBoxes)
            {
                if (cb.Checked)
                {
                    foreach (TextBox tb in TextBoxes)
                    {
                        if (cb.Location.Y - 6 == tb.Location.Y)
                        {
                            sum+= store.MoneyCount(Int32.Parse(tb.Text));

                            store.delete_load(Int32.Parse(tb.Text));

                            break;
                        }

                    }
                }
            }
            MessageBox.Show(Convert.ToString("Выручка за проданные товары составляет: " + sum + "руб."), "Текущая сделка");
            txt = Convert.ToInt32(textBox7.Text);
            txt += sum;
            textBox7.Text = txt.ToString();
            Delete_ALL();
            print_info();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete_ALL();
            print_info();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                Delete_ALL();

                store.find_loads(Convert.ToInt32(textBox6.Text));

                print_info();

                textBox6.Text = "";
                store.clear_list2();
            }
        }


        private void refresh_lists()
        {
            CheckBoxes.Clear();
            TextBoxes.Clear();
        }


        private void draw_text_boxes(int y, Load t, int number)
        {
            CheckBox newCheckBox = new CheckBox();
            CheckBoxes.Add(newCheckBox);
            Controls.Add(newCheckBox);
            newCheckBox.Location = new Point(14, y + 6);
            newCheckBox.Size = new Size(15, 15);
            newCheckBox.Visible = true;

            TextBox newTextBoxID = new TextBox();
            TextBoxes.Add(newTextBoxID);
            newTextBoxID.Font = Font;
            newTextBoxID.Text = t.GetId.ToString();
            Controls.Add(newTextBoxID);
            newTextBoxID.Location = new Point(textBox1.Location.X + 25, y);
            newTextBoxID.Size = textBox1.Size;
            newTextBoxID.Visible = true;

            TextBox newTextBoxName = new TextBox();
            newTextBoxName.Text = t.GetName;
            Controls.Add(newTextBoxName);
            newTextBoxName.Font = Font;
            newTextBoxName.Location = new Point(textBox2.Location.X + 25 , y);
            newTextBoxName.Size = textBox2.Size;
            newTextBoxName.Visible = true;

            TextBox newTextBoxCost = new TextBox();
            newTextBoxCost.Text = t.GetCost.ToString() + "руб";
            Controls.Add(newTextBoxCost);
            newTextBoxCost.Font = Font;
            newTextBoxCost.Location = new Point(textBox3.Location.X + 25 , y);
            newTextBoxCost.Size = textBox3.Size;
            newTextBoxCost.Visible = true;

            TextBox newTextBoxSquare = new TextBox();
            newTextBoxSquare.Text = t.GetSquare.ToString() + "м^2";
            Controls.Add(newTextBoxSquare);
            newTextBoxSquare.Font = Font;
            newTextBoxSquare.Location = new Point(textBox4.Location.X + 25, y);
            newTextBoxSquare.Size = textBox5.Size;
            newTextBoxSquare.Visible = true;

            TextBox newTextBoxDate = new TextBox();
            newTextBoxDate.Text = t.GetDate;
            Controls.Add(newTextBoxDate);
            newTextBoxDate.Font = Font;
            newTextBoxDate.Location = new Point(textBox5.Location.X + 30, y);
            newTextBoxDate.Size = textBox6.Size;
            newTextBoxDate.Visible = true;

            //TextBox newTextBoxMoney = new TextBox();
            //newTextBoxMoney.Text = store.MoneyCount(sum).ToString();
            //newTextBoxMoney.Font = Font;
            //newTextBoxMoney.Location = new Point(textBox5.Location.X + 30, y);
            //newTextBoxMoney.Size = textBox6.Size;
            //newTextBoxMoney.Visible = true;
        }

        private void Delete_ALL()
        {
            int count = 1;
            while (count != 0)
            {
                count = 0;
                foreach (Control obj in Controls)
                {
                    if ((obj is Button) || (obj is GroupBox))
                    {

                    }
                    else
                    {
                        count++;
                        obj.Dispose();
                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new_id = textBox1.Text;
            new_name = textBox2.Text;
            new_cost = textBox3.Text;
            new_square = textBox4.Text;
            new_date = textBox5.Text;
            newLoad(new_id, new_name, new_cost, new_square, new_date);
            Delete_ALL();
            print_info();
            
        }


    }
}
 