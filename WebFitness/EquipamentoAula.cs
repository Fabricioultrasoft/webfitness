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
    
    public partial class EquipamentoAula
    {
        public int idAula { get; set; }
        public int idEquipamento { get; set; }
        public Nullable<System.DateTime> dtCriacao { get; set; }
    
        public virtual Aula Aula { get; set; }
        public virtual Equipamento Equipamento { get; set; }
    }
}
