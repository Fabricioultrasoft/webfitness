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
        [Display(Name = "C�digo")]
        public int idManutencao { get; set; }

        [Display(Name = "Fornecedor")]
        [Required(ErrorMessage = "Fornecedor � obrigat�rio!")]
        public int idFornecedor { get; set; }

        [Display(Name = "Tipo de Manuten��o")]
        [Required(ErrorMessage = "Tipo de manuten��o � obrigat�ria!")]
        public int idTpManutencao { get; set; }

        [Display(Name = "Valor Manuten��o")]
        [Required(ErrorMessage = "Valor da manuten��o � obrigat�ria!")]
        public decimal valorManutencao { get; set; }

        [Display(Name = "Quantidade Parcelas")]
        [Required(ErrorMessage = "Quantidade de parcelas � obrigat�ria!")]
        public int qtdParcelas { get; set; }

        [Display(Name = "Data de Manuten��o")]
        [Required(ErrorMessage = "Data de manuten��o � obrigat�ria!")]
        public System.DateTime dtManutencao { get; set; }

        [Display(Name = "Data de Cria��o")]
        public Nullable<System.DateTime> dtCriacao { get; set; }

        [Display(Name = "C�digo")]
        public int idEquipamento { get; set; }
    
        public virtual Equipamento Equipamento { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual TpManutencao TpManutencao { get; set; }
    }
}
