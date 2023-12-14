using DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IFurnitureRepository FurnitureRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IOfficeRepository OfficeRepository { get; }
        void Save();
    }
}
