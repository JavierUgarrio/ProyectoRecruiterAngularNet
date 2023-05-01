using System;
using System.Collections.Generic;

namespace ProyectoRecruiterAngularNet.Modelos;

public partial class DetalleCandidaturaB
{
    public int IdDetalleCandidatura { get; set; }

    public int IdCandidatura { get; set; }

    public int IdProceso { get; set; }

    public virtual Candidatura IdCandidaturaNavigation { get; set; } = null!;

    public virtual Proceso IdProcesoNavigation { get; set; } = null!;
}
