﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WebfitnessDBEntities : DbContext
    {
        public WebfitnessDBEntities()
            : base("name=WebfitnessDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<AlunoAula> AlunoAula { get; set; }
        public DbSet<Aula> Aula { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Equipamento> Equipamento { get; set; }
        public DbSet<EquipamentoAula> EquipamentoAula { get; set; }
        public DbSet<Exercicio> Exercicio { get; set; }
        public DbSet<ExercicioEquipamento> ExercicioEquipamento { get; set; }
        public DbSet<Ficha> Ficha { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<HistExercicioAluno> HistExercicioAluno { get; set; }
        public DbSet<HistPgtoAluno> HistPgtoAluno { get; set; }
        public DbSet<HistPgtoFuncionario> HistPgtoFuncionario { get; set; }
        public DbSet<HistSalarioFuncionario> HistSalarioFuncionario { get; set; }
        public DbSet<Manutencao> Manutencao { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<TpAula> TpAula { get; set; }
        public DbSet<TpExercicio> TpExercicio { get; set; }
        public DbSet<TpManutencao> TpManutencao { get; set; }
        public DbSet<Uf> Uf { get; set; }
        public DbSet<Venda> Venda { get; set; }
    }
}
