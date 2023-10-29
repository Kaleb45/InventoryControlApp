using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Almacen.AutoGen;

[Table("Material")]
public partial class Material
{
    [Key]
    [Column(TypeName = "int")]
    public int? MaterialId { get; set; }

    [Column(TypeName = "int")]
    public int? ModeloId { get; set; }

    [Column(TypeName = "ntext")]
    public string Descripcion { get; set; } = null!;

    [Column(TypeName = "int")]
    public int? YearEntrada { get; set; }

    [Column(TypeName = "int")]
    public int? MarcaId { get; set; }

    [Column(TypeName = "int")]
    public int? CategoriaId { get; set; }

    [Column(TypeName = "int")]
    public int? PlantelId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(255)")]
    [StringLength(255)]
    public string Serie { get; set; } = null!;

    [Column(TypeName = "decimal(18,2)")]
    public decimal? ValorHistorico { get; set; } = null!;

    [ForeignKey("CategoriaId")]
    [InverseProperty("Materiales")]
    public virtual Categoria Categoria { get; set; } = null!;

    [InverseProperty("Material")]
    public virtual ICollection<DescPedido>? DescPedidos { get; set; }

    [ForeignKey("MarcaId")]
    [InverseProperty("Materiales")]
    public virtual Marca Marca { get; set; } = null!;

    [ForeignKey("ModeloId")]
    [InverseProperty("Materiales")]
    public virtual Modelo Modelo { get; set; } = null!;

    [ForeignKey("PlantelId")]
    [InverseProperty("Materiales")]
    public virtual Plantel Plantel { get; set; } = null!;

    [InverseProperty("Material")]
    public virtual ICollection<ReporteMantenimiento>? ReporteMantenimientos { get; set; }
}
