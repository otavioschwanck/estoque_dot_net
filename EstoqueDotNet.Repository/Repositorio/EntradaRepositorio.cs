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
    public class EntradaRepositorio
    {
        public static List<Entrada> GetAll()
        {
            StringBuilder sql = new StringBuilder();

            MySqlCommand cmd = new MySqlCommand();

            List<Entrada> entradas = new List<Entrada>();



            // sql.Append("select IdConta, QtdKwMes, max(QtdKwMes) ");
            sql.Append("select * ");
            sql.Append("From entrada ");
            sql.Append("order by data asc");



            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = ConexaoCenter.Get(cmd);

            // MySqlDataReader dr = Conexao.Get(sql.ToString());

            while (dr.Read())
            {
                entradas.Add(
                    new Entrada
                    {

                        id_entrada = (int)dr["id_entrada"],
                        data = (DateTime)dr["data"],
                        descricao = (string)dr["descricao"],
                        caixa_id_caixa = (int)dr["caixa_id_caixa"],
                        produtos_id_produtos = (int)dr["produtos_id_produtos"],
                        qtd = (int)dr["qtd"]


                    });
            }

            //maximo = sql.Append("select * from maximo");
            //SELECT * FROM vwProdutos
            dr.Close();
            return entradas;
        }

        public static void Create(Entrada pEntrada)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("insert into entrada (data, descricao, caixa_id_caixa, produtos_id_produtos, qtd)");
            sql.Append("value (@data, @descricao, @caixa_id_caixa, @produtos_id_produtos, @qtd)");



            cmd.Parameters.AddWithValue("@data", pEntrada.data);
            cmd.Parameters.AddWithValue("@descricao", pEntrada.descricao);
            cmd.Parameters.AddWithValue("@caixa_id_caixa", pEntrada.caixa_id_caixa);
            cmd.Parameters.AddWithValue("@produtos_id_produtos", pEntrada.produtos_id_produtos);
            cmd.Parameters.AddWithValue("@qtd", pEntrada.qtd);


            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            ConexaoCenter.CommandPersist(cmd);


        }

        public static void Delete(int id_entrada)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("DELETE FROM entrada where id_entrada=@id_entrada");


            cmd.Parameters.AddWithValue("@id_entrada", id_entrada);


            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            ConexaoCenter.CommandPersist(cmd);


        }

        public static void Edit(Entrada pEntrada)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("update entrada ");
            sql.Append("set carga_horaria=@carga_horaria, conteudo_prog=@conteudo_prog, nome=@nome, valor=@valor ");
            sql.Append("where id=@id");


            cmd.Parameters.AddWithValue("@data", pEntrada.data);
            cmd.Parameters.AddWithValue("@descricao", pEntrada.descricao);
            cmd.Parameters.AddWithValue("@caixa_id_caixa", pEntrada.caixa_id_caixa);
            cmd.Parameters.AddWithValue("@produtos_id_produtos", pEntrada.produtos_id_produtos);
            cmd.Parameters.AddWithValue("@qtd", pEntrada.qtd);

            cmd.Parameters.AddWithValue("@id", pEntrada.id_entrada);



            cmd.CommandText = sql.ToString();

            ConexaoCenter.CommandPersist(cmd);
        }

        public static object GetOne(int id_entrada)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("select * ");
            sql.Append("From entrada "); 
            sql.Append("Where id_entrada=@id_entrada");


            cmd.Parameters.AddWithValue("@id_entrada", id_entrada);
            //

            //

            Entrada entrada;
            cmd.CommandText = sql.ToString();
            MySqlDataReader dr = ConexaoCenter.Get(cmd);

            dr.Read();

            entrada = new Entrada
            {

                id_entrada = (int)dr["id_entrada"],
                data = (DateTime)dr["data"],
                descricao = (string)dr["descricao"],
                caixa_id_caixa = (int)dr["caixa_id_caixa"],
                produtos_id_produtos = (int)dr["produtos_id_produtos"],
                qtd = (int)dr["qtd"]



            };
            dr.Close();
            return entrada;

        }
    }
}
