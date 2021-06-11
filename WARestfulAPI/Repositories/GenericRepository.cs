using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WARestfulAPI.Data;
using WARestfulAPI.Dtos;
using WARestfulAPI.Entities.Base;

namespace WARestfulAPI.Repositories
{
    public class GenericRepository<T> where T : Entity
    {
        // repository is dealing with the databse operations
        private readonly DataContext _context;

        public GenericRepository(DataContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T FindById(int id)
        {
            var entity = _context.Set<T>().FirstOrDefault(e => e.Id == id);

            if(entity == null)
            {
                throw new ArgumentNullException();
            }
            return entity;
        }

        public async Task Upsert(T entity)
        {
            if (entity.Id == 0)
            {
                _context.Update(entity);
            }
            else
            {
                _context.Add(entity);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete (int id)
        {
            var entity = _context.Set<T>().FirstOrDefault(e => e.Id == id);

            if(entity != null)
            {
                _context.Remove(entity);
            }

            await _context.SaveChangesAsync();
        }
    }
}
