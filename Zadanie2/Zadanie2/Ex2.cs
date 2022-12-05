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

namespace Zadanie2
{
    public partial class Ex2 : Form
    {
        public Ex2()
        {
            InitializeComponent();
        }
        class Connect
        {
            public static MySqlConnection GetConnection(MySqlConnection mySql)
            {
                try
                {
                    MessageBox.Show("Подключение успешно. Возвращение подключения");
                    return mySql;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка. Подключение не найдено " + ex);
                    return null;
                }
            }
        }

        private void Ex2_Load(object sender, EventArgs e)
        {
            string connect = $"server=chuc.caseum.ru;port=33333;user=uchebka;database=uchebka;password=uchebka;";
            MySqlConnection Connection = new MySqlConnection(connect);
            try
            {
                Connect.GetConnection(Connection);
            }
            catch (Exception ex)
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Ошибка" + ex;
            }
            finally
            {
                label1.ForeColor = Color.Green;
                label1.Text = "Успешное подключение";
            }
        }
    }
}
