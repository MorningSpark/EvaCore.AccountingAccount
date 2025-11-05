using System;
using MediatR;

namespace EvaCore.AccountingAccount.Application.Commands.AccountingAccounts.UpdateAccountingAccount;

public class UpdateAccountingAccountCommand:IRequest<bool>
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public int UserId { get; set; }
    public string? ReferenceCode { get; set; }
    public string? Reference { get; set; }    
    public bool? Transaction { get; set; }  
    public string? Name { get; set; }
    public string? Resource { get; set; }

}
