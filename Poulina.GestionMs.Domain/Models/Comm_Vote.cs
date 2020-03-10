using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionMs.Domain.Models
{
    public class Comm_Vote
    {
        public Guid IDCVote { get; set; }

        public Guid FK_Com { get; set; }
        public virtual Commentaire Commentaire { get; set; }
        public Guid FK_Vote { get; set; }
        public virtual Vote Vote { get; set; }

    }
}
