using System;
using System.Collections.Generic;

namespace ProyectoRecruiterAngularNet.Modelos;

public partial class Proceso
{
    public int IdProceso { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Cliente { get; set; } = null!;

    public DateTime FechaAlta { get; set; }

    public DateTime? FechaBaja { get; set; }

    public virtual ICollection<DetalleCandidaturaB> DetalleCandidaturaBs { get; set; } = new List<DetalleCandidaturaB>();
}
