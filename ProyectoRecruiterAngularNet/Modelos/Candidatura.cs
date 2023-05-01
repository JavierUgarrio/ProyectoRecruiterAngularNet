using System;
using System.Collections.Generic;

namespace ProyectoRecruiterAngularNet.Modelos;

public partial class Candidatura
{
    public int IdCandidatura { get; set; }

    public int IdCliente { get; set; }

    public string Empresa { get; set; } = null!;

    public DateTime FechaAlta { get; set; }

    public DateTime? FechaBaja { get; set; }

    public virtual ICollection<DetalleCandidaturaB> DetalleCandidaturaBs { get; set; } = new List<DetalleCandidaturaB>();

    public virtual Usuario IdClienteNavigation { get; set; } = null!;
}
