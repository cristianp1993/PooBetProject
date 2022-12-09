using BetProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BetProject.Repositorys
{
    public class PersonRepository:GenericRepository<persona>
    {

        

        public bool Login(string user, string password)
        {
            try
            {
                bool result = false;
                using (BetProjectEntities db = new BetProjectEntities())
                {

                    var data = db.persona.Where(xh => xh.per_documento == user && xh.per_contrasena == password).ToList();

                    if (data.Count> 0)
                    {
                        result = true;
                    }
                }

                return result;
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public string SaveNewUser(persona Model)
        {
            try
            {
                string result = "";

                using (BetProjectEntities db = new BetProjectEntities())
                {
                    var person = db.Set<persona>();
                    //person.Add(new persona { per_documento = Model.per_documento, per_nombre = Model.per_nombre,per_correo= Model.per_correo, per_contrasena= Model.per_contrasena,per_fecha_nac= Model.per_fecha_nac });
                    person.Add(Model);

                    db.SaveChanges();

                    result = "OK";
                }

                return result;
            }
            catch (Exception e)
            {

                throw;
            }
        }


        public IEnumerable<SelectListItem> GetBetPlayers()
        {
            try
            {
                List<SelectListItem> lista = new List<SelectListItem>();


                using (BetProjectEntities db = new BetProjectEntities())
                {

                    lista = db.persona.Select(c => new SelectListItem { 
                    
                        Text = c.per_nombre,
                        Value = c.per_documento
                    
                    }).ToList();

                    lista.Insert(0, new SelectListItem
                    {
                        Text = "Seleccione un Apostador",
                        Value = "0"
                    });
                }

                

                return lista;

            }
            catch (Exception)
            {

                throw;
            }
            

        }

    }
}