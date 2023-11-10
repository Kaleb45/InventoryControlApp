using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AlmacenSQLiteEntities
{


    [Table("Pedido")]
    public class Pedido
    {
        [Key]
        [Column(TypeName = "int")]
        public int PedidoId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? Fecha { get; set; }

        [Column(TypeName = "int")]
        public int? LaboratorioId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? HoraEntrega { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? HoraDevolucion { get; set; }

        [Column(TypeName = "int")]
        public int? EstudianteId { get; set; }

        
        [Column(TypeName = "int")]
        public int? DocenteId { get; set; }

        [Column(TypeName = "bit")]
        public bool Estado { get; set; }

        [InverseProperty("Pedido")]
        public virtual ICollection<DescPedido>? DescPedidos { get; set; }

        [ForeignKey("DocenteId")]
        [InverseProperty("Pedidos")]
        public virtual Docente Docente { get; set; } = null!;

        [ForeignKey("EstudianteId")]
        [InverseProperty("Pedidos")]
        public virtual Estudiante Estudiante { get; set; } = null!;

        [ForeignKey("LaboratorioId")]
        [InverseProperty("Pedidos")]
        public virtual Laboratorio Laboratorio { get; set; } = null!;
    }
}
