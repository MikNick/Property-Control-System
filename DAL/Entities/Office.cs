using DAL.Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Office : Facility
    {
        public int department_id { get; set; }
        public Department department { get; set; }
    }
}
