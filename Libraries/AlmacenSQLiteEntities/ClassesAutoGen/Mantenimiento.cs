using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AlmacenSQLiteEntities
{

    [Table("Mantenimiento")]
    public class Mantenimiento
    {
        [Key]
        [Column(TypeName = "int")]
        public int MantenimientoId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50)]
        public string Nombre { get; set; } = null!;

        [Column(TypeName = "ntext")]
        public string Descripcion { get; set; } = null!;

        [InverseProperty("Mantenimiento")]
        public virtual ICollection<ReporteMantenimiento>? ReporteMantenimientos { get; set; }
    }

}
