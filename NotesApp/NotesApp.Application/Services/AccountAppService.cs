using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using NotesApp.Application.Contracts.DTOs.Abstract;
using NotesApp.Application.Contracts.DTOs.Concrete;
using NotesApp.Application.Contracts.Services;
using NotesApp.Domain.Aggregates.AccountAggregate.Abstracts;
using NotesApp.Domain.Aggregates.AccountAggregate.Concrete;
using NotesApp.Domain.Repositories;
using NotesApp.Domain.Specifications.AccountSpecifications;
using SeedWork.Application.Authorization;
using SeedWork.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Services
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;

        public AccountAppService(IAccountRepository accountRepository, IAuthorizationService authorizationService, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _authorizationService = authorizationService;
            _mapper = mapper;
        }

        public async Task<AccountDTO> DeleteAsync(ClaimsPrincipal claimsPrincipal, Guid id)
        {
            var account = await _accountRepository.GetOneAsync(new AccountGetByIdSpecification(id));
            if (account is null) throw new ItemNotFoundException("Account not found");
            // check user has permission
            var authorizationStatus = await _authorizationService.AuthorizeAsync(claimsPrincipal, account, Operations.Delete);
            if (!authorizationStatus.Succeeded) throw new UnauthorizedException("Permission Denied");
            // Do operation(soft delete)
            account.SoftDelete();
            await _accountRepository.UpdateAsync(account);
            return ToResponseObject(account);
        }

        public async Task<List<AccountDTO>> GetAllAsync(ClaimsPrincipal claimsPrincipal, int limit, int offset)
        {
            var accounts = await _accountRepository.GetAsync(new AccountGetAllSpecification(),limit,offset);
            if (accounts.Count == 0) return new List<AccountDTO>();
            // check permission
            foreach(var account in accounts)
            {
                var authorizationStatus = await _authorizationService.AuthorizeAsync(claimsPrincipal, accounts, Operations.Read);
                if (!authorizationStatus.Succeeded) throw new UnauthorizedException("Permission Denied");
            }
            return ToResponseObject(accounts);
        }

        public async Task<AccountDTO> GetByIdAsync(ClaimsPrincipal claimsPrincipal, Guid id)
        {
            var account = await _accountRepository.GetOneAsync(new AccountGetByIdSpecification(id));
            if (account is null) throw new ItemNotFoundException("Account not found");
            // check permission
            var authorizationStatus = await _authorizationService.AuthorizeAsync(claimsPrincipal, account, Operations.Read);
            if (!authorizationStatus.Succeeded) throw new UnauthorizedException("Permission Denied");
            return ToResponseObject(account);
        }

        public async Task<AccountDTO> PartialUpdateAsync(ClaimsPrincipal claimsPrincipal, Guid id, StandartUserUpdateDTO standartUserUpdateDTO)
        {
            var account = await _accountRepository.GetOneAsync(new AccountGetByIdSpecification(id));
            if (account is null) throw new ItemNotFoundException("Account not found");
            if (account is not StandartUser standartUser ) throw new WrongAttemptException("Account is not StandartUser");
            // check permission
            var authorizationStatus = await _authorizationService.AuthorizeAsync(claimsPrincipal, account, Operations.Update);
            if (!authorizationStatus.Succeeded) throw new UnauthorizedException("Permission Denied");

            if (standartUserUpdateDTO.Name is not null) standartUser.SetName(standartUserUpdateDTO.Name);
            if(standartUserUpdateDTO.Lastname is not null) standartUser.SetLastname(standartUserUpdateDTO.Lastname);
            
            await _accountRepository.UpdateAsync(standartUser);
            return ToResponseObject(standartUser);
        }

        public async Task<AccountDTO> UpdateAsync(ClaimsPrincipal claimsPrincipal, Guid id, StandartUserUpdateDTO standartUserUpdateDTO)
        {
            var account = await _accountRepository.GetOneAsync(new AccountGetByIdSpecification(id));
            if (account is null) throw new ItemNotFoundException("Account not found");
            if (account is not StandartUser standartUser) throw new WrongAttemptException("Account is not StandartUser");
            // check permission
            var authorizationStatus = await _authorizationService.AuthorizeAsync(claimsPrincipal, account, Operations.Update);
            if (!authorizationStatus.Succeeded) throw new UnauthorizedException("Permission Denied");

            standartUser.SetName(standartUserUpdateDTO.Name);
            standartUser.SetLastname(standartUserUpdateDTO.Lastname);

            await _accountRepository.UpdateAsync(standartUser);
            return ToResponseObject(standartUser);
        }

        private AccountDTO ToResponseObject(Account account)
        {
            return _mapper.Map<AccountDTO>(account);
        }
        private List<AccountDTO> ToResponseObject(List<Account> accounts)
        {
            return _mapper.Map<List<AccountDTO>>(accounts);
        }
    }
}
