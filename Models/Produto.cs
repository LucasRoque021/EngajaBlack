using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EngajaBlack1.Models
{
    public class Produto
    {
        [Key]
        public int CodigoProduto { get; set; }
        [Required]
        [StringLength(100)]
        public string NomeProduto { get; set; }
        [Required]
        public float ValorProduto { get; set; }
        [Required]
        [StringLength(50)]
        public string Categoria { get; set; }
        [ForeignKey("Pedido")]
        public int NumPedido { get; set; }
        public virtual Pedido Pedido { get; set; }
        [ForeignKey("Empreendedor")]
        public int CodigoEmpreendedor { get; set; }
        public virtual Empreendedor Emprendedor { get; set; }
        [ForeignKey("Fornecedor")]
        public int CodigoFornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}
