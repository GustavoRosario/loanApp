using LoanApp.Domain.Dto;
using LoanApp.Domain.Ports.Repository;
using LoanApp.Application.Application.Adapters.Repository;

namespace LoanApp.Application.Application.Query
{
    public class GetProvinceQuery : IQuery
    {
        ProvinceDto _provinceDto;
        IProvinceRepository _provinceRepository;

        public GetProvinceQuery()
        {
            //_provinceRepository = new ProvinceRepository();
        }

        public Task<List<ProvinceDto>> Execute()
        {
            return _provinceRepository.GetData();
        }
    }
}
