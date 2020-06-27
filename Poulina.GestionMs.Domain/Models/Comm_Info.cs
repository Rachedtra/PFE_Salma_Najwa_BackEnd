using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionMs.Domain.Models
{
    public class Comm_Info
    {
        public Guid IdCinfo { get; set; }

        public virtual Commentaire Commentaires { get; set; }

        public Guid IdCom { get; set; }

        public virtual Demande_information Demande_Information { get; set; }

        public Guid? IdInf { get; set; }

    }
}
