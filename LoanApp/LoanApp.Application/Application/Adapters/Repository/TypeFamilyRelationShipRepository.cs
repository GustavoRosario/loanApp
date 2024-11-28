using LoanApp.Domain.Dto;
using LoanApp.Domain.Ports.Repository;
using LoanApp.Infrastructure.Entity;
using LoanApp.Infrastructure.Entity.Data;
using LoanApp.Application.Helpers;
using Microsoft.EntityFrameworkCore;
using LoanApp.Domain.Entities;

namespace LoanApp.Application.Application.Adapters.Repository
{
    public class TypeFamilyRelationShipRepository : ITypeFamilyRelationShipRepository
    {
        private LoanAppDbContext LoanDbContext { get; set; }
        public TypeFamilyRelationShipRepository(LoanAppDbContext loanDbContext)
        {
            LoanDbContext = loanDbContext;
        }
        public async Task<List<TypeFamilyRelationShipDto>> GetData()
        {
            List<TypeFamilyRelationShipDto> lst = null;
            var lstProvince = LoanDbContext.lo_type_family_relationship.Where(x => x.type_family_relationship_id > 0 && x.active == true).ToList();

            lst = lstProvince.ConvertAll(x =>
            {
                return new TypeFamilyRelationShipDto()
                {
                    TypeFamilyRelationShipId = x.type_family_relationship_id,
                    TypeFamilyRelationShip = x.type_family_relationship
                };
            });

            return await Task.Run(() => lst);
        }

        public Task<TypeFamilyRelationShipDto> GetData(int typeFamilyRelationShipId)
        {
            TypeFamilyRelationShipDto typeFamilyRelationShipDto = null;
            var typeFamilyRelationShip = LoanDbContext.lo_type_family_relationship.Where(x => x.type_family_relationship_id == typeFamilyRelationShipId && x.active == true).First();

            typeFamilyRelationShipDto = new TypeFamilyRelationShipDto()
            {
                TypeFamilyRelationShipId = typeFamilyRelationShip.type_family_relationship_id,
                TypeFamilyRelationShip = typeFamilyRelationShip.type_family_relationship
            };

            return Task.Run(() => typeFamilyRelationShipDto);
        }
    }
}
