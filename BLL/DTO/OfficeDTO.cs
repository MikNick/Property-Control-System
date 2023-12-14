using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class OfficeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int employeeAmount { get; set; }

        public int maxEmployeeAmount { get; set; }
        public int department_id { get; set; }
    }
}
