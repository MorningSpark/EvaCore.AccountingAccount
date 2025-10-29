using System;
using EvaCore.AccountingAccount.Domain.Entities;

namespace EvaCore.AccountingAccount.Infrastructure.Utilitario;

public static class UtilitaryResponse
{
    public static async Task<DtoResponse> CreateDtoResponse<TResult>(Func<Task<TResult>> func)
    {
        DtoResponse response = new DtoResponse();
        try
        {
            TResult result = await func();
            response.Data = result;
            response.Errors = new List<string>();
            response.Message = "Operation completed successfully.";
        }
        catch (Exception ex)
        {
            response.Message = "An error occurred during the operation.";
            response.Errors = new List<string> { ex.Message };
            response.ErrorCode = -1;
        }
        return response;
    }

}
