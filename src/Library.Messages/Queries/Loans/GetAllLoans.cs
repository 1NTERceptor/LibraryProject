﻿using Library.Messages.Models;
using MediatR;

namespace Library.Messages.Queries.Loans
{
    public class GetAllLoans : IRequest<IEnumerable<LoanModel>>
    {
    }
}
