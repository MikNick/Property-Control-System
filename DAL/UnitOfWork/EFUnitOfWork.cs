using DAL.Repository.Impl;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private PCSContext context;
        private FurnitureRepository furnitureRepository;
        private OfficeRepository officeRepository;
        private DepartmentRepository depratmnetRepository;

        private bool _disposed = false;

        public EFUnitOfWork(DbContextOptions options)
        {
            context = new PCSContext(options);
        }


        public IFurnitureRepository FurnitureRepository
        {
            get
            {
                if (furnitureRepository == null)
                    furnitureRepository = new FurnitureRepository(context);
                return furnitureRepository;
            }
        }

        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                if (depratmnetRepository == null)
                    depratmnetRepository = new DepartmentRepository(context);
                return depratmnetRepository;
            }
        }
        public IOfficeRepository OfficeRepository
        {
            get
            {
                if (officeRepository == null)
                    officeRepository = new OfficeRepository(context);
                return officeRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
