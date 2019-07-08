using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Providers
{
    public class Credenciales
    {
        private static string user;
        private static string contra;

        public Credenciales()
        {

        }

        public Credenciales(string u, string c)
        {
            user = u;
            contra = c;

        }

        public string getUsuario()
        {
            return user;
        }

        public string getContra()
        {
            return contra;
        }

    }
}