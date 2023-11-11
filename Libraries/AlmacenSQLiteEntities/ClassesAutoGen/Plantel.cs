using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AlmacenSQLiteEntities
{
    [Table("Plantel")]
    public class Plantel
    {
        [Key]
        [Column(TypeName = "int")]
        public int PlantelId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50)]
        public string Nombre { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(100)]
        public string Direccion { get; set; } = null!;

        [Column(TypeName = "BIGINT")]
        public long? Telefono { get; set; }

        [InverseProperty("Plantel")]
        public virtual ICollection<Almacenista>? Almacenistas { get; set; }

        [InverseProperty("Plantel")]
        public virtual ICollection<Coordinador>? Coordinadores { get; set; }

        [InverseProperty("Plantel")]
        public virtual ICollection<Docente>? Docentes { get; set; }

        [InverseProperty("Plantel")]
        public virtual ICollection<Estudiante>? Estudiantes { get; set; }

        [InverseProperty("Plantel")]
        public virtual ICollection<Material>? Materiales { get; set; }
    }
}

