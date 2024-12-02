using LoanApp.Domain.Dto;
using LoanApp.Domain.Ports.Repository;
using LoanApp.Infrastructure.Entity.Data;

namespace LoanApp.Application.Application.Adapters.Repository
{
    public class YearOfResidenceRepository : IYearOfResidenceRepository
    {
        private LoanAppDbContext LoanDbContext { get; set; }

        public YearOfResidenceRepository(LoanAppDbContext loanDbContext)
        {
            this.LoanDbContext = loanDbContext;
        }

        public async Task<List<YearOfResidenceDto>> GetData()
        {
            var lstYearOfResidende = LoanDbContext.lo_year_of_residence.Where(x => x.active == true).ToList();

            var lst = lstYearOfResidende.ConvertAll(x =>
            {
                return new YearOfResidenceDto()
                {
                    YearOfResidenceId = x.year_of_residence_id,
                    YearOfResidence = x.year_of_residence
                };
            });

            return await Task.Run(() => lst);
        }

        public Task<YearOfResidenceDto> GetData(int yeraOdResidenceId)
        {
            var yearOfResidence = LoanDbContext.lo_year_of_residence.Where(x => x.year_of_residence_id == yeraOdResidenceId && x.active == true).First();

            var _yearOfResidenceDto = new YearOfResidenceDto()
            {
                YearOfResidenceId = yearOfResidence.year_of_residence_id,
                YearOfResidence = yearOfResidence.year_of_residence
            };

            return Task.Run(() => _yearOfResidenceDto);
        }
    }
}
