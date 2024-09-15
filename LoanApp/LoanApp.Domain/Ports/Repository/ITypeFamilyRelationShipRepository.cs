using LoanApp.Domain.Dto;

namespace LoanApp.Domain.Ports.Repository
{
    public interface ITypeFamilyRelationShipRepository
    {
        public Task<List<TypeFamilyRelationShipDto>> GetData();
        public Task<TypeFamilyRelationShipDto> GetData(int typeFamilyId);
    }
}
