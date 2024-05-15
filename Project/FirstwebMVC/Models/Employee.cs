using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstwebMVC.Models
{
    public class Employee : Person
    {
        public string EmployeeID { get; set; }
        public int Age { get; set; }
    }
}