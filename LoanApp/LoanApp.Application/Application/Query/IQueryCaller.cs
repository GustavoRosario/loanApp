using LoanApp.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanApp.Application.Application.Query
{
    public interface IQueryCaller
    {
        public Task ExecuteProcess();
    }
}
