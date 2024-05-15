using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstwebMVC.Models
{
    [Table("Employee")]
    public class Employee : Person
    {
        public string EmployeeID { get; set; }
        public int Age { get; set; }
    }
}