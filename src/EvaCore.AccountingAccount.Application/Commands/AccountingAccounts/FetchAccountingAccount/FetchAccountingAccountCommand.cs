using MediatR;
using EvaCore.AccountingAccount.Domain.Entities;

namespace EvaCore.AccountingAccount.Application.Commands.AccountingAccounts.FetchAccountingAccount;

public class FetchAccountingAccountCommand:IRequest<List<AccountingAccountModel>>
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public int UserId { get; set; }
    public string? ReferenceCode { get; set; }
    public string? Reference { get; set; }
    public string? Name { get; set; }
    public int Breed { get; set; }
    public bool? Transaction { get; set; }
    public int Level { get; set; }
}
