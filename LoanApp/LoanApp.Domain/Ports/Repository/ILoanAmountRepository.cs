﻿using LoanApp.Domain.Dto;

namespace LoanApp.Domain.Ports.Repository
{
    public interface ILoanAmountRepository
    {
        public Task<List<LoanAmountDto>> GetData();
    }
}
