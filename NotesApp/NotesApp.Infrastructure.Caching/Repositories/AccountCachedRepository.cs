using Hangfire;
using NotesApp.Domain.Aggregates.AccountAggregate.Abstracts;
using NotesApp.Domain.Repositories;
using NotesApp.Domain.Specifications.AccountSpecifications;
using NotesApp.Infrastructure.Caching.Abstract;
using SeedWork.Domain.Specifications.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Infrastructure.Caching.Repositories
{
    public class AccountCachedRepository : IAccountRepository
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICacheService _cacheService;

        public AccountCachedRepository(IAccountRepository accountRepository, ICacheService cacheService)
        {
            _accountRepository = accountRepository;
            _cacheService = cacheService;
        }

        public async Task<bool> AnyAsync(ISpecification<Account> spec)
        {
           // not caching 
           return await _accountRepository.AnyAsync(spec);
        }

        public async Task<long> CountAsync(ISpecification<Account> spec)
        {
            // not caching 
            return await _accountRepository.CountAsync(spec);
        }

        public async Task CreateAsync(Account entity)
        {
            await _accountRepository.CreateAsync(entity);
            // caching for GetById specification
            var getByIdSpecification = new AccountGetByIdSpecification(entity.Id);
            _cacheService.Set(getByIdSpecification.GetCacheKey(), entity, getByIdSpecification.CacheDuration);
            // caching for GetByEmail Specification
            var getByEmailSpecification = new AccountGetByEmailSpecification(entity.Email.Value);
            _cacheService.Set(getByEmailSpecification.GetCacheKey(), entity, getByEmailSpecification.CacheDuration);
        }

        public async Task DeleteAsync(Account entity)
        {
            // Clean Cache for GetById
            var getByIdSpecification = new AccountGetByIdSpecification(entity.Id);
            BackgroundJob.Enqueue(() => _cacheService.Remove(getByIdSpecification.GetCacheKey()));
            // Clean Cache for GetByEmail
            var getByEmailSpecification = new AccountGetByEmailSpecification(entity.Email.Value);
            BackgroundJob.Enqueue(() => _cacheService.Remove(getByEmailSpecification.GetCacheKey()));
            await _accountRepository.DeleteAsync(entity);

        }

        public async Task<List<Account>> GetAsync(ISpecification<Account> spec, int limit, int offset)
        {
            // not caching operation
            return await _accountRepository.GetAsync(spec, limit, offset);
        }

        public async Task<Account?> GetOneAsync(ISpecification<Account> spec)
        {
            if(spec is ICachedSpecification<Account> cachedSpecification)
            {
                if (!_cacheService.TryGet(cachedSpecification.GetCacheKey(), out Account? entity))
                {
                    // miss
                    entity = await _accountRepository.GetOneAsync(spec);

                    if(entity is not null)
                        _cacheService.Set(cachedSpecification.GetCacheKey(), entity,cachedSpecification.CacheDuration);
                }
                // hit
                return entity;
            }
            else
            {
                return await _accountRepository.GetOneAsync(spec);
            }
        }

        public async Task UpdateAsync(Account entity)
        {
            // Clean Cache For GetById Specification
            var getByIdSpecification = new AccountGetByIdSpecification(entity.Id);
            BackgroundJob.Enqueue(() => _cacheService.Remove(getByIdSpecification.GetCacheKey()));
            // Clean Cache For GetByEmail Specification
            // Clean Cache for GetByEmail
            var getByEmailSpecification = new AccountGetByEmailSpecification(entity.Email.Value);
            BackgroundJob.Enqueue(() => _cacheService.Remove(getByEmailSpecification.GetCacheKey()));
            // Do operation
            await _accountRepository.UpdateAsync(entity);
            if (!entity.IsDeleted)
            {
                // caching for GetById specification
                getByIdSpecification = new AccountGetByIdSpecification(entity.Id);
                _cacheService.Set(getByIdSpecification.GetCacheKey(), entity, getByIdSpecification.CacheDuration);
                // caching for GetByEmail Specification
                getByEmailSpecification = new AccountGetByEmailSpecification(entity.Email.Value);
                _cacheService.Set(getByEmailSpecification.GetCacheKey(), entity, getByEmailSpecification.CacheDuration);
            }
        }
    }
}
