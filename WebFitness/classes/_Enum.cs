using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFitness
{
    
    public enum Status : byte 
    {
        Ativo = 1,
        Inativo = 0
    }

    public enum TipoFunacionario : byte
    {
        Administrador = 1,
        Instrutor = 2,
        Recepcionista = 3
    }

    public enum TipoContasPagar : byte
    {
        Manutencao = 1,
        Salario = 2,
        Diversas = 3
    }

}
