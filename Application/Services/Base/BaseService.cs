﻿using AmazonTours.Application.Interfaces.Services.Base;
using AmazonTours.Application.Interfaces.UnitOfWork;
using Application.Interfaces.Repositories.Base;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.Services.Base
{
    public class BaseService<T> : IBaseService<T> where T : class, IEntity, new()
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<T> _repository;

        public BaseService(IUnitOfWork unitOfWork, IBaseRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<Guid> AddAsync(T entity)
        {
            var entityId = await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entityId;
        }

        public async Task<Guid> DeleteByIdAsync(Guid id)
        {
            var entityId = await _repository.DeleteByIdAsync(id);
            await _unitOfWork.CommitAsync();
            return entityId;
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IQueryable<T>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetAllAsync(pageNumber, pageSize);
        }

        public async Task<IQueryable<T>> GetAllAsync(params Expression<Func<T, object>>[] IncludeProperties)
        {
            return await _repository.GetAllAsync(IncludeProperties);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<T> PatchAsync(Guid id, T entity)
        {
            var patchedEntity = await _repository.PatchAsync(id, entity);
            await _unitOfWork.CommitAsync();
            return patchedEntity;
        }

        public async Task<T> UpdateAsync(Guid id, T entity)
        {
            var updatedEntity = await _repository.UpdateAsync(id, entity);
            await _unitOfWork.CommitAsync();
            return updatedEntity;
        }
    }
}
