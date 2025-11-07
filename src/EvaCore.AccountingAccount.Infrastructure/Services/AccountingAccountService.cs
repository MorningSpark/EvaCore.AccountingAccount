using System;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using EvaCore.AccountingAccount.Domain.Entities;
using EvaCore.AccountingAccount.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EvaCore.AccountingAccount.Infrastructure.Services;

public class AccountingAccountService : IAccountingAccountService
{
    public const string LEVEL_1 = @"^[0-9]+$";
    public const string LEVEL_2 = @"^[0-9]+\.[0-9]+$";
    public const string LEVEL_3 = @"^[0-9]+\.[0-9]+\.[0-9]+$";
    private readonly AccountingAccountDbContext _context;
    public AccountingAccountService(AccountingAccountDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAccountingAccountAsync(AccountingAccountModel accountingAccount, CancellationToken cancellationToken = default)
    {
        _context.AccountingAccounts.Add(accountingAccount);
        await _context.SaveChangesAsync(cancellationToken);
        return accountingAccount.Id.GetValueOrDefault();
    }

    public async Task<IEnumerable<AccountingAccountModel>> GetCustomAccountingAccountAsync(AccountingAccountModel accountingAccount, int level, CancellationToken cancellationToken = default)
    {
        var query = _context.AccountingAccounts.AsQueryable();
        var accounts = await query.ToListAsync(cancellationToken);

        var filter = accounts.Select(c => new AccountingAccountModel
        {
            Id = c.Id,
            ParentId = c.ParentId ?? 0,
            UserId = c.UserId ?? 0,
            CreationDate = c.CreationDate,
            AlterDate = c.AlterDate,
            ReferenceCode = c.ReferenceCode,
            Reference = c.Reference,
            Transaction = c.Transaction,
            Configuration = c.Configuration,
            Name = c.Name,
            Resource = c.Resource
        }).ToList();

        if (level == 1)
            filter = filter.Where(c => Regex.IsMatch(c.ReferenceCode ?? string.Empty, LEVEL_1)).ToList();

        if (level == 2)
            filter = filter.Where(c => Regex.IsMatch(c.ReferenceCode ?? string.Empty, LEVEL_2)).ToList();

        if (level == 3)
            filter = filter.Where(c => Regex.IsMatch(c.ReferenceCode ?? string.Empty, LEVEL_3)).ToList();

        if (!accountingAccount.Id.GetValueOrDefault().Equals(0))
            filter = filter.Where(c => c.Id.Equals(accountingAccount.Id)).ToList();

        if (!accountingAccount.ParentId.GetValueOrDefault().Equals(0))
            filter = filter.Where(c => c.ParentId.Equals(accountingAccount.ParentId)).ToList();

        if (!string.IsNullOrEmpty(accountingAccount.ReferenceCode))
            filter = filter.Where(c => c.ReferenceCode == accountingAccount.ReferenceCode).ToList();

        if (!accountingAccount.UserId.GetValueOrDefault().Equals(0))
            filter = filter.Where(c => c.UserId == accountingAccount.UserId).ToList();

        if (!string.IsNullOrEmpty(accountingAccount.Reference))
            filter = filter.Where(c => c.Reference == accountingAccount.Reference).ToList();

        if (!string.IsNullOrEmpty(accountingAccount.Name))
            filter = filter.Where(c => c.Name == accountingAccount.Name).ToList();

        if (accountingAccount.Transaction.HasValue)
            filter = filter.Where(c => c.Transaction == accountingAccount.Transaction).ToList();

        if (accountingAccount.Configuration.HasValue)
            filter = filter.Where(c => (c.Configuration.GetValueOrDefault() & accountingAccount.Configuration.GetValueOrDefault()) != 0).ToList();

        return filter;
    }

    public async Task<bool> UpdateAccountingAccountAsync(AccountingAccountModel accountingAccount, CancellationToken cancellationToken = default)
    {
        AccountingAccountModel? existingAccount = await _context.AccountingAccounts
            .FirstOrDefaultAsync(x => x.Id == accountingAccount.Id, cancellationToken);

        if (existingAccount == null)
            return false;
        existingAccount.Name = accountingAccount.Name ?? existingAccount.Name;
        existingAccount.Reference = accountingAccount.Reference ?? existingAccount.Reference;
        existingAccount.ReferenceCode = accountingAccount.ReferenceCode ?? existingAccount.ReferenceCode;
        existingAccount.ParentId = accountingAccount.ParentId ?? existingAccount.ParentId;
        existingAccount.Transaction = accountingAccount.Transaction ?? existingAccount.Transaction;
        existingAccount.Configuration = accountingAccount.Configuration ?? existingAccount.Configuration;
        existingAccount.AlterDate = DateTime.UtcNow;
        _context.AccountingAccounts.Update(existingAccount);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteAccountingAccountAsync(int id, CancellationToken cancellationToken = default)
    {
        var accountingAccount = await _context.AccountingAccounts
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        if (accountingAccount == null)
        {
            return false;
        }

        _context.AccountingAccounts.Remove(accountingAccount);
        await _context.SaveChangesAsync(cancellationToken);
        return true;    
    }
}