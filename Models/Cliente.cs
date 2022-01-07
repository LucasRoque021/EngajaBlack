﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EngajaBlack1.Models
{
    public class Cliente
    {
        [Key]
        public int CodigoCliente { get; set; }
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
        public string CreditCard { get; set; }
        public virtual List<Pedido> Pedidos { get; set; }
    }
}
