﻿using RentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Domain.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car?> GetByIdAsync(int id);
        Task AddAsync(Car car);
        Task UpdateAsync(Car car);
        Task DeleteAsync(int id);
    }
}
