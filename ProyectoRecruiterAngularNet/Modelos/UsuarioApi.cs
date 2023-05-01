using System;
using System.Collections.Generic;

namespace ProyectoRecruiterAngularNet.Modelos;

public partial class UsuarioApi
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public int Password { get; set; } 

    public string FechaAlta { get; set; } = null!;

    public string? FechaBaja { get; set; }
}
