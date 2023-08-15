using AutoMarket.DAL.Interfaces;
using AutoMarket.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMarket.DAL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _db;

        public CarRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Car entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async  Task<bool> Delete(Car entity)
        {
            _db.car.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<Car> Get(int id)
        {
            return await _db.car.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Car>> GetAll()
        {
            return await _db.car.ToListAsync();
        }

        public async Task<Car> GetByName(string name)
        {
			return await _db.car.FirstOrDefaultAsync(c => c.Name == name);
		}
    }
}
