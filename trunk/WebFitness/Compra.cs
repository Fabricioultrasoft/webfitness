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
    
    public partial class Compra
    {
        public Compra()
        {
            this.CompraEquipamento = new HashSet<CompraEquipamento>();
        }
    
        public int idCompra { get; set; }
        public Nullable<int> idFornecedor { get; set; }
        public Nullable<decimal> valorCompra { get; set; }
        public Nullable<int> qtdParcelas { get; set; }
        public Nullable<System.DateTime> dtVenda { get; set; }
        public Nullable<System.DateTime> dtCriacao { get; set; }
    
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual ICollection<CompraEquipamento> CompraEquipamento { get; set; }
    }
}
