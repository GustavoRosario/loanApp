using LoanApp.Application.Application.Query;
using LoanApp.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanApp.Application.Application.Query
{
    public class QueryCaller 
    {
        private IQuery _getProvinceQuery;
        public Task ExecuteProcess()
        {
            _getProvinceQuery = new GetProvinceQuery();

            return _getProvinceQuery.Execute();
        }
    }
}
