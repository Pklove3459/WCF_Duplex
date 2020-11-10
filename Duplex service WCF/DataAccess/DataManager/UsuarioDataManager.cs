using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataManager
{
    public class UsuarioDataManager
    {
        private readonly JuegoContainer context = new JuegoContainer();

        public bool ExisteNickname(string nickname)
        {
            bool existe = false;

            existe = context.Usuarios.Any(usuario => usuario.Nickname.Equals(nickname));

            return existe;
        }

        public bool EsPasswordCorrecto(string password)
        {
            bool esCorrecto = false;

            esCorrecto = context.Usuarios.Any(usuario => usuario.Password.Equals(password));

            return esCorrecto;
        }
    }
}
