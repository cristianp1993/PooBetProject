using BetProject.Models;
using BetProject.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BetProject.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        PersonRepository person = new PersonRepository();
        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Recharge()
        {
            Models.persona personaViewModel = null;

            personaViewModel = new Models.persona
            {
                LsApostadores = person.GetBetPlayers(),               

            };
            return View(personaViewModel);
        }

        public string CreateUserNew(persona Model)
        {

            try
            {
                string save = person.SaveNewUser(Model);


                return save;
            }
            catch (Exception e)
            {

                throw;
            }      

            
        }

        public string RechargeUser(apostador Model)
        {
            try
            {

                return "";

            }
            catch (Exception e)
            {

                throw;
            }
        }

    }
}