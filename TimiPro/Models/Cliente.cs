using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimiPro.Models
{
    public class Cliente
    {

        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Nome do Cliente")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Email do Cliente")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF Inválido")]
        public string CPF { get; set; }
        [Required]
        [Display(Name = "Cliente Ativo ?")]
        public bool Ativo { get; set; }
    }
}
