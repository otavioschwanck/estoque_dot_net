using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueDotNet.Data.Entidade
{
    public class Saida
    {
        public int id_saida { get; set; }
        public DateTime data { get; set; }
        public string descricao { get; set; }
        public int caixa_id_caixa { get; set; }
        public int produtos_id_produtos { get; set; }
        public int qtd { get; set; }
        
    }
}
       