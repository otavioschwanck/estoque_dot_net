using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace EstoqueDotNet
{
    public partial class Acesso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Connection string for a typical local MySQL installation
                string connString = "Server=localhost;Database=banco_estoque;Uid=root;Pwd=";

                // Create a connection object and data adapter
                MySqlConnection cnx = new MySqlConnection(connString);

                //Take the strings from text box
                string user = txtUser.Text;
                string pass = txtPass.Text;

                //Open Conection
                cnx.Open();

             //   connString = new DataSet();


               MySqlCommand user_verify = new MySqlCommand("select * from usuario WHERE login = '" + txtUser.Text.Trim() + "' AND senha = '" + txtPass.Text.Trim() + "' LIMIT 1", cnx);
               
                bool user_result = user_verify.ExecuteReader().HasRows;

                lblStatus.Text = user_result.ToString();
                if (user_result == true)
                {
                    Response.Redirect ("http://localhost:1866/Saida");
                 
                    bool k = true;
                }
                else
                {
                    bool k = false;
                }
            }

            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }

       


    }
}