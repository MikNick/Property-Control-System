using DAL.Entities;
using DAL.Repository.Implementations;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Impl
{
    public class FurnitureRepository : BaseRepository<Furniture>, IFurnitureRepository
    {
        public FurnitureRepository(DbContext context) : base(context)
        {
        }
    }
}
