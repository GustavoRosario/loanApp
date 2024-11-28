using LoanApp.Domain.Dto;
using LoanApp.Domain.Ports.Repository;
using LoanApp.Infrastructure.Entity.Data;
using LoanApp.Application.Helpers;
using LoanApp.Domain.Entities;

namespace LoanApp.Application.Application.Adapters.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private LoanAppDbContext LoanDbContext { get; set; }

        public ApplicationRepository(LoanAppDbContext LoanDbContext)
        {
            this.LoanDbContext = LoanDbContext;
        }
        public Task<ResponseDto> Create(ApplicationDto applicationDto)
        {
            var responseDto = new ResponseDto();
            var loApplication = LoanDbContext.Set<lo_application>();
            const int SAVE = 1;
            const int NATIONALIDRD = 1;
            loApplication.Add(new lo_application
            {
                ref_id = Guid.NewGuid(),
                doctor_type_id = applicationDto.Doctortypeid,
                medical_center = applicationDto.Medicalcenter,
                passing_time = applicationDto.Passingtime,
                specialty = applicationDto.Specialty,
                year_of_residence_id = applicationDto.YearofresidenceId,
                //status_id = applicationDto.Statusid,
                status_id = SAVE,
                name = applicationDto.Name,
                last_name = applicationDto.Lastname,
                province_id = applicationDto.Provinceid,
                //identification_type_id = applicationDto.Identificationtypeid,
                person_province_id = applicationDto.Personprovinceid,
                identification_type_id = NATIONALIDRD,
                identification = applicationDto.Identification,
                identification_image = applicationDto.Identificationimage,
                sex_id = applicationDto.Sexid,
                address = applicationDto.Address,
                movil = applicationDto.Movil,
                direct_family_name = applicationDto.Directfamilyname,
                type_family_relationship_id = applicationDto.Typefamilyrelationshipid,
                direct_family_telephone = applicationDto.Directfamilytelephone,
                amount_to_lend = applicationDto.Amounttolend,
                record_date = DateTime.Now.Date,
                record_time = DateTime.Now,
                active = true

            });

            var saveRecord = LoanDbContext.SaveChanges();

            if (saveRecord > 0)
                responseDto.Success = true;

            return Task.Run(() => responseDto);
        }

        public Task<int> GetLastId()
        {
            var applicationId = LoanDbContext.lo_application.Max(q => q.application_id);

            return Task.Run(() => applicationId);
        }
    }
}
