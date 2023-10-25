using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Almacen.AutoGen;

[Table("Coordinador")]
public partial class Coordinador
{
    [Key]
    public long CoordinadorId { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "varchar(50)")]
    public string ApellidoPaterno { get; set; } = null!;

    [Column(TypeName = "varchar(50)")]
    public string ApellidoMaterno { get; set; } = null!;

    [Column(TypeName = "varchar(100)")]
    public string Correo { get; set; } = null!;

    public long PlantelId { get; set; }

    public long UsuarioId { get; set; }

    [InverseProperty("Coordinador")]
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    [ForeignKey("PlantelId")]
    [InverseProperty("Coordinadores")]
    public virtual Plantel Plantel { get; set; } = null!;

    [ForeignKey("UsuarioId")]
    [InverseProperty("Coordinadores")]
    public virtual Usuario Usuario { get; set; } = null!;
}