using LoanApp.Application.Helpers;
using LoanApp.Domain.Dto;
using LoanApp.Domain.Ports.Repository;
using LoanApp.Infrastructure.Entity.Data;

namespace LoanApp.Application.Application.Adapters.Repository
{
    public class YearOfResidenceRepository : IYearOfResidenceRepository
    {
        LoanAppDbContext _db;
        private Context db = new Context();

        public YearOfResidenceRepository()
        {
            _db = db.Get();
        }

        public async Task<List<YearOfResidenceDto>> GetData()
        {
            List<YearOfResidenceDto> lst = null;
            var lstYearOfResidende = _db.lo_year_of_residence.Where(x => x.year_of_residence_id > 0 && x.active == true).ToList();

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
            var yearOfResidence = _db.lo_year_of_residence.Where(x => x.year_of_residence_id == yeraOdResidenceId && x.active == true).First();

            _yearOfResidenceDto = new YearOfResidenceDto()
            {
                YearOfResidenceId = yearOfResidence.year_of_residence_id,
                YearOfResidence = yearOfResidence.year_of_residence
            };

            return Task.Run(() => _yearOfResidenceDto);
        }
    }
}
