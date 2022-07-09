using AutoMapper;
using NotesApp.Application.Contracts.DTOs.Abstract;
using NotesApp.Application.Contracts.DTOs.Concrete;
using NotesApp.Application.Contracts.Services;
using NotesApp.Domain.Aggregates.AccountAggregate.Concrete;
using NotesApp.Domain.Aggregates.AccountAggregate.ValueObjects;
using NotesApp.Domain.Repositories;
using NotesApp.Domain.Specifications.AccountSpecifications;
using SeedWork.Application.Utils.Hashing;
using SeedWork.Application.Utils.JWT.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Services
{
    public class AuthenticationAppService : IAuthenticationAppService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;

        public AuthenticationAppService(IAccountRepository accountRepository, ITokenHelper tokenHelper, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
        }

        public async Task<AuthDTO> LoginAsync(LoginDTO loginDTO)
        {
            var account = await _accountRepository.GetOneAsync(new AccountGetByEmailSpecification(loginDTO.Email));
            if (account is null) throw new AuthenticationException("Account not found.");

            var status = HashingHelper.VerifyPassword(loginDTO.Password, account.PasswordHash, account.PasswordSalt);
            if (!status) throw new AuthenticationException("Password is not correct.");

            // create JWT Token
            var token = _tokenHelper.CreateToken(account);
            var accountDTO = _mapper.Map<AccountDTO>(account);

            return new AuthDTO
            {
                Account = accountDTO,
                AccessToken = token,
            };
        }

        public async Task<AuthDTO> RegisterStandartUserAsync(StandartUserRegisterDTO standartUserRegisterDTO)
        {
            // Normally, this operation should be done in the domain service, but because there is a time constraint for the project, it was done here.
            var account = await _accountRepository.GetOneAsync(new AccountGetByEmailSpecification(standartUserRegisterDTO.Email));
            if (account is not null) throw new AuthenticationException("Email is used another user");
            // check password constraints in here, because depends on application, not domain!!!
            // probably in another class
            if (string.IsNullOrEmpty(standartUserRegisterDTO.Password)) throw new ArgumentNullException("Password cannot be empty!");
            HashingHelper.CreatePasswordHashAndSalt(standartUserRegisterDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var standartUser = new StandartUser(standartUserRegisterDTO.Name, standartUserRegisterDTO.Lastname, new Email(standartUserRegisterDTO.Email), passwordHash, passwordSalt);
            await _accountRepository.CreateAsync(standartUser);

            // create JWT Token
            var token = _tokenHelper.CreateToken(standartUser);
            var accountDTO = _mapper.Map<AccountDTO>(standartUser);

            return new AuthDTO
            {
                Account = accountDTO,
                AccessToken = token,
            };
        }
    }
}
