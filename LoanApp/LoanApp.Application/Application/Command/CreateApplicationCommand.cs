using LoanApp.Domain.Dto;
using LoanApp.Domain.Ports.Repository;
using LoanApp.Application.Application.Adapters.Repository;

namespace LoanApp.Application.Application.Command
{
    public class CreateApplicationCommand : ICommand
    {
        ApplicationDto _applicationDto;
        IApplicationRepository _applicationRepository;
        public CreateApplicationCommand(ApplicationDto applicationDto)
        {
            this._applicationDto = applicationDto;
            //this._applicationRepository = new ApplicationRepository();
        }

        public Task<ResponseDto> Execute()
        {
            var response = _applicationRepository.Create(_applicationDto);

            return Task.Run(() => response);
        }
    }
}
