using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _3_CRUD.Models
{
    public interface IDepartment
    {
        int Id { get; set; }
        string Location { get; set; }
    }

    public class Department:IDepartment
    {
        public int Id { get; set; }

       // [ReadOnly(true)]
       [Display(Name="DepartmentName")]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        
    }
    }
