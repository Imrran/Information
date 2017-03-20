using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cats.Models;
using System.Net;
using Cats.BusinessLayer;

namespace Cats.Controllers
{
    public class PeopleController : Controller
    {
        public ActionResult GetCatsInfo()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCatsDetails()
        {
            CatsLogic catsLogic = new CatsLogic();
            List<PeopleModel> peopleList = new List<PeopleModel>();
            List<CatsInfoVM> catsInfoVMList = new List<CatsInfoVM>();
            peopleList = catsLogic.GetCatsInfo();

            List<PeopleModel> owner_Gender = peopleList.Where(p => p.gender == "Male").ToList();
            for (int i = 0; i < owner_Gender.Count; i++)
            {

                var pet_Cat = owner_Gender[i].pets.Where(p => p.type == "Cat" && p.peoplesName == owner_Gender[i].name).OrderBy(x => x.name).ToList();
                for (int j = 0; j < pet_Cat.Count; j++)
                {
                    CatsInfoVM catsInfoVM = new CatsInfoVM();
                    catsInfoVM.Name = owner_Gender[i].name;
                    catsInfoVM.Gender = owner_Gender[i].gender;
                    catsInfoVM.PetName = pet_Cat[j].name;
                    catsInfoVM.PetType = pet_Cat[j].type;
                    catsInfoVMList.Add(catsInfoVM);
                }
            }
            return Json(catsInfoVMList, JsonRequestBehavior.AllowGet);
        }
    }
}