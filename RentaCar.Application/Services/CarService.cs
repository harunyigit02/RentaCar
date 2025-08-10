using RentaCar.Domain.Entities;
using RentaCar.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Application.Services
{
    public class CarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public Task<IEnumerable<Car>> GetAllCarsAsync() => _carRepository.GetAllAsync();

        public Task<Car?> GetCarByIdAsync(int id) => _carRepository.GetByIdAsync(id);

        public Task AddCarAsync(Car car) => _carRepository.AddAsync(car);

        public Task UpdateCarAsync(Car car) => _carRepository.UpdateAsync(car);

        public Task DeleteCarAsync(int id) => _carRepository.DeleteAsync(id);
    }
}
