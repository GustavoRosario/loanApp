using LoanApp.Domain.Dto;

namespace LoanApp.Application.Application.Query
{
    public interface IQuery
    {
        public Task<List<ProvinceDto>> Execute();
    }
}
