using LoanApp.Domain.Dto;

namespace LoanApp.Application.Application.Command
{
    public class CommandCaller : ICommandCaller
    {
        private ICommand createApplicationCommand;
        public Task<ResponseDto> ExecuteProcess(ApplicationDto applicationDto)
        {
            createApplicationCommand = new CreateApplicationCommand(applicationDto);

            return createApplicationCommand.Execute();
        }
    }
}
