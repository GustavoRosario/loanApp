using LoanApp.Domain.Dto;

namespace LoanApp.Application.Application.Command
{
    public interface ICommandCaller
    {
        public Task<ResponseDto> ExecuteProcess(ApplicationDto applicationDto);
    }
}
