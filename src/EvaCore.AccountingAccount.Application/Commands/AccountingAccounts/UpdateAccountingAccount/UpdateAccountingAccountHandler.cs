using System;
using EvaCore.AccountingAccount.Domain.Entities;
using EvaCore.AccountingAccount.Infrastructure.Services;
using MediatR;

namespace EvaCore.AccountingAccount.Application.Commands.AccountingAccounts.UpdateAccountingAccount;

public class UpdateAccountingAccountHandler:IRequestHandler<UpdateAccountingAccountCommand, bool>
{
    private readonly IAccountingAccountService _accountingAccountService;
    public UpdateAccountingAccountHandler(IAccountingAccountService accountingAccountService)
    {
        _accountingAccountService = accountingAccountService;
    }

    public async Task<bool> Handle(UpdateAccountingAccountCommand request, CancellationToken cancellationToken)
    {
        var accountingAccount = new AccountingAccountModel
        {
            Id = request.Id,
            ParentId = request.ParentId,
            UserId = request.UserId,
            ReferenceCode = request.ReferenceCode,
            Reference = request.Reference,
            Transaction = request.Transaction,
            Name = request.Name,
            Resource = request.Resource
        };

        return await _accountingAccountService.UpdateAccountingAccountAsync(accountingAccount, cancellationToken);
    }
}
