using LoanApp.Domain.Dto;
using LoanApp.Domain.Ports.Repository;
using LoanApp.Infrastructure.Entity.Data;

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
            var lstProvince = LoanDbContext.lo_type_family_relationship.Where(x => x.active == true).ToList();

            var lst = lstProvince.ConvertAll(x =>
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
            var typeFamilyRelationShip = LoanDbContext.lo_type_family_relationship.Where(x => x.type_family_relationship_id == typeFamilyRelationShipId && x.active == true).First();

            var typeFamilyRelationShipDto = new TypeFamilyRelationShipDto()
            {
                TypeFamilyRelationShipId = typeFamilyRelationShip.type_family_relationship_id,
                TypeFamilyRelationShip = typeFamilyRelationShip.type_family_relationship
            };

            return Task.Run(() => typeFamilyRelationShipDto);
        }
    }
}
