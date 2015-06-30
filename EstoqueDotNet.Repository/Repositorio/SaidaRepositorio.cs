using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnEstoqueDAO;
using MySql.Data.MySqlClient;
using EstoqueDotNet.Data.Entidade;

namespace EstoqueDotNet.Repository.Repositorio
{
    public class SaidaRepositorio
    {
        public static List<Saida> GetAll()
        {
            StringBuilder sql = new StringBuilder();

            MySqlCommand cmd = new MySqlCommand();

            List<Saida> saidas = new List<Saida>();



            // sql.Append("select IdConta, QtdKwMes, max(QtdKwMes) ");
            sql.Append("select * ");
            sql.Append("From saida ");
            sql.Append("order by id_saida asc");



            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = ConexaoCenter.Get(cmd);

            // MySqlDataReader dr = Conexao.Get(sql.ToString());

            while (dr.Read())
            {
                saidas.Add(
                    new Saida
                    {

                        id_saida = (int)dr["id_saida"],
                        data = (DateTime)dr["data"],
                        descricao = (string)dr["descricao"],
                        caixa_id_caixa = (int)dr["caixa_id_caixa"],
                        produtos_id_produtos = (int)dr["produtos_id_produtos"],
                        qtd = (int)dr["qtd"]

                    });
            }

            dr.Close();
            return saidas;
        }

        public static void Create(Saida pSaida)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("insert into saida (data, descricao, caixa_id_caixa, produtos_id_produtos, qtd)");
            sql.Append("value (@data, @descricao, @caixa_id_caixa, @produtos_id_produtos, @qtd)");



            cmd.Parameters.AddWithValue("@data", pSaida.data);
            cmd.Parameters.AddWithValue("@descricao", pSaida.descricao);
            cmd.Parameters.AddWithValue("@caixa_id_caixa", pSaida.caixa_id_caixa);
            cmd.Parameters.AddWithValue("@produtos_id_produtos", pSaida.produtos_id_produtos);
            cmd.Parameters.AddWithValue("@qtd", pSaida.qtd);


            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            ConexaoCenter.CommandPersist(cmd);


        }

        public static void Delete(int id_saida)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("DELETE FROM saida where id_saida=@id_saida");


            cmd.Parameters.AddWithValue("@id_saida", id_saida);


            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            ConexaoCenter.CommandPersist(cmd);


        }

        public static void Edit(Saida pSaida)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("update saida ");
            sql.Append("set data=@data, descricao=@descricao, caixa_id_caixa=@caixa_id_caixa, produtos_id_produtos=@produtos_id_produtos, qtd=@qtd ");
            sql.Append("where id_saida=@id_saida");


            cmd.Parameters.AddWithValue("@data", pSaida.data);
            cmd.Parameters.AddWithValue("@descricao", pSaida.descricao);
            cmd.Parameters.AddWithValue("@caixa_id_caixa", pSaida.caixa_id_caixa);
            cmd.Parameters.AddWithValue("@produtos_id_produtos", pSaida.produtos_id_produtos);
            cmd.Parameters.AddWithValue("@qtd", pSaida.qtd);



            cmd.CommandText = sql.ToString();

            ConexaoCenter.CommandPersist(cmd);
        }

        public static object GetOne(int id_saida)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("select * ");
            sql.Append("From saida ");
            sql.Append("Where id_saida=@id_saida");


            cmd.Parameters.AddWithValue("@id_saida", id_saida);
            

            Saida saida;
            cmd.CommandText = sql.ToString();
            MySqlDataReader dr = ConexaoCenter.Get(cmd);

            dr.Read();

            saida = new Saida
            {

                id_saida = (int)dr["id_saida"],
                data = (DateTime)dr["data"],
                descricao = (string)dr["descricao"],
                caixa_id_caixa = (int)dr["caixa_id_caixa"],
                produtos_id_produtos = (int)dr["produtos_id_produtos"],
                qtd = (int)dr["qtd"]

                

            };
            dr.Close();
            return saida;

        }
    }
}
