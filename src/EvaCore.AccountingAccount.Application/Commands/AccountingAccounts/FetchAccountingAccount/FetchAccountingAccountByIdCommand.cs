using EvaCore.AccountingAccount.Application.Dto.AccountingAccount;
using MediatR;

namespace EvaCore.AccountingAccount.Application.Commands.AccountingAccounts.FetchAccountingAccount;

public class FetchAccountingAccountByIdCommand:IRequest<AccountingAccountResponse?>
{
    public int Id { get; set; }
}
