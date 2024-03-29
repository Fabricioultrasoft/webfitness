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
    
    public partial class Equipamento
    {
        public Equipamento()
        {
            this.Compra = new HashSet<Compra>();
            this.EquipamentoAula = new HashSet<EquipamentoAula>();
            this.ExercicioEquipamento = new HashSet<ExercicioEquipamento>();
            this.Manutencao = new HashSet<Manutencao>();
            this.Venda = new HashSet<Venda>();
        }

        [Display(Name = "C�digo")]
        public int idEquipamento { get; set; }

        [Display(Name = "Descri��o")]
        [StringLength(100, ErrorMessage = "Descri��o n�o pode ter mais que 100 caracteres!")]
        [Required(ErrorMessage = "Descri��o � obrigat�ria!")]
        public string dsEquipamento { get; set; }

        [Display(Name = "Data de Cria��o")]
        public Nullable<System.DateTime> dtCriacao { get; set; }

        [Display(Name = "Status")]
        public Nullable<byte> status_ { get; set; }

        [Display(Name = "Tipo de Equipamento")]
        [Required(ErrorMessage = "Tipo de equipamento � obrigat�rio!")]
        public int idTpEquipamento { get; set; }

        [Display(Name = "Fornecedor")]
        [Required(ErrorMessage = "Fornecedor � obrigat�rio!")]
        public int idFornecedor { get; set; }
    
        public virtual ICollection<Compra> Compra { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual ICollection<EquipamentoAula> EquipamentoAula { get; set; }
        public virtual ICollection<ExercicioEquipamento> ExercicioEquipamento { get; set; }
        public virtual ICollection<Manutencao> Manutencao { get; set; }
        public virtual ICollection<Venda> Venda { get; set; }
    }
}
