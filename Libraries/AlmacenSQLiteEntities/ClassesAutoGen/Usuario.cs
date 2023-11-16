using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AlmacenSQLiteEntities
{
    [Table("Usuario")]
    public class Usuario
    {
        public Usuario()
        {
            Almacenistas = new HashSet<Almacenista>();
            Coordinadores = new HashSet<Coordinador>();
            Docentes = new HashSet<Docente>();
            Estudiantes = new HashSet<Estudiante>();
        }

        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }

        [Required]
        [Column("Usuario", TypeName = "nvarchar(50)")]
        [StringLength(50)]
        public string Usuario1 { get; set; } = null!;

        
        [Required]
        [Column(TypeName = "nvarchar(8)")]
        [StringLength(8)]
        public string Password { get; set; } = null!;

        [Column(TypeName = "bit")]
        public bool Temporal { get; set; }

        [InverseProperty("Usuario")]
        public virtual ICollection<Almacenista>? Almacenistas { get; set; }

        [InverseProperty("Usuario")]
        public virtual ICollection<Coordinador>? Coordinadores { get; set; }

        [InverseProperty("Usuario")]
        public virtual ICollection<Docente>? Docentes { get; set; }

        [InverseProperty("Usuario")]
        public virtual ICollection<Estudiante>? Estudiantes { get; set; }
    }
}