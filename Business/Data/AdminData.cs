using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Model;
using Data;


namespace Business.Data
{
    public class AdminData
    {
        public static Boolean Crear(string nombre, string paterno, string materno, string user, string contra, int institutom, string imagen)
        {

            appruebaEntities data = new appruebaEntities();
            Boolean existe = false;

            //var identificador = data.Admins.Select(z => z.AdminsID);


            var g = new Admin
            {

                Name = nombre,
                LastNameP = paterno,
                LastNameM = materno,
                Users = user,
                Pass = contra,
                InstitutionID = institutom,
                Photo = imagen,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = user,
                UserModification = user,
                Status = "1"
            };
            data.Admins.Add(g);
            data.SaveChanges();

            if (g != null)
                existe = true;





            return existe;
        }


        public static List<AdminAllModel> Mostrar(string user)
        {
            using (var Contexto = new appruebaEntities())
            {
                var Resultado = (from adm in Contexto.Admins
                                 where adm.Status == "1" && adm.Users == user
                                 select new AdminAllModel
                                 {
                                     AdminsID = adm.AdminsID,
                                     Name = adm.Name,
                                     LastNameP = adm.LastNameP,
                                     LastNameM = adm.LastNameM,
                                     Users = adm.Users,
                                     Pass = adm.Pass,
                                     InstitutionID = adm.InstitutionID,
                                     Photo = adm.Photo

                                 }).ToList();
                return Resultado;
            }
        }

        public static Boolean Eliminar(int id)
        {
            Boolean existe = false;
            appruebaEntities data = new appruebaEntities();
            var consulta = data.Admins.First(d => d.AdminsID == id);
            if (consulta != null)
            {
                consulta.Status = "0";
                data.SaveChanges();
                existe = true;
            }
            return existe;
        }

        public static List<AdminAllModel> UpdateShow(string user, string pass)
        {
            using (var Contexto = new appruebaEntities())
            {
                var Resultado = (from Admin in Contexto.Admins
                                 where Admin.Users == user && Admin.Pass == pass
                                 select new AdminAllModel
                                 {
                                     AdminsID = Admin.AdminsID,
                                     Name = Admin.Name,
                                     LastNameP = Admin.LastNameP,
                                     LastNameM = Admin.LastNameM,
                                     Users = Admin.Users,
                                     Pass = Admin.Pass,
                                     InstitutionID = Admin.InstitutionID,
                                     Photo = Admin.Photo
                                 }).ToList();
                return Resultado;
            }
        }


        public static Boolean UpdateRegister(string nombre, string lastp, string lastm, string useradmin, string pass, int inst, string ph, string user)
        {
            using (var Contexto = new appruebaEntities())
            {
                Boolean existe = false;

                appruebaEntities data = new appruebaEntities();

                //var identificador = data.Admins.Select(z => z.AdminsID).Where(q)


                var consulta = data.Admins.First(a => a.Users == user);

                if (consulta != null && ph != null)
                {

                    consulta.Name = nombre;
                    consulta.LastNameP = lastp;
                    consulta.LastNameM = lastm;
                    consulta.Users = useradmin;
                    consulta.Pass = pass;
                    consulta.InstitutionID = inst;
                    consulta.Photo = ph;
                    consulta.DateTimeModification = DateTime.Now;
                    consulta.UserModification = user;

                    data.SaveChanges();
                    existe = true;

                }
                else if (consulta != null && ph == null)
                {
                    consulta.Name = nombre;
                    consulta.LastNameP = lastp;
                    consulta.LastNameM = lastm;
                    consulta.Users = useradmin;
                    consulta.Pass = pass;
                    consulta.InstitutionID = inst;
                    consulta.DateTimeModification = DateTime.Now;
                    consulta.UserModification = user;

                    data.SaveChanges();
                    existe = true;
                }
                return existe;
            }
        }


        public static List<AdminInstitutionModel> ObtenerInstitution()
        {
            using (var Contexto = new appruebaEntities())
            {
                var Resultado = (from Institution in Contexto.Institutions
                                 select new AdminInstitutionModel
                                 {
                                     AdminsID = Institution.InstitutionID,
                                     Name = Institution.Name
                                 }).ToList();
                return Resultado;
            }
        }


    }
}