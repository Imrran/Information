using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cats.Models
{
    public class PeopleModel
    {
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public List<Pets> pets { get; set; }
    }
}