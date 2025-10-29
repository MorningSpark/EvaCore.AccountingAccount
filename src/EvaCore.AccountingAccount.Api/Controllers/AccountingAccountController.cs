using EvaCore.AccountingAccount.Application.Commands.AccountingAccounts.CreateAccountingAccount;
using EvaCore.AccountingAccount.Application.Commands.AccountingAccounts.FetchAccountingAccount;
using EvaCore.AccountingAccount.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EvaCore.AccountingAccount.Infrastructure.Utilitario;

namespace EvaCore.AccountingAccount.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountingAccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        protected DtoResponse _response;

        public AccountingAccountController(IMediator mediator)
        {
            _mediator = mediator;
            _response = new DtoResponse();
        }

        /// <summary>
        /// Create a new accounting account
        /// </summary>
        /// <param name="command">The command containing the details of the accounting account to create</param>
        /// <returns>The ID of the created accounting account</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAccountingAccountCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<AccountingAccountModel>>> ObtenerCuentasFiltradas(
        [FromQuery] int? id,
        [FromQuery] int? parentId,
        [FromQuery] string? referenceCode,
        [FromQuery] string? reference,
        [FromQuery] string? name,
        [FromQuery] int? breed,
        [FromQuery] bool? transaction,
        [FromQuery] int? level,
        [FromQuery] DateTime? creationDate)
        {
            FetchAccountingAccountCommand query = new FetchAccountingAccountCommand
            {
                Id = id ?? 0,
                ParentId = parentId ?? 0,
                ReferenceCode = referenceCode,
                Reference = reference,
                Name = name,
                Transaction = transaction,
                Breed = breed ?? 0,
                Level = level ?? 0,
            };
            _response = await UtilitaryResponse.CreateDtoResponse(async () =>
            {
                return await _mediator.Send(query);

            }); 
            return Ok(_response);
        }
    }
}
