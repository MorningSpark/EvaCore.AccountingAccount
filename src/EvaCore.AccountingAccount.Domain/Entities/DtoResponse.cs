using System;

namespace EvaCore.AccountingAccount.Domain.Entities;

public class DtoResponse
{
    public string? Message { get; set; }
    public IList<string>? Errors { get; set; }
    public Object? Data { get; set; }
    public int? ErrorCode { get; set; }

    public bool Success { get; set; }

}
