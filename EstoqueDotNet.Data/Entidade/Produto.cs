using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueDotNet.Data.Entidade
{
    public class Produto
    {
        public int id_produtos { get; set; }
        [Display(Name="Nome")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string nome { get; set; }
        [Display(Name = "Valor de Compra")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal valor_compra { get; set; }
        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int qtd { get; set; }
        [Display(Name = "Valor de Venda")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal valor_venda { get; set; }
    }

    
}
