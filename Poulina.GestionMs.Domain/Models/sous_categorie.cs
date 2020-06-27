using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Poulina.GestionMs.Domain.Models
{
    public class sous_categorie
    {
        [Key]
        public Guid IdSC { get; set; }

        public string Label { get; set; }
        public virtual Categorie Categorie { get; set; }

        public Guid FK_SousCategorie { get; set; }


    }
}
