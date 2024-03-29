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

    public partial class TpAula
    {
        public TpAula()
        {
            this.Aula = new HashSet<Aula>();
        }

        [Display(Name = "C�digo")]
        public int idTpAula { get; set; }

        [Display(Name = "Descri��o")]
        [StringLength(100, ErrorMessage = "Descri��o n�o pode ter mais que 100 caracteres!")]
        [Required(ErrorMessage = "Descri��o � obrigat�ria!")]
        public string dsTpAula { get; set; }

        [Display(Name = "Status")]
        public Nullable<byte> status { get; set; }

        [Display(Name = "Data de Cria��o")]
        public Nullable<System.DateTime> dtCriacao { get; set; }
    
        public virtual ICollection<Aula> Aula { get; set; }
    }
}
