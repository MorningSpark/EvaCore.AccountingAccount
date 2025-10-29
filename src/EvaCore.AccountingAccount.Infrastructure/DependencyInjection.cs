using EvaCore.AccountingAccount.Infrastructure.Data;
using EvaCore.AccountingAccount.Infrastructure.Services;
using EvaCore.AccountingAccount.Infrastructure.Utilitario;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EvaCore.AccountingAccount.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AccountingAccountDbContext>(options => options.UseSqlServer(connectionString));
        return services;
    }

    public static IServiceCollection AddUtils(this IServiceCollection services)
    {
        services.AddScoped<IExpresionEvaluator, ExpresionEvaluator>();
        services.AddScoped<IAccountingAccountService, AccountingAccountService>();
        return services;
    }
}
