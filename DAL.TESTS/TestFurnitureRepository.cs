using DAL.Entities;
using DAL.Repository.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.TESTS
{
    public class TestFurnitureRepository : BaseRepository<Furniture>
    {
        public TestFurnitureRepository(DbContext context) : base(context)
        {
        }
    }
}
