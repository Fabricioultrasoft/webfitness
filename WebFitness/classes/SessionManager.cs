using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WebFitness
{
    public static class SessionManager
    {
        public static Funcionario Funcionario
        {
            get
            {
                Funcionario func;
                HttpSessionState sessao = HttpContext.Current.Session;
                
                if (IsAutenticado) 
                {
                    func = (Funcionario)sessao["FUNCIONARIO"];
                }
                else
                {
                    func = new Funcionario();
                    func.nome = "Usuário";
                    func.idTpFuncionario = 888;
                }

                return func;
                
            }
        }

        public static bool IsAutenticado
        {
            get 
			{ 
				HttpSessionState sessao = HttpContext.Current.Session;
                return sessao["FUNCIONARIO"] != null;
			}
        }
        
    }
}