using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ConnectBD;

namespace Zadanie5
{
    public partial class Ex5 : Form
    {
        public Ex5()
        {
            InitializeComponent();
        }
        MySqlConnection сon1;
        //Открываем доступ к бд
        Connect connect1 = new Connect("server=chuc.caseum.ru;port=33333;username=st_2_20_28;password=29461060;database=is_2_20_st28_KURS");
        //Создаем виртуальную таблицу
        DataTable dtable1 = new DataTable();
        MySqlDataAdapter medtable1 = new MySqlDataAdapter();
        BindingSource bs1 = new BindingSource();
        public void Inform()
        {
            dtable1.Clear();
            // Запрос выгрузки данных с бд
            string sqlI1 = "SELECT t_Uchebka_Hajiev.idStud AS 'Код', t_Uchebka_Hajiev.fioStud AS 'Имя', t_Uchebka_Hajiev.datatimeStud AS 'Дата рождения' FROM t_Uchebka_Hajiev;";
            сon1.Open();
            // Заполнение полей dataGrid данными с бд
            medtable1.SelectCommand = new MySqlCommand(sqlI1, сon1);
            medtable1.Fill(dtable1);

            bs1.DataSource = dtable1;

            dataGridView1.DataSource = bs1;
            сon1.Close();
            ////Настройка полей dataGrid////
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ColumnHeadersVisible = true;
            //////////////////////////////////
            label3.Visible = false;
        }

        private void Ex5_Load(object sender, EventArgs e)
        {
            //Создаем подключения к главному меню задания и запрашиваем метод дял заполнения dataGrid'a
            сon1 = connect1.Connection();
            Inform();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Присваеваем значения данным из текстбокса
            string fio = textBox1.Text;
            string data = textBox2.Text;
            try
            {
                сon1.Open();
                //Вводим запрос на добавление данных в БД. Используем @a и @b в качестве временных переменных
                string str3 = "INSERT INTO `t_Uchebka_Hajiev` (fioStud, datatimeStud) VALUES (@a, @b)";
                MySqlCommand cmd = new MySqlCommand(str3, сon1);
                //присваеваем значения текстбоксов временным переменным, отрправляя их в запрос и кк следствие в БД 
                cmd.Parameters.Add("@a", MySqlDbType.VarChar).Value = fio;
                cmd.Parameters.Add("@b", MySqlDbType.VarChar).Value = data;
                //Возвращает количество измененных записей
                cmd.ExecuteNonQuery();
                сon1.Close();
            }
            catch (Exception ex)
            {
                //Выводим сообщение об ошибке, если такова имеется
                label3.Visible = true;
                label3.ForeColor = Color.Red;
                label3.Text = ("Ошибка добавления строки" + ex);
            }
            finally
            {
                //Уведомляем пользователя о успешном добавлении строки в БД
                label3.Visible = true;
                label3.ForeColor = Color.Green;
                label3.Text = "Строка добавлена";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Вызываем метод для обновления содержимого dataGrid'a
            Inform();
        }
    }
}
