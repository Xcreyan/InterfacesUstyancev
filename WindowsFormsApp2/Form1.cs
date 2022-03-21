using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Класс кабинета, в конструкторе инициализируются свойства, метод message выводит сообщение
        class CabinetStomatology: IItems
        {
            public CabinetStomatology(int _numberDoctors, int _numberPriems)
            {
                numberDoctors = _numberDoctors;
                numberPriems = _numberPriems;
            }
            public int numberDoctors { get; set; }
            public int numberPriems { get; set; }
            public virtual void message()
            {
                MessageBox.Show($"Количество докторов: {numberDoctors}\nКоличество завершенных приёмов: {numberPriems}");
            }
        }
        //Класс с методом вывода примерных значений всех выполненных приёмов на одного доктора.
        class Priems: CabinetStomatology, IItems
        {
            double x;
            public Priems(int _numberDoctors, int _numberPriems) : base(_numberDoctors, _numberPriems)
            {
                if (numberDoctors != 0)
                {
                    x = Convert.ToDouble(numberPriems) / Convert.ToDouble(numberDoctors);
                }
                else
                {
                    MessageBox.Show("На ноль делить нельзя! Заполните количество докторов");
                }
            }
            public override void message()
            {
                if (numberDoctors != 0)
                {
                    MessageBox.Show($"Примерно приёмов на одного доктора: {x}");
                }
                else 
                { 
                    MessageBox.Show("На ноль делить нельзя! Заполните количество докторов");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0 && textBox2.TextLength > 0)
            {
                CabinetStomatology cabinetStomatology = new CabinetStomatology(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                cabinetStomatology.message();
            }
            else 
            { 
                MessageBox.Show("Заполните все поля");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0 && textBox2.TextLength > 0)
            {
                Priems priems = new Priems(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                priems.message();
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
    }
}
