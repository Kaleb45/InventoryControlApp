using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AlmacenSQLiteEntities
{
    [Table("Laboratorio")]
    public class Laboratorio
    {
        public Laboratorio()
        {
            Pedidos = new HashSet<Pedido>();
        }

        [Key]
        [Column(TypeName = "int")]
        public int LaboratorioId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50)]
        public string Nombre { get; set; } = null!;

        [Column(TypeName = "ntext")]
        public string Descripcion { get; set; } = null!;

        [InverseProperty("Laboratorio")]
        public virtual ICollection<Pedido>? Pedidos { get; set; }
    }
}
