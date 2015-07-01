using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueDotNet.Data.Entidade
{
    public class Saida
    {
        public int id_saida { get; set; }
        [Display(Name = "Data")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime data { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string descricao { get; set; }
        [Display(Name = "Caixa")]
        public int caixa_id_caixa { get; set; }
        [Display(Name = "Produto")]
        public int produtos_id_produtos { get; set; }
        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int qtd { get; set; }
        
    }
}
       