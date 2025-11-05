using EvaCore.AccountingAccount.Application.Commands.AccountingAccounts.CreateAccountingAccount;
using EvaCore.AccountingAccount.Application.Commands.AccountingAccounts.FetchAccountingAccount;
using EvaCore.AccountingAccount.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EvaCore.AccountingAccount.Infrastructure.Utilitario;
using EvaCore.AccountingAccount.Application.Dto.AccountingAccount;
using EvaCore.AccountingAccount.Application.Commands.AccountingAccounts.UpdateAccountingAccount;
using EvaCore.AccountingAccount.Application.Commands.AccountingAccounts.DeleteAccountingAccount;

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
            _response = await UtilitaryResponse.CreateDtoResponse(async () =>
            {
                return await _mediator.Send(command);

            });
            return Ok(_response);
        }

        [HttpGet]
        public async Task<IActionResult> FetchAccountingAccount([FromBody] FetchAccountingAccountByIdCommand command)
        {
            _response = await UtilitaryResponse.CreateDtoResponse(async () =>
            {
                return await _mediator.Send(command);
            });
            return Ok(_response);
        }
    
        /// <summary>
        /// Fetch accounting accounts based on provided filters
        /// </summary>
        /// <param name="id">The ID of the accounting account</param>
        /// <param name="parentId">The parent ID of the accounting account</param>
        /// <param name="referenceCode">The reference code of the accounting account</param>
        /// <param name="reference">The reference of the accounting account</param>
        /// <param name="name">The name of the accounting account</param>
        /// <param name="breed">The breed of the accounting account</param>
        /// <param name="transaction">Indicates if the accounting account is a transaction account</param>
        /// <param name="level">The level of the accounting account</param>
        /// <returns>A list of matching accounting accounts</returns>
        [HttpGet("filter-query")]
        public async Task<ActionResult<List<AccountingAccountResponse>>> FetchAccountingAccounts(
        [FromQuery] int? id,
        [FromQuery] int? parentId,
        [FromQuery] string? referenceCode,
        [FromQuery] string? reference,
        [FromQuery] string? name,
        [FromQuery] int? breed,
        [FromQuery] bool? transaction,
        [FromQuery] int? level)
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

        /// <summary>
        /// Update an existing accounting account
        /// </summary>
        /// <param name="command">The command containing the details of the accounting account to update</param>
        /// <returns>The ID of the updated accounting account</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAccountingAccount([FromBody] UpdateAccountingAccountCommand command)
        {
            _response = await UtilitaryResponse.CreateDtoResponse(async () =>
            {
                return await _mediator.Send(command);

            });
            return Ok(_response);
        }

        /// <summary>
        /// Delete an accounting account by Id
        /// </summary>
        /// <param name="command">The command containing the details of the accounting account to delete</param>
        /// <returns>The ID of the deleted accounting account</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteAccountingAccount([FromBody] DeleteAccountingAccountCommand command)
        {
            _response = await UtilitaryResponse.CreateDtoResponse(async () =>
            {
                return await _mediator.Send(command);
            });
            return Ok(_response);
        }
    }
}
