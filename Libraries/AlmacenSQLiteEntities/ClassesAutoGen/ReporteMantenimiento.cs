using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AlmacenSQLiteEntities
{

    [Table("ReporteMantenimiento")]
    public class ReporteMantenimiento
    {
        [Key]
        [Column(TypeName = "int")]
        public int ReporteMantenimientoId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? Fecha { get; set; }

        [Column(TypeName = "int")]
        public int? MantenimientoId { get; set; }

        [Column(TypeName = "int")]
        public int? MaterialId { get; set; }

        [ForeignKey("MantenimientoId")]
        [InverseProperty("ReporteMantenimientos")]
        public virtual Mantenimiento Mantenimiento { get; set; } = null!;

        [ForeignKey("MaterialId")]
        [InverseProperty("ReporteMantenimientos")]
        public virtual Material Material { get; set; } = null!;
    }
}