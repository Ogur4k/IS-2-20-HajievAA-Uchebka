using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectBD;
using MySql.Data.MySqlClient;

namespace Zadanie4
{
    public partial class Ex4 : Form
    {
        public Ex4()
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
        private void Ex4_Load(object sender, EventArgs e)
        {
            сon1 = connect1.Connection();
            Inform();
        }
        public void Inform()
        {
            dtable1.Clear();
            // Запрос выгрузки данных с бд
            string sqlI1 = "SELECT t_database.id AS 'ID', t_database.fio AS 'Имя', t_database.date_of_Birght AS 'Дата рождения', t_database.photoUrl AS 'Фото' FROM t_database;";
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
            dataGridView1.Columns[3].Visible = false;

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ColumnHeadersVisible = true;
            label1.Visible = false;
            //////////////////////////////////
        }
        //Метод Загрузки фото в pictureBox
        void InicilPhoto(string x)
        {
            var p = WebRequest.Create(x);
            using (var pp = p.GetResponse())
            using (var GRS = pp.GetResponseStream())
            {
                pictureBox1.Image = Bitmap.FromStream(GRS);
            }

        }
        //Событие на клик по стоке в dataDrid
        private void DataGridView1_LineClick(object sender, DataGridViewCellEventArgs e)
        {
            //Присваеваем id выбранной кликом строки
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            try
            {
                сon1.Open();
                //Запрос на выборку ссылки изображения из бд
                string sql1 = "SELECT t_database.photoUrl AS 'Фото' FROM t_database WHERE t_database.id = " + id;
                MySqlCommand cmd1 = new MySqlCommand(sql1, сon1);
                string pictur = cmd1.ExecuteScalar().ToString();
                //Отправляем ссылку фото на обработку в метод InicilPhoto
                InicilPhoto(pictur);
                MySqlDataReader reader = cmd1.ExecuteReader();
                сon1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка выгрузки фото " + ex.Message);
            }
        }
        //Вывод данных для сноски под фото 
        private void DataGridView1_CellDoubleClic(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            сon1.Open();
            string i1 = "";
            string i2 = "";
            string i3 = "";
            string i4 = "";
            string sql = $"SELECT t_database.id AS 'ID', t_database.fio AS 'Имя', t_database.date_of_Birght AS 'Дата рождения', t_database.photoUrl AS 'Фото' FROM t_database WHERE t_database.id = " + id;
            MySqlCommand cmd = new MySqlCommand(sql, сon1);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                i1 = reader[0].ToString();
                i2 = reader[1].ToString();
                i3 = reader[2].ToString();
                i4 = reader[3].ToString();
            }
            reader.Close();
            label1.Text = $"Код: " + i1 + "\n" + "Имя: " + i2 + "\n" + "Дата рождения: " + i3;
            label1.Visible = true;
            сon1.Close();
        }
    }
}
