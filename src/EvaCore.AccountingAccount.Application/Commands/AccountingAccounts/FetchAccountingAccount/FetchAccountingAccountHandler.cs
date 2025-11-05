using EvaCore.AccountingAccount.Application.Dto.AccountingAccount;
using EvaCore.AccountingAccount.Domain.Entities;
using EvaCore.AccountingAccount.Infrastructure.Services;
using MediatR;

namespace EvaCore.AccountingAccount.Application.Commands.AccountingAccounts.FetchAccountingAccount;

public class FetchAccountingAccountHandler : IRequestHandler<FetchAccountingAccountCommand, List<AccountingAccountResponse>>
{
    private readonly IAccountingAccountService _accountingAccountService;
    public FetchAccountingAccountHandler(IAccountingAccountService accountingAccountService)
    {
        _accountingAccountService = accountingAccountService;
    }
    
    public async Task<List<AccountingAccountResponse>> Handle(FetchAccountingAccountCommand request, CancellationToken cancellationToken)
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

        return (await _accountingAccountService.GetCustomAccountingAccountAsync(account, request.Level, cancellationToken)).Select(a => new AccountingAccountResponse
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
        }).ToList();
    }
}
