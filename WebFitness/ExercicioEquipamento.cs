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
    
    public partial class ExercicioEquipamento
    {
        [Display(Name = "Exerc�cio")]
        [Required(ErrorMessage = "Exerc�cio � obrigat�rio!")]
        public int idExercicio { get; set; }

        [Display(Name = "Equipamento")]
        [Required(ErrorMessage = "Equipamento � obrigat�rio!")]
        public int idEquipamento { get; set; }

        [Display(Name = "Data de Cria��o")]
        public Nullable<System.DateTime> dtCriacao { get; set; }
    
        public virtual Equipamento Equipamento { get; set; }
        public virtual Exercicio Exercicio { get; set; }
    }
}
