using LoanApp.Domain.Dto;

namespace LoanApp.Domain.Ports.Repository
{
    public interface IProvinceRepository
    {
        public Task<List<ProvinceDto>> GetData();
        public Task<ProvinceDto> GetData(int provinceId);
    }
}
