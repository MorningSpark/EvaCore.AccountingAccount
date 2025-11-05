using System;
using EvaCore.AccountingAccount.Domain.Entities;

namespace EvaCore.AccountingAccount.Infrastructure.Services;

public interface IAccountingAccountService
{
    Task<AccountingAccountModel> CreateAccountingAccountAsync(AccountingAccountModel accountingAccount, CancellationToken cancellationToken = default);
    Task<bool> UpdateAccountingAccountAsync(AccountingAccountModel accountingAccount, CancellationToken cancellationToken = default);
    Task<bool> DeleteAccountingAccountAsync(int id, CancellationToken cancellationToken = default);     
    Task<IEnumerable<AccountingAccountModel>> GetCustomAccountingAccountAsync(AccountingAccountModel accountingAccount, int level, CancellationToken cancellationToken = default);
}
