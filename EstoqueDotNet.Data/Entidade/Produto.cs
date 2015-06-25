using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueDotNet.Data.Entidade
{
    public class Produto
    {
        public int id_produtos { get; set; }
        public string nome { get; set; }
        public decimal valor_compra { get; set; }
        public int qtd { get; set; }
        public decimal valor_venda { get; set; }
    }

    
}
