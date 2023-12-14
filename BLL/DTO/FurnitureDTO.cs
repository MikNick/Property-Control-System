using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class FurnitureDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FurnitureCategory category { get; set; }
        public int documentary_id { get; set; }
        public int office_id { get; set; }
    }
}
