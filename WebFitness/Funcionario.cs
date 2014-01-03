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
    
    public partial class Funcionario
    {
        public Funcionario()
        {
            this.HistPgtoFuncionario = new HashSet<HistPgtoFuncionario>();
            this.HistSalarioFuncionario = new HashSet<HistSalarioFuncionario>();
        }

        [Display(Name = "C�digo")]
        public int idFuncionario { get; set; }

        [Display(Name = "Nome")]
        [StringLength(100, ErrorMessage = "Nome n�o pode ter mais que 100 caracteres!")]
        [Required(ErrorMessage = "Nome � obrigat�rio!")]
        public string nome { get; set; }

        [Display(Name = "CPF")]
        [StringLength(20, ErrorMessage = "CPF n�o pode ter mais que 20 caracteres!")]
        [Required(ErrorMessage = "CPF � obrigat�rio!")]
        public string cpf { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(20, ErrorMessage = "Telefone n�o pode ter mais que 20 caracteres!")]
        [Required(ErrorMessage = "Telefone � obrigat�rio!")]
        public string telefone { get; set; }

        [Display(Name = "E-mail")]
        [StringLength(100, ErrorMessage = "E-mail n�o pode ter mais que 100 caracteres!")]
        [Required(ErrorMessage = "E-mail � obrigat�ria!")]
        public string email { get; set; }

        [Display(Name = "Endere�o")]
        [StringLength(100, ErrorMessage = "Endere�o n�o pode ter mais que 100 caracteres!")]
        [Required(ErrorMessage = "Endere�o � obrigat�rio!")]
        public string rua { get; set; }

        [Display(Name = "Bairro")]
        [StringLength(100, ErrorMessage = "Bairro n�o pode ter mais que 100 caracteres!")]
        [Required(ErrorMessage = "Bairro � obrigat�rio!")]
        public string bairro { get; set; }

        [Display(Name = "CEP")]
        [StringLength(9, ErrorMessage = "CEP n�o pode ter mais que 9 caracteres!")]
        [Required(ErrorMessage = "CEP � obrigat�rio!")]
        public string cep { get; set; }

        [Display(Name = "CTPS")]
        [StringLength(20, ErrorMessage = "CTPS n�o pode ter mais que 20 caracteres!")]
        [Required(ErrorMessage = "CTPS � obrigat�rio!")]
        public string ctps { get; set; }

        [Display(Name = "Sexo")]
        [StringLength(1, ErrorMessage = "Sexo deve ser M ou F!")]
        [Required(ErrorMessage = "Sexo � obrigat�rio!")]
        public string sexo { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "Data de nascimento � obrigat�ria!")]
        public System.DateTime aniversario { get; set; }

        [Display(Name = "Data de Cria��o")]
        public Nullable<System.DateTime> dtCriacao { get; set; }

        [Display(Name = "Cidade")]
        public int idCidade { get; set; }

        [Display(Name = "Status")]
        public Nullable<byte> status { get; set; }

        [Display(Name = "Tipo de Funcion�rio")]
        [Required(ErrorMessage = "Tipo de funcion�rio � obrigat�rio!")]
        public int idTpFuncionario { get; set; }

        [Display(Name = "Login")]
        [StringLength(100, ErrorMessage = "Login n�o pode ter mais que 100 caracteres!")]
        [Required(ErrorMessage = "Login � obrigat�rio!")]
        public string login { get; set; }

        public string senha { get; set; }
    
        public virtual Cidade Cidade { get; set; }
        public virtual ICollection<HistPgtoFuncionario> HistPgtoFuncionario { get; set; }
        public virtual ICollection<HistSalarioFuncionario> HistSalarioFuncionario { get; set; }
    }
}
