using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public abstract class Facility
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int employeeAmount { get; set; }

        public int maxEmployeeAmount { get; set; }
    }
}
