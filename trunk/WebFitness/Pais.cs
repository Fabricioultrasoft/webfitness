//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebFitness
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Pais
    {
        public Pais()
        {
            this.Uf = new HashSet<Uf>();
        }

        [Display(Name = "C�digo")]
        public int idPais { get; set; }

        [Display(Name = "Descri��o")]
        public string dsPais { get; set; }

        [Display(Name = "Abrevia��o")]
        public string abrevPais { get; set; }

        [Display(Name = "Status")]
        public Nullable<byte> status { get; set; }

        [Display(Name = "Data de Cria��o")]
        public System.DateTime dtCriacao { get; set; }
    
        public virtual ICollection<Uf> Uf { get; set; }
    }
}
