using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AlmacenSQLiteEntities
{
    [Table("Grupo")]
    public class Grupo
    {
        public Grupo()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        [Key]
        [Column(TypeName = "int")]
        public int GrupoId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(3)")]
        [StringLength(3)]
        public string Nombre { get; set; } = null!;

        [InverseProperty("Grupo")]
        public virtual ICollection<Estudiante>? Estudiantes { get; set; }
    }
}
