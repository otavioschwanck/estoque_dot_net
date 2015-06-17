using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnEstoqueDAO;
using EstoqueDotNet.Data.Entidade;
using MySql.Data.MySqlClient;

namespace EstoqueDotNet.Repository.Repositorio
{
    public class ProdutoRepositorio
    {
        public static List<Produto> GetAll()
        {
            StringBuilder sql = new StringBuilder();

            MySqlCommand cmd = new MySqlCommand();

            List<Produto> produtos = new List<Produto>();



            // sql.Append("select IdConta, QtdKwMes, max(QtdKwMes) ");
            sql.Append("select * ");
            sql.Append("From produtos ");
            sql.Append("order by nome asc");



            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = ConexaoCenter.Get(cmd);

            // MySqlDataReader dr = Conexao.Get(sql.ToString());

            while (dr.Read())
            {
                produtos.Add(
                    new Produto
                    {

                        id_produtos = (int)dr["id_produtos"],
                        nome = (string)dr["nome"],
                        valor_compra = (double)dr["valor_compra"],
                        qtd = (int)dr["qtd"],
                        valor_venda = (double)dr["valor_venda"]
                                               

                    });
            }

            //maximo = sql.Append("select * from maximo");
            //SELECT * FROM vwProdutos
            dr.Close();
            return produtos;
        }

        public static void Create(Produto pProduto)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("insert into produtos (nome, valor_compra, qtd, valor_venda)");
            sql.Append("value (@nome, @valor_compra, @qtd, @valor_venda)");



            cmd.Parameters.AddWithValue("@nome", pProduto.nome);
            cmd.Parameters.AddWithValue("@valor_compra", pProduto.valor_compra);
            cmd.Parameters.AddWithValue("@qtd", pProduto.qtd);
            cmd.Parameters.AddWithValue("@valor_venda", pProduto.valor_venda);


            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            ConexaoCenter.CommandPersist(cmd);


        }

        public static void Delete(int id_produtos)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("DELETE FROM produtos where id_produtos=@id_produtos");


            cmd.Parameters.AddWithValue("@id_produtos", id_produtos);


            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            ConexaoCenter.CommandPersist(cmd);


        }

        public static void Edit(Produto pProduto)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("update produtos ");
            sql.Append("set nome=@nome, valor_compra=@valor_compra, qtd=@qtd, valor_venda=@valor_venda ");
            sql.Append("where id_produtos=@id_produtos");


            cmd.Parameters.AddWithValue("@nome", pProduto.nome);
            cmd.Parameters.AddWithValue("@valor_compra", pProduto.valor_compra);
            cmd.Parameters.AddWithValue("@qtd", pProduto.qtd);
            cmd.Parameters.AddWithValue("@valor_venda", pProduto.valor_venda);



            cmd.CommandText = sql.ToString();

            ConexaoCenter.CommandPersist(cmd);
        }

        public static object GetOne(int id_produtos)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("select * ");
            sql.Append("From produtos ");
            sql.Append("Where id_produtos=@id_produtos");


            cmd.Parameters.AddWithValue("@id_produtos", id_produtos);
            //

            //

            Produto produto;
            cmd.CommandText = sql.ToString();
            MySqlDataReader dr = ConexaoCenter.Get(cmd);

            dr.Read();

            produto = new Produto
            {                

                id_produtos = (int)dr["id_produtos"],
                nome = (string)dr["nome"],
                valor_compra = (double)dr["valor_compra"],
                qtd = (int)dr["qtd"],
                valor_venda = (double)dr["valor_venda"]

            };
            dr.Close();
            return produto;

        }
    }
}
