using EvaCore.AccountingAccount.Domain.Entities;
using EvaCore.AccountingAccount.Infrastructure.Services;
using MediatR;

namespace EvaCore.AccountingAccount.Application.Commands.AccountingAccounts.FetchAccountingAccount;

public class FetchAccountingAccountHandler : IRequestHandler<FetchAccountingAccountCommand, List<AccountingAccountModel>>
{
    private readonly IAccountingAccountService _accountingAccountService;
    public FetchAccountingAccountHandler(IAccountingAccountService accountingAccountService)
    {
        _accountingAccountService = accountingAccountService;
    }
    
    public async Task<List<AccountingAccountModel>> Handle(FetchAccountingAccountCommand request, CancellationToken cancellationToken)
    {
        AccountingAccountModel account = new AccountingAccountModel
        {
            ParentId = request.ParentId,
            ReferenceCode = request.ReferenceCode,
            UserId = request.UserId,
            Reference = request.Reference,
            Transaction= request.Transaction,
            Name = request.Name,
            CreationDate = DateTime.UtcNow
        };

        return (await _accountingAccountService.GetCustomAccountingAccountByIdAsync(account, request.Level, cancellationToken)).ToList();
    }
}
