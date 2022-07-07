using Hangfire;
using NotesApp.Domain.Aggregates.NoteAggregate.Abstract;
using NotesApp.Domain.Repositories;
using NotesApp.Domain.Specifications.NoteSpecifications;
using NotesApp.Infrastructure.Caching.Abstract;
using SeedWork.Domain.Specifications.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Infrastructure.Caching.Repositories
{
    public class NoteCachedRepository : INoteRepository
    {
        private readonly INoteRepository _noteRepository;
        private readonly ICacheService _cacheService;

        public NoteCachedRepository(INoteRepository noteRepository, ICacheService cacheService)
        {
            _noteRepository = noteRepository;
            _cacheService = cacheService;
        }

        public async Task<bool> AnyAsync(ISpecification<Note> spec)
        {
            // not caching opretions
            return await _noteRepository.AnyAsync(spec);
        }

        public async Task<long> CountAsync(ISpecification<Note> spec)
        {
            // not caching opretions
            return await _noteRepository.CountAsync(spec);
        }

        public async Task CreateAsync(Note entity)
        {
            await _noteRepository.CreateAsync(entity);
            // caching for GetById specification
            var getByIdSpecification = new NoteGetByIdSpecification(entity.Id);
            _cacheService.Set(getByIdSpecification.GetCacheKey(), entity, getByIdSpecification.CacheDuration);

        }

        public async Task DeleteAsync(Note entity)
        {
            // Clean Cache
            var getByIdSpecification = new NoteGetByIdSpecification(entity.Id);
            BackgroundJob.Enqueue(() => _cacheService.Remove(getByIdSpecification.GetCacheKey()));
            await _noteRepository.DeleteAsync(entity);
        }

        public async Task<List<Note>> GetAsync(ISpecification<Note> spec, int limit, int offset)
        {
            // not caching operation
            return await _noteRepository.GetAsync(spec, limit, offset);
        }

        public async Task<Note?> GetOneAsync(ISpecification<Note> spec)
        {
            if (spec is ICachedSpecification<Note> cachedSpecification)
            {
                if (!_cacheService.TryGet(cachedSpecification.GetCacheKey(), out Note? entity))
                {
                    // miss
                    entity = await _noteRepository.GetOneAsync(spec);

                    if (entity is not null)
                        _cacheService.Set(cachedSpecification.GetCacheKey(), entity, cachedSpecification.CacheDuration);
                }
                // hit
                return entity;
            }
            else
            {
                return await _noteRepository.GetOneAsync(spec);
            }
        }

        public async Task UpdateAsync(Note entity)
        {
            // Clean Cache
            var getByIdSpecification = new NoteGetByIdSpecification(entity.Id);
            BackgroundJob.Enqueue(() => _cacheService.Remove(getByIdSpecification.GetCacheKey()));
            await _noteRepository.UpdateAsync(entity);
            // caching for GetById specification
            getByIdSpecification = new NoteGetByIdSpecification(entity.Id);
            _cacheService.Set(getByIdSpecification.GetCacheKey(), entity, getByIdSpecification.CacheDuration);
        }
    }
}
