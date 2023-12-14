using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Furniture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FurnitureCategory category { get; set; }
        public Documentary documentary { get; set; }
        public int documentary_id { get; set; }
        public Office office { get; set; }
        public int office_id { get; set; }

    }

    public enum FurnitureCategory
    {
        Plumbling, SoftFurniture, Table, Cabinet
    }
}
