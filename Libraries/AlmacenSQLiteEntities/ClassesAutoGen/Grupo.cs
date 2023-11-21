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

        [Required(ErrorMessage = "El campo Grupo es obligatorio.")]
        [Column(TypeName = "nvarchar(3)")]
        [StringLength(2, ErrorMessage = "El campo Grupo debe tener dos caracteres, uno númerico y uno albabetico.")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Solo se permiten letras y números en el nombre del grupo.")]
        public string Nombre { get; set; } = null!;

        [InverseProperty("Grupo")]
        public virtual ICollection<Estudiante>? Estudiantes { get; set; }
    }
}
