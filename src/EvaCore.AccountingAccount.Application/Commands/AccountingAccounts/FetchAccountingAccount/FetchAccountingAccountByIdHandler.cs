using System;
using EvaCore.AccountingAccount.Application.Dto.AccountingAccount;
using EvaCore.AccountingAccount.Domain.Entities;
using EvaCore.AccountingAccount.Infrastructure.Services;
using MediatR;

namespace EvaCore.AccountingAccount.Application.Commands.AccountingAccounts.FetchAccountingAccount;

public class FetchAccountingAccountByIdHandler:IRequestHandler<FetchAccountingAccountByIdCommand, AccountingAccountResponse?>
{
    readonly IAccountingAccountService _accountingAccountService;
    public FetchAccountingAccountByIdHandler(IAccountingAccountService accountingAccountService)
    {
        _accountingAccountService = accountingAccountService;
    }
    
    public async Task<AccountingAccountResponse?> Handle(FetchAccountingAccountByIdCommand request, CancellationToken cancellationToken)
    {
        AccountingAccountModel account = new AccountingAccountModel
        {
            Id = request.Id
        };

        var result = await _accountingAccountService.GetCustomAccountingAccountAsync(account, 0, cancellationToken);
        return result?.Select(a => new AccountingAccountResponse
        {
            Id = a.Id,
            ParentId = a.ParentId,
            UserId = a.UserId,
            ReferenceCode = a.ReferenceCode,
            Reference = a.Reference,
            Name = a.Name,
            Resource = a.Resource,
            Configuration = a.Configuration,
            Transaction = a.Transaction,
            ReferenceValue = a.ReferenceValue,
            CreationDate = a.CreationDate,
            AlterDate = a.AlterDate
        }).FirstOrDefault() ?? null;
    }
}
