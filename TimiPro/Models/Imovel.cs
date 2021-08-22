using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimiPro.Models
{
    public class Imovel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Tipo de Negócio")]
        public string TipoNegocio { get; set; }
        [Required]
        [Display(Name = "Valor de Imóvel")]
        public float Valor { get; set; }
        [Display(Name = "Descrição do Imóvel")]
        public string Descricao { get; set; }
        [Required]
        [Display(Name = "Imóvel Ativo ?")]
        public bool Ativo { get; set; }
        [Display(Name = "Nome do Cliente Relacionado ao Imóvel")]
        public string ClienteNome { get; set; }

    }
}
