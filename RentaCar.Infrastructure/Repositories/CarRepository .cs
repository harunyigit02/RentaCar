using Dapper;
using RentaCar.Domain.Entities;
using RentaCar.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RentaCar.Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly IDbConnection _dbConnection;
        public CarRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            var sql = "SELECT * FROM Cars";
            return await _dbConnection.QueryAsync<Car>(sql);
        }

        public async Task<Car?> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Cars WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Car>(sql, new { Id = id });
        }

        public async Task AddAsync(Car car)
        {
            var sql = @"INSERT INTO Cars (Brand, Model, DailyPrice, IsAvailable) 
                    VALUES (@Brand, @Model, @DailyPrice, @IsAvailable)";
            await _dbConnection.ExecuteAsync(sql, car);
        }

        public async Task UpdateAsync(Car car)
        {
            var sql = @"UPDATE Cars SET Brand=@Brand, Model=@Model, DailyPrice=@DailyPrice, IsAvailable=@IsAvailable
                    WHERE Id=@Id";
            await _dbConnection.ExecuteAsync(sql, car);
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM Cars WHERE Id=@Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
