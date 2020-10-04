using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.DAO;
using View.Entidades;

namespace View.Modelo
{
    class UsuarioModelo
    {
        internal static int Inserir(UsuarioEnt objTabela)
        {
            return new UsuarioDAO().Inserir(objTabela);
        }

        internal List<UsuarioEnt> Lista()
        {
            return new UsuarioDAO().Lista();
        }

        internal List<UsuarioEnt> Consulta(UsuarioEnt objTabela)
        {
            return new UsuarioDAO().Consulta(objTabela);
        }

        internal static int Editar(UsuarioEnt objTabela)
        {
            return new UsuarioDAO().Editar(objTabela);
        }

        internal static int Excluir(UsuarioEnt objTabela)
        {
            return new UsuarioDAO().Excluir(objTabela);
        }
    }
}