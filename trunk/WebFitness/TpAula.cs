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
    
    public partial class TpAula
    {
        public TpAula()
        {
            this.Aula = new HashSet<Aula>();
        }
    
        public int idTpAula { get; set; }
        public string dsTpAula { get; set; }
        public Nullable<byte> status { get; set; }
        public Nullable<System.DateTime> dtCriacao { get; set; }
    
        public virtual ICollection<Aula> Aula { get; set; }
    }
}