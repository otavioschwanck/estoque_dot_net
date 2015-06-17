using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueDotNet.Data.Entidade
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string nome_completo{ get; set; }
    }
}
