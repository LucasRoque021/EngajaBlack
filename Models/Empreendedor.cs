using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EngajaBlack1.Models
{
    public class Empreendedor
    {
        [Key]
        public int CodigoEmpreendedor { get; set; }
        [Required]
        public string NomeLoja { get; set; }
        [StringLength(14)]
        public string CNPJ { get; set; }
        public string Ramo { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public  string Comunidade { get; set; }
        [Required]
        public string Estado { get; set; }
        public string HoraAbertura { get; set; }
        public string HoraFechamento { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [StringLength(11)]
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telefone { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        [StringLength(8)]
        public string CEP { get; set; }
        public virtual List<Pedido> Pedidos { get; set; }
        public virtual List<Produto> Produtos { get; set; }

    }
}
