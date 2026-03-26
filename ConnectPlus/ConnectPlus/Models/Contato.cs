using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Models;

[Table("Contato")]
public partial class Contato
{
    [Key]
    public Guid IdContato { get; set; }

    [Column("nome")]
    [StringLength(150)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [Column("formaContato")]
    [StringLength(100)]
    [Unicode(false)]
    public string FormaContato { get; set; } = null!;

    [Column("imagem")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Imagem { get; set; }

    public Guid IdTipoContato { get; set; }

    [ForeignKey("IdTipoContato")]
    [InverseProperty("Contatos")]
    
    public virtual TipoContato IdTipoContatoNavigation { get; set; } = null!;
}
