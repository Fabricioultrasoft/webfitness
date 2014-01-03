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
    
    public partial class Fornecedor
    {
        public Fornecedor()
        {
            this.Compra = new HashSet<Compra>();
            this.Equipamento = new HashSet<Equipamento>();
            this.Manutencao = new HashSet<Manutencao>();
        }

        [Display(Name = "C�digo")]
        public int idFornecedor { get; set; }

        [Display(Name = "Descri��o")]
        [StringLength(100, ErrorMessage = "Descri��o n�o pode ter mais que 100 caracteres!")]
        [Required(ErrorMessage = "Descri��o � obrigat�ria!")]
        public string dsFornecedor { get; set; }

        [Display(Name = "CNPJ")]
        [StringLength(20, ErrorMessage = "CNPJ n�o pode ter mais que 20 caracteres!")]
        [Required(ErrorMessage = "CNPJ � obrigat�rio!")]
        public string cnpj { get; set; }

        [Display(Name = "Inscri��o Estadual")]
        [StringLength(20, ErrorMessage = "Inscri��o estadual n�o pode ter mais que 20 caracteres!")]
        [Required(ErrorMessage = "Inscri��o estadual � obrigat�ria!")]
        public string inscrEstadual { get; set; }

        [Display(Name = "Endere�o")]
        [StringLength(100, ErrorMessage = "Endere�o n�o pode ter mais que 100 caracteres!")]
        [Required(ErrorMessage = "Endere�o � obrigat�rio!")]
        public string rua { get; set; }

        [Display(Name = "Bairro")]
        [StringLength(100, ErrorMessage = "Bairro n�o pode ter mais que 100 caracteres!")]
        [Required(ErrorMessage = "Bairro � obrigat�rio!")]
        public string bairro { get; set; }

        [Display(Name = "E-mail")]
        [StringLength(100, ErrorMessage = "E-mail n�o pode ter mais que 100 caracteres!")]
        [Required(ErrorMessage = "E-mail � obrigat�rio!")]
        public string email { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(20, ErrorMessage = "Telefone n�o pode ter mais que 20 caracteres!")]
        [Required(ErrorMessage = "Telefone � obrigat�rio!")]
        public string telefone { get; set; }

        [Display(Name = "Data de Cria��o")]
        public Nullable<System.DateTime> dtCriacao { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Cidade � obrigat�ria!")]
        public int idCidade { get; set; }

        [Display(Name = "Status")]
        public Nullable<byte> status { get; set; }
    
        public virtual Cidade Cidade { get; set; }
        public virtual ICollection<Compra> Compra { get; set; }
        public virtual ICollection<Equipamento> Equipamento { get; set; }
        public virtual ICollection<Manutencao> Manutencao { get; set; }
    }
}
