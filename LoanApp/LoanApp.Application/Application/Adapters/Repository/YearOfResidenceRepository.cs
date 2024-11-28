using LoanApp.Application.Helpers;
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
            List<YearOfResidenceDto> lst = null;
            var lstYearOfResidende = LoanDbContext.lo_year_of_residence.Where(x => x.year_of_residence_id > 0 && x.active == true).ToList();

            lst = lstYearOfResidende.ConvertAll(x =>
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
            YearOfResidenceDto _yearOfResidenceDto = null;
            var yearOfResidence = LoanDbContext.lo_year_of_residence.Where(x => x.year_of_residence_id == yeraOdResidenceId && x.active == true).First();

            _yearOfResidenceDto = new YearOfResidenceDto()
            {
                YearOfResidenceId = yearOfResidence.year_of_residence_id,
                YearOfResidence = yearOfResidence.year_of_residence
            };

            return Task.Run(() => _yearOfResidenceDto);
        }
    }
}
