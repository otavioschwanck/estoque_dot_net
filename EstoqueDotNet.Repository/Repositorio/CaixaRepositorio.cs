using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnEstoqueDAO;
using EstoqueDotNet.Data.Entidade;
using MySql.Data.MySqlClient;

namespace EstoqueDotNet.Repository
{
    public class CaixaRepositorio
    {
        public static List<Caixa> GetAll()
        {
            StringBuilder sql = new StringBuilder();

            MySqlCommand cmd = new MySqlCommand();

            List<Caixa> caixas = new List<Caixa>();

            sql.Append("select * ");
            sql.Append("From caixa ");
            sql.Append("order by nome asc");

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = ConexaoCenter.Get(cmd);

            while (dr.Read())
            {
                caixas.Add(
                    new Caixa
                    {

                        id_caixa = (int)dr["id_caixa"],
                        em_caixa = (string)dr["em_caixa"],
                        nome = (string)dr["nome"]
                        

                    });
            }

            dr.Close();
            return caixas;

        }

        public static void Create(Caixa pCaixa)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("insert into caixa (em_caixa, nome)");
            sql.Append("value (@em_caixa, @nome)");


            cmd.Parameters.AddWithValue("@em_caixa", pCaixa.em_caixa);            
            cmd.Parameters.AddWithValue("@nome", pCaixa.nome);


            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            ConexaoCenter.CommandPersist(cmd);

        }

        public static void Delete(int id_caixa)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("DELETE FROM caixa where id_caixa=@id_caixa");


            cmd.Parameters.AddWithValue("@id_caixa", id_caixa);


            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            ConexaoCenter.CommandPersist(cmd);

        }

        public static void Edit(Caixa pCaixa)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("update caixa ");
            sql.Append("set em_caixa=@em_caixa, nome=@nome ");
            sql.Append("where id_caixa=@id_caixa");

            cmd.Parameters.AddWithValue("@id_caixa", pCaixa.id_caixa);
            cmd.Parameters.AddWithValue("@em_caixa", pCaixa.em_caixa);
            cmd.Parameters.AddWithValue("@nome", pCaixa.nome);


            cmd.CommandText = sql.ToString();

            ConexaoCenter.CommandPersist(cmd);
        }

        public static object GetOne(int id_caixa)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("select * ");
            sql.Append("From caixa "); 
            sql.Append("Where id_caixa=@id_caixa");


            cmd.Parameters.AddWithValue("@id_caixa", id_caixa);
            

            Caixa caixa;
            cmd.CommandText = sql.ToString();
            MySqlDataReader dr = ConexaoCenter.Get(cmd);

            dr.Read();

            caixa = new Caixa
            {


                id_caixa = (int)dr["id_caixa"],
                em_caixa = (string)dr["em_caixa"],
                nome = (string)dr["nome"],


            };
            dr.Close();
            return caixa;

        }


    }
}
