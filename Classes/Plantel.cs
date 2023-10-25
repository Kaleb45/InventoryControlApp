using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Almacen.AutoGen;

[Table("Plantel")]
public partial class Plantel
{
    [Key]
    public long PlantelId { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "varchar(100)")]
    public string Direccion { get; set; } = null!;

    public long Telefono { get; set; }

    [InverseProperty("Plantel")]
    public virtual ICollection<Docente> Docentes { get; set; } = new List<Docente>();

    [InverseProperty("Plantel")]
    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
}
