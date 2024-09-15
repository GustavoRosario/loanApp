using LoanApp.Domain.Dto;

namespace LoanApp.Application.Application.Command
{
    public interface ICommand
    {
        public Task<ResponseDto> Execute();
    }
}
