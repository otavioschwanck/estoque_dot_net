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
        public double valor_compra { get; set; }
        public int qtd { get; set; }
        public double valor_venda { get; set; }
    }

    
}
