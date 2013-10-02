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
    
    public partial class Funcionario
    {
        public Funcionario()
        {
            this.FuncionarioPermissao = new HashSet<FuncionarioPermissao>();
            this.HistPgtoFuncionario = new HashSet<HistPgtoFuncionario>();
            this.HistSalarioFuncionario = new HashSet<HistSalarioFuncionario>();
        }
    
        public int idFuncionario { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string rua { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string ctps { get; set; }
        public string sexo { get; set; }
        public System.DateTime aniversario { get; set; }
        public Nullable<System.DateTime> dtCriacao { get; set; }
        public int idCidade { get; set; }
        public Nullable<byte> status { get; set; }
        public int idTpFuncionario { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
    
        public virtual Cidade Cidade { get; set; }
        public virtual TpFuncionario TpFuncionario { get; set; }
        public virtual ICollection<FuncionarioPermissao> FuncionarioPermissao { get; set; }
        public virtual ICollection<HistPgtoFuncionario> HistPgtoFuncionario { get; set; }
        public virtual ICollection<HistSalarioFuncionario> HistSalarioFuncionario { get; set; }
    }
}
