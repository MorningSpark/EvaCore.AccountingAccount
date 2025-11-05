using System;
using EvaCore.AccountingAccount.Infrastructure.Services;
using MediatR;

namespace EvaCore.AccountingAccount.Application.Commands.AccountingAccounts.DeleteAccountingAccount;

public class DeleteAccountingAccountHandler:IRequestHandler<DeleteAccountingAccountCommand, bool>
{
    /// <summary>
    /// Accounting Account Service
    /// </summary>
    private readonly IAccountingAccountService _accountingAccountService;

    /// <summary>
    /// Constructor for DeleteAccountingAccountHandler
    /// </summary>
    /// <param name="accountingAccountService"></param>
    public DeleteAccountingAccountHandler(IAccountingAccountService accountingAccountService)
    {
        _accountingAccountService = accountingAccountService;
    }

    /// <summary>
    /// Delete Accounting Account by Id
    /// </summary>
    /// <param name="request">Request containing the Id of the Accounting Account to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the Accounting Account was deleted successfully, otherwise false</returns>
    public async Task<bool> Handle(DeleteAccountingAccountCommand request, CancellationToken cancellationToken)
    {
        return await _accountingAccountService.DeleteAccountingAccountAsync(request.Id, cancellationToken);
    }

}
