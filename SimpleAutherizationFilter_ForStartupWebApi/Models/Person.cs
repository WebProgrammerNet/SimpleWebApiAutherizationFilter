using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleAutherizationFilter_ForStartupWebApi.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
    }
}