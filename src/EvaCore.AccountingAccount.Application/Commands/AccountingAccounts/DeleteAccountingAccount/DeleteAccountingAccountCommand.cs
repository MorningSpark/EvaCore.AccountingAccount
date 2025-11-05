using MediatR;

namespace EvaCore.AccountingAccount.Application.Commands.AccountingAccounts.DeleteAccountingAccount;

/// <summary>
/// Command to delete an Accounting Account by Id
/// </summary>
public class DeleteAccountingAccountCommand : IRequest<bool>
{
    /// <summary>
    /// Id of the Accounting Account to delete
    /// </summary>
    public int Id { get; set; }
}
