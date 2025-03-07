﻿using RahmanyCourses.Core.Entities;
using RahmanyCourses.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Infrastructure.Persistance.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext Context)
        {
            _context = Context;
        }
        public async Task<T> Add(T entity)
        {
            var ent = await _context.Set<T>().AddAsync(entity);
            return ent.Entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().AsQueryable().Where(t => !t.IsDeleted).ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public IQueryable<T> GetQueryableData()
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}
