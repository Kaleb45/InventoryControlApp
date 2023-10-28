using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Almacen.AutoGen;

[Table("Desc_Pedido")]
public partial class DescPedido
{
    [Key]
    [Column("Desc_PedidoId", TypeName = "int")]
    public int? DescPedidoId { get; set; }

    [Column(TypeName = "int")]
    public int? Cantidad { get; set; }

    [Column(TypeName = "int")]
    public int? PedidoId { get; set; }

    [Column(TypeName = "int")]
    public int? MaterialId { get; set; }

    [ForeignKey("MaterialId")]
    [InverseProperty("DescPedidos")]
    public virtual Material Material { get; set; } = null!;

    [ForeignKey("PedidoId")]
    [InverseProperty("DescPedidos")]
    public virtual Pedido Pedido { get; set; } = null!;
}
