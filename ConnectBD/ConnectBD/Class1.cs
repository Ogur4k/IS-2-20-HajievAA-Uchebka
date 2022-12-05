using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConnectBD
{
    public class Connect
    {
        string strConnect;
        MySqlConnection Conn;
        public MySqlConnection Connection()
        {
            Conn = new MySqlConnection(strConnect);
            return Conn;
        }
        public string RCon()
        {
            return strConnect;
        }
        public Connect(string connect)
        {
            strConnect = connect;
        }
    }
}
