using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class BinnacleData
    {
       
        public static Boolean Recibir(string accion, string error, string msj, string U)
        {
            if (U==null)
            {
                U = "Default";
            }
            var existe = false;
            var Accion = accion;
            var User = U;
            var Error = error;
            var Msj = msj;

            Crear(Accion, User , Error, Msj);
                existe = true;

            return existe;
        }

        public static Boolean Crear(string accion, string user, string error, string msj)
        {
            var existe = false;
            appruebaEntities data = new appruebaEntities();
            var d = new Binnacle
            {
                Actions = accion,
                Users = user, 
                Error = error,
                Messages = msj,
                DateTime = DateTime.Now
            };
            data.Binnacles.Add(d);
            data.SaveChanges();

            if (d != null)
                existe = true;

            return existe;
        }
    }
}