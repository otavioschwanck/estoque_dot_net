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
    public class UsuarioRepositorio
    {
        public static List<Usuario> GetAll()
        {
            StringBuilder sql = new StringBuilder();

            MySqlCommand cmd = new MySqlCommand();

            List<Usuario> usuarios = new List<Usuario>();



            // sql.Append("select IdConta, QtdKwMes, max(QtdKwMes) ");
            sql.Append("select * ");
            sql.Append("From usuarios ");
            sql.Append("order by id_usuario asc");



            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = ConexaoCenter.Get(cmd);

            // MySqlDataReader dr = Conexao.Get(sql.ToString());

            while (dr.Read())
            {
                usuarios.Add(
                    new Usuario
                    {

                        id_usuario = (int)dr["id_usuario"],
                        login = (string)dr["login"],
                        senha = (string)dr["senha"],
                        nome_completo = (string)dr["nome_completo"]

                    });
            }

            dr.Close();
            return usuarios;
        }

        public static void Create(Usuario pUsuario)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("insert into saidas (login, senha, nome_completo)");
            sql.Append("value (@login, @senha, @nome_completo)");



            cmd.Parameters.AddWithValue("@login", pUsuario.login);
            cmd.Parameters.AddWithValue("@senha", pUsuario.senha);
            cmd.Parameters.AddWithValue("@nome_completo", pUsuario.nome_completo);
            




            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            ConexaoCenter.CommandPersist(cmd);


        }

        public static void Delete(int id_usuario)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("DELETE FROM usuarios where id_usuario=@id_usuario");


            cmd.Parameters.AddWithValue("@id_usuario", id_usuario);


            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            ConexaoCenter.CommandPersist(cmd);


        }

        public static void Edit(Usuario pUsuario)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("update usuarios ");
            sql.Append("set login=@login, senha=@senha, nome_completo=@nome_completo ");
            sql.Append("where id_usuario=@id_usuario");


            cmd.Parameters.AddWithValue("@login", pUsuario.login);
            cmd.Parameters.AddWithValue("@senha", pUsuario.senha);
            cmd.Parameters.AddWithValue("@nome_completo", pUsuario.nome_completo);



            cmd.CommandText = sql.ToString();

            ConexaoCenter.CommandPersist(cmd);
        }

        public static object GetOne(int id_usuario)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("select * ");
            sql.Append("From usuarios ");
            sql.Append("Where id_usuario=@id_usuario");


            cmd.Parameters.AddWithValue("@id_usuario", id_usuario);


            Usuario usuario;
            cmd.CommandText = sql.ToString();
            MySqlDataReader dr = ConexaoCenter.Get(cmd);

            dr.Read();

            usuario = new Usuario
            {

                id_usuario = (int)dr["id_usuario"],
                login = (string)dr["login"],
                senha = (string)dr["senha"],
                nome_completo = (string)dr["nome_completo"]


            };
            dr.Close();
            return usuario;

        }
    }
}
