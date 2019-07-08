using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class ValidationData
    {
        public Boolean InsertValidation(string user, string password, string token, DateTime delete)
        {
            appruebaEntities data = new appruebaEntities();
            Boolean status = false;
            var insertToken = new Autentication
            {
                User = user,
                Pass = password,
                Token = token,
                Inssued = DateTime.Now,
                Deleted= delete,
                Status = "1"
            };

            data.Autentications.Add(insertToken);
            data.SaveChanges();

            if (insertToken != null)
                status = true;

            return status;
        }


        public Boolean ValidationToken(string token)
        {
            Boolean status = false;

            using (var Contexto = new appruebaEntities())
            {
                var Resultado = Contexto.Autentications.Where(x => x.Token.Equals(token) && x.Deleted>(DateTime.Now)).FirstOrDefault();
                if (Resultado != null)
                    status = true;
            }
          
            return status;
        }
    }
}