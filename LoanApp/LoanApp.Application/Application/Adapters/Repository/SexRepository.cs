using LoanApp.Domain.Dto;
using LoanApp.Domain.Ports.Repository;
using LoanApp.Infrastructure.Entity.Data;

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
            var lstSex = LoanDbContext.lo_sex.Where(x => x.active == true).ToList();

            var lst = lstSex.ConvertAll(x =>
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
            var sex = LoanDbContext.lo_sex.Where(x => x.sex_id == sexId && x.active == true).First();

            var sexDto = new SexDto()
            {
                SexId = sex.sex_id,
                Sex = sex.sex
            };

            return Task.Run(() => sexDto);
        }
    }
}
