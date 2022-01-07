using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EngajaBlack1.Models
{
    public class Pedido
    {
        [Key]
        public int NumPedido { get; set; }
        public DateTime PrevisaoEntrega { get; set; }
        public DateTime DataPedido { get; set; }
        public float ValorPedido { get; set; }
        [ForeignKey("Cliente")]
        public int CodigoCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        [ForeignKey("Empreendedor")]
        public int CodigoEmpreendedor { get; set; }
        public virtual Empreendedor Empreendedor{ get; set; }
        public virtual List<Produto> Produtos { get; set; }

    }
}
