using AutoMapper;
using CourseWork.Application.Services.Interfaces;
using CourseWork.Infrastructure.Exceptions;
using CourseWork.Persistence.Repositories.Interfaces;
using LazyCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Services.Implementations
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        protected readonly IGenericRepository<TEntity> _repository;
        protected readonly IAppCache _cache;
        protected readonly IMapper _mapper;

        public GenericService(IGenericRepository<TEntity> repository, IAppCache cache, IMapper mapper)
        {
            _repository = repository;
            _cache = cache;
            _mapper = mapper;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new DataNotFoundException($"{typeof(TEntity).Name} with id {id} doesn't exist!");
            }

            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            _cache.Remove(typeof(TEntity).Name);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
            _cache.Remove(typeof(TEntity).Name);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
            _cache.Remove(typeof(TEntity).Name);
        }

        private async Task<IEnumerable<TEntity>> GetCached()
        {
            if (_cache.TryGetValue<IEnumerable<TEntity>>(typeof(TEntity).Name, out var result))
            {
                return result;
            }

            var entities = await _repository.TakeRecords(100);
            _cache.Add(typeof(TEntity).Name, entities, DateTimeOffset.Now.AddMinutes(10));
            return entities;
        }
    }
}
