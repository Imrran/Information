using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cats.Models;
using System.Net;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace Cats.BusinessLayer
{
    public class CatsLogic
    {
        public List<PeopleModel> GetCatsInfo()
        {
            try
            {
                var url = "http://agl-developer-test.azurewebsites.net/people.json";
                string res;
                WebClient client = new WebClient();

                List<PeopleModel> peopleList = new List<PeopleModel>();
                List<Pets> petList = new List<Pets>();
                string value = client.DownloadString(url);
                res = value;
                dynamic dyn = JsonConvert.DeserializeObject(res);
                var jss = new JavaScriptSerializer();

                foreach (var obj in dyn)
                {
                    PeopleModel pl = new PeopleModel();
                    pl.name = obj.name;
                    pl.gender = obj.gender;
                    pl.age = obj.age;
                    if (obj.pets != null)
                    {
                        foreach (var objPets in obj.pets)
                        {
                            Pets pt = new Pets();
                            pt.name = objPets.name;
                            pt.type = objPets.type;
                            pt.peoplesName = obj.name;
                            petList.Add(pt);

                        }
                    }
                    pl.pets = petList;
                    peopleList.Add(pl);
                }
                return peopleList;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}