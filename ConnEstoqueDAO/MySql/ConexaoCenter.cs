using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConnEstoqueDAO
{
    public class ConexaoCenter
    {
        private static MySqlConnection conn = new MySqlConnection();
        private static MySqlCommand cmd = new MySqlCommand();
        private static MySqlDataReader dr;


        private static string StrConn = "Server=localhost" +
                                        ";Port=3306" +
                                        ";Database=cursos" +
                                        ";Uid=root" +
                                        ";Pwd=";

        public static bool Connect()
        {

            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.ConnectionString = StrConn;
                conn.Open();
            }


            return true;
        }



        public static bool Close()
        {
            conn.Close();
            return true;
        }

        public static bool CommandPersist(MySqlCommand pCmd)
        {
            Connect();
            pCmd.Connection = conn;
            pCmd.ExecuteNonQuery();



            return true;
        }

        public static MySqlDataReader Get(MySqlCommand pCmd)
        {
            Connect();

            if (dr != null && !dr.IsClosed)
                dr.Close();

            pCmd.Connection = conn;

            dr = pCmd.ExecuteReader();

            return dr;
        }



    }
}
