using LoanApp.Domain.Dto;
using LoanApp.Domain.Ports.Repository;
using LoanApp.Infrastructure.Entity;
using LoanApp.Infrastructure.Entity.Data;
using LoanApp.Application.Helpers;
using Microsoft.EntityFrameworkCore;
using LoanApp.Domain.Entities;

namespace LoanApp.Application.Application.Adapters.Repository
{
    public class IdentificationTypeRepository : IIdentificationTypeRepository
    {
        private LoanAppDbContext LoanDbContext { get; set; }
        public IdentificationTypeRepository(LoanAppDbContext LoanDbContext)
        {
            this.LoanDbContext = LoanDbContext;
        }
        public async Task<List<IdentificationTypeDto>> GetData()
        {
            List<IdentificationTypeDto> lst = null;
            var lstProvince = LoanDbContext.lo_identification_type.Where(x => x.identification_type_id > 0 && x.active == true).ToList();

            lst = lstProvince.ConvertAll(x =>
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
