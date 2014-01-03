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
    
    public partial class Exercicio
    {
        public Exercicio()
        {
            this.ExercicioEquipamento = new HashSet<ExercicioEquipamento>();
            this.Ficha = new HashSet<Ficha>();
        }

        [Display(Name = "C�digo")]
        public int idExercicio { get; set; }

        [Display(Name = "Descri��o")]
        [StringLength(100, ErrorMessage = "Descri��o n�o pode ter mais que 100 caracteres!")]
        [Required(ErrorMessage = "Descri��o � obrigat�ria!")]
        public string dsExercicio { get; set; }

        [Display(Name = "Observa��o")]
        [StringLength(200, ErrorMessage = "Observa��o n�o pode ter mais que 200 caracteres!")]
        [Required(ErrorMessage = "Observa��o � obrigat�ria!")]
        public string observacao { get; set; }

        [Display(Name = "Status")]
        public Nullable<byte> status { get; set; }

        [Display(Name = "Data de Cria��o")]
        public System.DateTime dtCriacao { get; set; }

        [Display(Name = "Tipo de Exerc�cio")]
        [Required(ErrorMessage = "Tipo de exerc�cio � obrigat�rio!")]
        public int idTpExercicio { get; set; }
    
        public virtual TpExercicio TpExercicio { get; set; }
        public virtual ICollection<ExercicioEquipamento> ExercicioEquipamento { get; set; }
        public virtual ICollection<Ficha> Ficha { get; set; }
    }
}
