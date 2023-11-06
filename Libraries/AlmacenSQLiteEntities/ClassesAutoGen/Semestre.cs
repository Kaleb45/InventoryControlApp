using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AlmacenSQLiteEntities
{
    [Table("Semestre")]
    public class Semestre
    {
        [Key]
        [Column(TypeName = "int")]
        public int SemestreId { get; set; }

        [Column(TypeName = "int")]
        public int? Numero { get; set; }

        [InverseProperty("Semestre")]
        public virtual ICollection<Estudiante>? Estudiantes { get; set; }
    }
}
