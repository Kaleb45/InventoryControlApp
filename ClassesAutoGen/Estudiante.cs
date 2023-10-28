using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Almacen.AutoGen;

[Table("Estudiante")]
public partial class Estudiante
{
    [Key]
    [Column(TypeName = "int")]
    public int? EstudianteId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    [StringLength(50)]
    public string ApellidoPaterno { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    [StringLength(50)]
    public string ApellidoMaterno { get; set; } = null!;

    [Column(TypeName = "int")]
    public int? SemestreId { get; set; }

    [Column(TypeName = "int")]
    public int? GrupoId { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? Adeudo { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(100)")]
    [StringLength(100)]
    public string Correo { get; set; } = null!;

    [Column(TypeName = "int")]
    public int? PlantelId { get; set; }

    [Column(TypeName = "int")]
    public int? UsuarioId { get; set; }

    [ForeignKey("GrupoId")]
    [InverseProperty("Estudiantes")]
    public virtual Grupo Grupo { get; set; } = null!;

    [InverseProperty("Estudiante")]
    public virtual ICollection<Pedido>? Pedidos { get; set; }

    [ForeignKey("PlantelId")]
    [InverseProperty("Estudiantes")]
    public virtual Plantel Plantel { get; set; } = null!;

    [ForeignKey("SemestreId")]
    [InverseProperty("Estudiantes")]
    public virtual Semestre Semestre { get; set; } = null!;

    [ForeignKey("UsuarioId")]
    [InverseProperty("Estudiantes")]
    public virtual Usuario Usuario { get; set; } = null!;
}
