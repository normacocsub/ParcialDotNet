using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Ayudas
    {
        [Key]
        [Column(TypeName = "varchar(4)")]
        public string Numero { get; set; }
        [Column(TypeName = "decimal(12,0)")]
        public decimal ValorApoyo { get; set; }
        [Column(TypeName = "varchar(12)")]
        public string  ModalidadApoyo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }

    }
}