using MediatR;

namespace EvaCore.AccountingAccount.Application.Commands.AccountingAccounts.CreateAccountingAccount;

public class CreateAccountingAccountCommand:IRequest<int>
{
    /// <summary>
    /// parent Id
    /// </summary>
    public int ParentId { get; set; }

    /// <summary>
    /// User Id
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Reference code
    /// </summary>
    public string? ReferenceCode { get; set; }

    /// <summary>
    /// Reference
    /// </summary>
    public string? Reference { get; set; }    

    /// <summary>
    /// Transaction
    /// </summary>
    public bool? Transaction { get; set; }  

    /// <summary>
    /// Config
    /// </summary>
    public int? Configuration { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Resource
    /// </summary>
    public string? Resource { get; set; }

    /// <summary>
    /// Reference Value
    /// </summary>
    public decimal? ReferenceValue { get; set; }
}

