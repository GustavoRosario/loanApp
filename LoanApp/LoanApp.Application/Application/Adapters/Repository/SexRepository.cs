using LoanApp.Domain.Dto;
using LoanApp.Domain.Ports.Repository;
using LoanApp.Infrastructure.Entity.Data;
using LoanApp.Application.Helpers;
using Microsoft.EntityFrameworkCore;

namespace LoanApp.Application.Application.Adapters.Repository
{
    public class SexRepository : ISexRepository
    {
        private LoanAppDbContext LoanDbContext { get; set; }

        public SexRepository(LoanAppDbContext loanAppDbContext)
        {
            this.LoanDbContext = loanAppDbContext;
        }
        public async Task<List<SexDto>> GetData()
        {
            List<SexDto> lst = null;
            var lstSex = LoanDbContext.lo_sex.Where(x => x.sex_id > 0 && x.active == true).ToList();

            lst = lstSex.ConvertAll(x =>
            {
                return new SexDto()
                {
                    SexId = x.sex_id,
                    Sex = x.sex
                };
            });

            return await Task.Run(() => lst);
        }

        public Task<SexDto> GetData(int sexId)
        {
            SexDto sexDto = null;
            var sex = LoanDbContext.lo_sex.Where(x => x.sex_id == sexId && x.active == true).First();

            sexDto = new SexDto()
            {
                SexId = sex.sex_id,
                Sex = sex.sex
            };

            return Task.Run(() => sexDto);
        }
    }
}
