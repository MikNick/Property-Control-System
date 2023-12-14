using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class OfficeService : IOfficeService
    {
        private IUnitOfWork _database;

        public OfficeService(IUnitOfWork database)
        {
            if(database == null)
            {
                throw new ArgumentNullException(nameof(database));
            }
            _database = database;
        }

        public IEnumerable<OfficeDTO> GetOffices()
        {
            var user = SecurityContext.GetUser();

            if (user.GetType() != typeof(AssistManager) && user.GetType() != typeof(Manager))
            {
                throw new MethodAccessException();
            }

            var offices = _database.OfficeRepository.GetAll();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Office, OfficeDTO>()).CreateMapper();
            var officesDTO = mapper.Map<IEnumerable<Office>, List<OfficeDTO>>(offices);

            return officesDTO;
        }

        public IEnumerable<FurnitureDTO> GetOfficeFurniture(int officeId)
        {
            var user = SecurityContext.GetUser();

            if (user.GetType() != typeof(Manager))
            {
                throw new MethodAccessException();
            }

            var furnitures = _database.FurnitureRepository
                .Find(f => f.office_id == officeId);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Furniture, FurnitureDTO>()).CreateMapper();
            var furnituresDTO = mapper.Map<IEnumerable<Furniture>, List<FurnitureDTO>>(furnitures);

            return furnituresDTO;
        }
    }
}
