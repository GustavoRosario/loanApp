using LoanApp.Domain.Dto;
using LoanApp.Domain.Ports.Repository;
using LoanApp.Infrastructure.Entity.Data;
using LoanApp.Application.Helpers;
using Microsoft.EntityFrameworkCore;

namespace LoanApp.Application.Application.Adapters.Repository
{
    public class ProvinceRepository : IProvinceRepository
    {
        LoanAppDbContext _db;
        private Context db = new Context();

        public ProvinceRepository()
        {
            _db = db.Get();
        }
        public async Task<List<ProvinceDto>> GetData()
        {
            List<ProvinceDto> lst = null;
            var lstProvince = _db.lo_province.Where(x => x.province_id > 0 && x.active == true).ToList();

            lst = lstProvince.ConvertAll(x =>
            {
                return new ProvinceDto()
                {
                    ProvinceId = x.province_id,
                    Province = x.province
                };
            });

            //return await Task.Run(() => { return lst; });
            return await Task.Run(() => lst);
        }

        public Task<ProvinceDto> GetData(int provinceId)
        {
            ProvinceDto provinceDto = null;
            var province = _db.lo_province.Where(x => x.province_id == provinceId && x.active == true).First();

            provinceDto = new ProvinceDto()
            {
                ProvinceId = province.province_id,
                Province = province.province
            };

            return Task.Run(() => provinceDto);
        }
    }
}
