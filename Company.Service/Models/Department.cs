using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Company.Service.Models
{
    
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        public string DeptName { get; set; }
       [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}