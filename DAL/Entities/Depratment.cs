using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Depratment : Facility
    {
        public string DepartmentName { get; set; }

        public List<Office> offices { get; set; }
    }
}
