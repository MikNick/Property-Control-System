using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class StuffReportDTO
    {
        public int Id { get; set; }
        public string fullName { get; set; }
        public bool isOfficeAppropriate { get; set; }
        public int furnitureAmount { get; set; }
        public double furnitureCost { get; set; }
        public int employeeAmount { get; set; }
    }
}
