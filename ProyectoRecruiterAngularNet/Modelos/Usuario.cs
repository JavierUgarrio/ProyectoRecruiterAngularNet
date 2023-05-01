using System;
using System.Collections.Generic;

namespace ProyectoRecruiterAngularNet.Modelos;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Telefono { get; set; }

    public int Password { get; set; }

    public DateTime FechaAlta { get; set; }

    public DateTime? FechaBaja { get; set; }

    public virtual ICollection<Candidatura> Candidaturas { get; set; } = new List<Candidatura>();
}
