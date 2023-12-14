using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class DocumentaryDTO
    {
        public int Id { get; set; }

        public double aproximateCost { get; set; }

        public ItemState itemState { get; set; }
    }
}
