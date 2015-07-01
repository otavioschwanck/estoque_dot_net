using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EstoqueDotNet.Data.Entidade
{
    public class Caixa
    {
        public int id_caixa { get; set; }
        [Required(ErrorMessage="Campo obrigatório!")]
        [Display(Name="Em caixa")]
        public string em_caixa { get; set; }
        [Required(ErrorMessage="Campo obrigatório")]
        [Display(Name="Nome")]
        public string nome { get; set; }

    }
}
