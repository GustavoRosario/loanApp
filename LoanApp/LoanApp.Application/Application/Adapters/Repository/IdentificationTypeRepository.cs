using LoanApp.Domain.Dto;
using LoanApp.Domain.Ports.Repository;
using LoanApp.Infrastructure.Entity.Data;

namespace LoanApp.Application.Application.Adapters.Repository
{
    public class IdentificationTypeRepository : IIdentificationTypeRepository
    {
        private LoanAppDbContext LoanDbContext { get; set; }
        public IdentificationTypeRepository(LoanAppDbContext loanDbContext)
        {
            this.LoanDbContext = loanDbContext;
        }
        public async Task<List<IdentificationTypeDto>> GetData()
        {
            var lstProvince = LoanDbContext.lo_identification_type.Where(x => x.active == true).ToList();

            var lst = lstProvince.ConvertAll(x =>
            {
                return new IdentificationTypeDto()
                {
                    IdentificationTypeId = x.identification_type_id,
                    IdentificationType = x.identification_type
                };
            });

            return await Task.Run(() => lst);
        }
    }
}
