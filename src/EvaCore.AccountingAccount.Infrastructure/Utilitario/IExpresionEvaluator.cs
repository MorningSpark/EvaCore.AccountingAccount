using System;

namespace EvaCore.AccountingAccount.Infrastructure.Utilitario;

public interface IExpresionEvaluator
{
    Task<decimal> Evaluate(string expression, decimal value);
}
