using LoanApp.Application.Application.Command;
using LoanApp.Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LoanApp.Controllers
{
    public class LoanApplicationController : Controller
    {
        public ICommandCaller _commandCaller;

        public LoanApplicationController(ICommandCaller commandCaller)
        {
            _commandCaller = commandCaller;
        }

        public IActionResult Index()
        {
            ApplicationDto applicationDto = new ApplicationDto();

            _commandCaller.ExecuteProcess(applicationDto);
            
            return View();
        }
    }
}
