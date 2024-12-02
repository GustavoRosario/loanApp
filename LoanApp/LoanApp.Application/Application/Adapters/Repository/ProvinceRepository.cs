using LoanApp.Domain.Dto;
using LoanApp.Domain.Ports.Repository;
using LoanApp.Infrastructure.Entity.Data;

namespace LoanApp.Application.Application.Adapters.Repository
{
    public class ProvinceRepository : IProvinceRepository
    {
        private LoanAppDbContext LoanDbContext { get; set; }

        public ProvinceRepository(LoanAppDbContext loanAppDbContext)
        {
            this.LoanDbContext = loanAppDbContext;
        }
        public async Task<List<ProvinceDto>> GetData()
        {
            var lstProvince = LoanDbContext.lo_province.Where(x => x.active == true).ToList();

            var lst = lstProvince.ConvertAll(x =>
            {
                return new ProvinceDto()
                {
                    ProvinceId = x.province_id,
                    Province = x.province
                };
            });

            return await Task.Run(() => lst);
        }

        public Task<ProvinceDto> GetData(int provinceId)
        {
            var province = LoanDbContext.lo_province.Where(x => x.province_id == provinceId && x.active == true).First();

            var provinceDto = new ProvinceDto()
            {
                ProvinceId = province.province_id,
                Province = province.province
            };

            return Task.Run(() => provinceDto);
        }
    }
}
