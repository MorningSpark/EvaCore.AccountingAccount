using System;
using EvaCore.AccountingAccount.Domain.Entities;

namespace EvaCore.AccountingAccount.Infrastructure.Services;

public interface IAccountingAccountService
{
    Task<AccountingAccountModel> CreateAccountingAccountAsync(AccountingAccountModel accountingAccount, CancellationToken cancellationToken = default);
    Task<AccountingAccountModel> GetAccountingAccountByIdAsync(int id, string reference, CancellationToken cancellationToken = default);
    Task<IEnumerable<AccountingAccountModel>> GetCustomAccountingAccountByIdAsync(AccountingAccountModel accountingAccount, int level, CancellationToken cancellationToken = default);
    Task<IEnumerable<AccountingAccountModel>> GetAllAccountingAccountsAsync(CancellationToken cancellationToken = default);
}
