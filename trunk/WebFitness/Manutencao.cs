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
    
    public partial class Manutencao
    {
        [Display(Name = "C�digo Manuten��o")]
        public int idManutencao { get; set; }

        [Display(Name = "Fornecedor")]
        public int idFornecedor { get; set; }

        [Display(Name = "Tipo de Manuten��o")]
        [Required(ErrorMessage = "Tipo de Manuten��o � obrigatorio!")]
        public int idTpManutencao { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Valor � obrigatorio!")]
        public decimal valorManutencao { get; set; }

        [Display(Name = "Parcelas")]
        [Required(ErrorMessage = "Quantidade de parcelas � obrigatorio!")]
        public int qtdParcelas { get; set; }

        [Display(Name = "Data Manuten��o")]
        [Required(ErrorMessage = "Data de manuten��o � obrigatorio!")]
        public System.DateTime dtManutencao { get; set; }

        [Display(Name = "Data Cria��o")]
        public Nullable<System.DateTime> dtCriacao { get; set; }
        public int idEquipamento { get; set; }
    
        public virtual Equipamento Equipamento { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual TpManutencao TpManutencao { get; set; }
    }
}
