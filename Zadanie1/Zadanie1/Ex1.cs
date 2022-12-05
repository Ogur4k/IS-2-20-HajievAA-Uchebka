using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie1
{
    public partial class Ex1 : Form
    {
        public Ex1()
        {
            InitializeComponent();
        }
        abstract class Complect<T>
        {
            public int cost;
            public int age;
            public T Artic;
            public Complect(int age, int cost, T acr)
            {
                this.cost = cost;
                this.age = age;
                Artic = acr;
            }

            public virtual string Display()
            {

                return $"Цена: {cost}р \n Год выпуска: {age}г \n Артикул:{Artic}";
            }
        }
        class HDD<T> : Complect<T>
        {
            int Turnover;
            int Turn
            {
                get
                {
                    return Turnover;
                }
                set
                {
                    Turnover = value;
                }
            }
            string Ifac;
            string ifac
            {
                get
                {
                    return Ifac;
                }
                set
                {
                    Ifac = value;
                }
            }

            int Volume;
            int val
            {
                get
                {
                    return Volume;
                }
                set
                {
                    Volume = value;
                }
            }
            public HDD(int cost, int age, T arc, int turn, string iface, int vol) : base(cost, age, arc)
            {
                Turn = turn;
                ifac = iface;
                val = vol;
            }
            public override string Display()
            {
                return $"Цена: {cost}р \n Год выпуска: {age}г \n Артикул:{Artic} \n Количество оборотов: {Turn}об/мин \n Интерфейс: {ifac} \n Объем: {val}Гб \n ";
            }
        }
        class VCard<T> : Complect<T>
        {
            int Freq;
            int freq
            {
                get
                {
                    return Freq;
                }
                set
                {
                    Freq = value;
                }
            }
            string Manufacturer;
            string manufacturer
            {
                get
                {
                    return Manufacturer;
                }
                set
                {
                    Manufacturer = value;
                }
            }
            int Memory;
            int memory
            {
                get
                {
                    return Memory;
                }
                set
                {
                    Memory = value;
                }
            }
            public VCard(int cost, int age, T arc, int fq, string man, int mem) : base(cost, age, arc)
            {
                freq = fq;
                manufacturer = man;
                memory = mem;
            }
            public override string Display()
            {
                return $"Цена: {cost}р \n Год выпуска: {age}г \n Артикул:{Artic} \n Частота: {freq}Гц \n Производитель: {manufacturer} \n Объем памяти: {memory}Гб \n ";
            }
        }
        HDD<int> hdd;
        VCard<int> vc;
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                int cost = Convert.ToInt32(textBox1.Text);
                int age = Convert.ToInt32(textBox2.Text);
                int tur = Convert.ToInt32(textBox3.Text);
                string ifac = textBox4.Text;
                int vol = Convert.ToInt32(textBox5.Text);
                int arc = Convert.ToInt32(textBox9.Text);
                hdd = new HDD<int>(cost, age, arc, tur, ifac, vol);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                listBox1.Items.Add(hdd.Display());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int cost = Convert.ToInt32(textBox1.Text);
                int age = Convert.ToInt32(textBox2.Text);
                int freq = Convert.ToInt32(textBox6.Text);
                string manuf = textBox7.Text;
                int memo = Convert.ToInt32(textBox8.Text);
                int arc = Convert.ToInt32(textBox9.Text);
                vc = new VCard<int>(cost, age, arc, freq, manuf, memo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                listBox1.Items.Add(vc.Display());
            }
        }
    }
}
