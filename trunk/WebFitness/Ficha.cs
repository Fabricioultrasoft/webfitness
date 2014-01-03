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
    
    public partial class Ficha
    {
        public Ficha()
        {
            this.HistExercicioAluno = new HashSet<HistExercicioAluno>();
        }

        [Display(Name = "C�digo")]
        public int idFicha { get; set; }

        [Display(Name = "Exerc�cio")]
        [Required(ErrorMessage = "Exerc�cio � obrigat�rio!")]
        public int idExercicio { get; set; }

        [Display(Name = "Aluno")]
        [Required(ErrorMessage = "Aluno � obrigat�rio!")]
        public int idAluno { get; set; }

        [Display(Name = "Repeti��es")]
        [Required(ErrorMessage = "Quantidade de repeti��es � obrigat�rio!")]
        public int qtdRepeticoes { get; set; }

        [Display(Name = "Status")]
        public byte status { get; set; }

        [Display(Name = "S�ries")]
        [Required(ErrorMessage = "S�rie de exerc�cio � obrigat�rio!")]
        public int series { get; set; }

        [Display(Name = "Data de Cria��o")]
        public Nullable<System.DateTime> dtCriacao { get; set; }
    
        public virtual Aluno Aluno { get; set; }
        public virtual Exercicio Exercicio { get; set; }
        public virtual ICollection<HistExercicioAluno> HistExercicioAluno { get; set; }
    }
}
