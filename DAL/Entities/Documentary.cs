using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Documentary
    {
        public int Id { get; set; }

        public double aproximateCost { get; set; }

        public ItemState itemState { get; set; }
    }

    public enum ItemState
    {
        Normal, Bad, Broken
    }
}
